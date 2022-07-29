﻿using AutoMapper;
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
using Ejournal.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GroupsController : BaseController
    {
        private readonly IMapper _mapper;
        public GroupsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<GroupListResponseVm>> GetAll([FromQuery] PaginationParams parametrs)
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
        public async Task<ActionResult<GroupMemberListResponseVm>> GetDepartmentMembers(Guid groupId, 
            [FromQuery] PaginationParams parametrs)
        {
            var query = new GetGroupMemberListQuery
            {
                GroupId = groupId,
                Parametrs = parametrs,
                Active = true
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GroupDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetGroupDetailsQuery
            {
                GroupId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/{memberId:Guid}")]
        public async Task<ActionResult<GroupMemberDetailsResponseVm>> GetDepartmentMember(Guid groupId, Guid memberId)
        {
            var query = new GetGroupMemberDetailsQuery
            {
                GroupId = groupId,
                MemberId = memberId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateGroupDto createGroupDto)
        {
            var command = _mapper.Map<CreateGroupCommand>(createGroupDto);
            var groupId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = groupId }, null);
        }

        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/")]
        public async Task<ActionResult<Guid>> CreateDepartmentMember([FromBody] CreateGroupMemberDto createGroupMemberDto,
                Guid groupId)
        {
            var command = _mapper.Map<CreateGroupMemberCommand>(createGroupMemberDto);
            command.GroupId = groupId;
            var memberId = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetDepartmentMember), new { groupId, memberId }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateGroupDto updateGroupDto, Guid Id)
        {
            var command = _mapper.Map<UpdateGroupCommand>(updateGroupDto);
            command.GroupId = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/{memberId:Guid}")]
        public async Task<IActionResult> UpdateDepartmentMember([FromBody] UpdateGroupMemberDto updateGroupMemberDto,
            Guid groupId, Guid memberId)
        {
            var command = _mapper.Map<UpdateGroupMemberCommand>(updateGroupMemberDto);
            command.GroupId = groupId;
            command.GroupMemberId = memberId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeleteGroupCommand
            {
                GroupId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/{memberId:Guid}")]
        public async Task<IActionResult> DeleteDepartmentMember(Guid groupId, Guid memberId)
        {
            var command = new DeleteGroupMemberCommand
            {
                GroupId = groupId,
                GroupMemberId = memberId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
