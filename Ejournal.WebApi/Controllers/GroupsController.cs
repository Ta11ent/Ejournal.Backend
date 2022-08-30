using AutoMapper;
using Ejournal.Application.Application.Command.Goup_s.CreateGroup;
using Ejournal.Application.Application.Command.Goup_s.DeleteGroup;
using Ejournal.Application.Application.Command.Goup_s.UpdateGroup;
using Ejournal.Application.Application.Command.GroupMember.CreateGroupMember;
using Ejournal.Application.Application.Command.GroupMember.DeleteGroupMember;
using Ejournal.Application.Application.Command.GroupMember.UpdateGroupMember;
using Ejournal.Application.Application.Queries.Goup_s.GetGroupDetails;
using Ejournal.Application.Application.Queries.Goup_s.GetGroupList;
using Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberDetails;
using Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberList;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.WebApi.Models.Group;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GroupsController : BaseController
    {
        private readonly IMapper _mapper;
        public GroupsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<GroupListResponseVm>> GetGroups([FromQuery] FilterParams parametrs)
        {
            var query = new GetGroupListQuery
            {
                Parametrs = parametrs,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/")]
        public async Task<ActionResult<GroupMemberListResponseVm>> GetGroupMembers(Guid groupId, 
            [FromQuery] FilterParams parametrs)
        {
            var query = new GetGroupMemberListQuery
            {
                GroupId = groupId,
                Parametrs = parametrs,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GroupDetailsResponseVm>> GetGroupId(Guid Id)
        {
            var query = new GetGroupDetailsQuery
            {
                GroupId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/{classMemberId:Guid}")]
        public async Task<ActionResult<GroupMemberDetailsResponseVm>> GetGroupMember(Guid groupId, Guid classMemberId)
        {
            var query = new GetGroupMemberDetailsQuery
            {
                GroupId = groupId,
                ClassMemberId = classMemberId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateGroupDto createGroupDto)
        {
            var command = _mapper.Map<CreateGroupCommand>(createGroupDto);
            var groupId = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetGroupId), new { Id = groupId }, null);
        }

        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/")]
        public async Task<ActionResult<Guid>> CreateGroupMember([FromBody] CreateGroupMemberDto createGroupMemberDto,
                Guid groupId)
        {
            var command = _mapper.Map<CreateGroupMemberCommand>(createGroupMemberDto);
            command.GroupId = groupId;
            var memberId = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetGroupMember), new { groupId, memberId }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupDto updateGroupDto, Guid Id)
        {
            var command = _mapper.Map<UpdateGroupCommand>(updateGroupDto);
            command.GroupId = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/{classMemberId:Guid}")]
        public async Task<IActionResult> UpdateGroupMember([FromBody] UpdateGroupMemberDto updateGroupMemberDto,
            Guid groupId, Guid classMemberId)
        {
            var command = _mapper.Map<UpdateGroupMemberCommand>(updateGroupMemberDto);
            command.GroupId = groupId;
            command.ClassMemberId = classMemberId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGroup(Guid Id)
        {
            var command = new DeleteGroupCommand
            {
                GroupId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/{classMemberId:Guid}")]
        public async Task<IActionResult> DeleteGroupMember(Guid groupId, Guid classMemberId)
        {
            var command = new DeleteGroupMemberCommand
            {
                GroupId = groupId,
                ClassMemberId = classMemberId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
