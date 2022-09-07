using AutoMapper;
using Ejournal.Application.Application.Command.Claim_s.CreateClaim;
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
using Ejournal.WebApi.Helpers;
using Ejournal.WebApi.Models.Group;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        /// <summary>Get the list of Groups</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Groups
        /// </remarks>
        /// <param name="filterDto">Filter params</param>
        /// <returns>GroupListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<GroupListResponseVm>> GetGroups([FromQuery] GetGroupListDto filterDto)
        {
            var query = _mapper.Map<GetGroupListQuery>(filterDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        /// <summary>Get the list of Group Members</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Groups/A5DC9FC3-438B-43C8-B562-09552D22E211/Members
        /// </remarks>
        /// <param name="groupId">GroupId (Guid)</param>
        /// <param name="filterDto">Filter params</param>
        /// <returns>GroupMemberListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/")]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<GroupMemberListResponseVm>> GetGroupMembers(Guid groupId, 
            [FromQuery] GetGroupMemberListDto filterDto)
        {
            var query = _mapper.Map<GetGroupMemberListQuery>(filterDto);
            query.GroupId = groupId;
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>Get the Group by Id</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Groups/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="Id">GroupId (Guid)</param>
        /// <returns>GroupDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet("{Id}")]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<GroupDetailsResponseVm>> GetGroupId(Guid Id)
        {
            var query = new GetGroupDetailsQuery
            {
                GroupId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>Get the GroupMember by Id</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Group/A5DC9FC3-438B-43C8-B562-09552D22E211/Members/EF23D499-B69D-479C-A4D8-2B8B39871978
        /// </remarks>
        /// <param name="groupId">GroupId (Guid)</param>
        /// <param name="classMemberId">ClassMemberId (Guid)</param>
        /// <returns>GroupMemberDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/{classMemberId:Guid}")]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

        /// <summary>Create a Group</summary>
        /// <remarks>
        /// Simple request:
        /// Post /Groups
        /// {
        ///     name: "Name of a Groupp",
        ///     startDate: "startDate of a Group",
        ///     endDate : "endDate of a Group",
        ///     specializationId "id by a specialization"
        /// }
        /// </remarks>
        /// <param name="createGroupDto">createGroupDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateGroupDto createGroupDto)
        {
            var command = _mapper.Map<CreateGroupCommand>(createGroupDto);
            var groupId = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetGroupId), new { Id = groupId }, null);
        }

        /// <summary>Create a Group Member</summary>
        /// <remarks>
        /// Simple request:
        /// Post /Groups/A5DC9FC3-438B-43C8-B562-09552D22E211/Members/
        /// {
        ///     UserId: "EF23D499-B69D-479C-A4D8-2B8B39871978"
        /// }
        /// </remarks>
        /// <param name="groupId">GroupID (Guid)</param>
        /// <param name="createGroupMemberDto">createGroupMemberDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> CreateGroupMember([FromBody] CreateGroupMemberDto createGroupMemberDto,
                Guid groupId)
        {
            var command = _mapper.Map<CreateGroupMemberCommand>(createGroupMemberDto);
            command.GroupId = groupId;
            var classMemberId = await Mediator.Send(command);
            var cliaimCommand = new CreateClaimCommand
            {
                UserId = createGroupMemberDto.UserId,
                ClaimType = ClaimLevel.Type,
                ClaimValue = ClaimLevel.Low
            };
            await Mediator.Send(cliaimCommand);
            return CreatedAtAction(nameof(GetGroupMember), new { groupId, classMemberId }, null);
        }

        /// <summary>Update the Group</summary>
        /// <remarks>
        /// Simple request:
        /// Put /Groups/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// {
        ///     name: "Name of a Groupp",
        ///     startDate: "startDate of a Group",
        ///     endDate : "endDate of a Group",
        ///     specializationId "id by a specialization",
        ///     active : "state of Group"
        /// }
        /// </remarks>
        /// <param name="Id">GroupId (Guid)</param>
        /// <param name="updateGroupDto">updateGroupDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut("{Id}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupDto updateGroupDto, Guid Id)
        {
            var command = _mapper.Map<UpdateGroupCommand>(updateGroupDto);
            command.GroupId = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>Update the Group Member</summary>
        /// <remarks>
        /// Simple request:
        /// Put /Groups/A5DC9FC3-438B-43C8-B562-09552D22E211/Members/EF23D499-B69D-479C-A4D8-2B8B39871978
        /// {
        ///     userId: "id by user"
        ///     active: "State of the group"
        /// }
        /// </remarks>
        /// <param name="groupId">GroupId {Guid}</param>
        /// <param name="classMemberId">ClassMemberId {Guid}</param>
        /// <param name="updateGroupMemberDto">updateGroupMemberDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/{classMemberId:Guid}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateGroupMember([FromBody] UpdateGroupMemberDto updateGroupMemberDto,
            Guid groupId, Guid classMemberId)
        {
            var command = _mapper.Map<UpdateGroupMemberCommand>(updateGroupMemberDto);
            command.GroupId = groupId;
            command.ClassMemberId = classMemberId;
            await Mediator.Send(command);
            return NoContent();
        }


        /// <summary>Delete the Group</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Groups/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// <param name="Id">Group Id (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete("{Id}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteGroup(Guid Id)
        {
            var command = new DeleteGroupCommand
            {
                GroupId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>Delete the Group Member</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Groups/A5DC9FC3-438B-43C8-B562-09552D22E211/Members/EF23D499-B69D-479C-A4D8-2B8B39871978
        /// </remarks>
        /// <param name="groupId">GrouptId (Guid)</param>
        /// <param name="classMemberId">ClassMember Id (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{groupId:Guid}/Members/{classMemberId:Guid}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
