using AutoMapper;
using Ejournal.Application.Application.Command.Claim_s.CreateClaim;
using Ejournal.Application.Application.Command.DepartmentMember_s.CreateDepartmetMember;
using Ejournal.Application.Application.Command.DepartmentMember_s.DeleteDepartmentMember;
using Ejournal.Application.Application.Command.DepartmentMember_s.UpdateDepartmentMember;
using Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberDetails;
using Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList;
using Ejournal.Application.Ejournal.Command.Department_s.CreateDepartment;
using Ejournal.Application.Ejournal.Command.Department_s.DeleteDepartment;
using Ejournal.Application.Ejournal.Command.Department_s.UpdateDepartment;
using Ejournal.Application.Ejournal.Queries.Department_s.GetDeparmentDetails;
using Ejournal.Application.Ejournal.Queries.Department_s.GetDepartmentList;
using Ejournal.AuthenticationManager.Helpers;
using Ejournal.WebApi.Models.Department;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DepartmentsController : BaseController
    {
        private readonly IMapper _mapper;
        public DepartmentsController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Get the list of Departments
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Get /Departments
        /// </remarks>
        /// <param name="filterDto">Filter params</param>
        /// <returns>DepartmentListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DepartmentListResponseVm>> GetAllDeprtments([FromQuery] GetDepartmentListDto filterDto)
        {
            var query = _mapper.Map<GetDepartmentListQuery>(filterDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get the list of Department Members
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Get /Departments/A5DC9FC3-438B-43C8-B562-09552D22E211/Members
        /// </remarks>
        /// <param name="departmentId">MembershipId (Guid)</param>
        /// <param name="filterDto">Filter params</param>
        /// <returns>DepartmentMemberListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DepartmentMemberListResponseVm>> GetDepartmentMembers(Guid departmentId, 
            [FromQuery] GetDepartmentMemberListDto filterDto)
        {
            var query = _mapper.Map<GetDepartmentMemberListQuery>(filterDto);
            query.DepartmentId = departmentId;
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get the Department by Id
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Get /Department/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="departmentId">Department Id (Guid)</param>
        /// <returns>DepartmentDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet("{departmentId:Guid}")]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DepartmentDetailsResponseVm>> GetDepartment(Guid departmentId)
        {
            var query = new GetDepartmentDetailsQuery
            {
                DepartmentId = departmentId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get the DepartmentMember by Id
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Get /Department/A5DC9FC3-438B-43C8-B562-09552D22E211/Members/EF23D499-B69D-479C-A4D8-2B8B39871978
        /// </remarks>
        /// <param name="departmentId">DepartmentId (Guid)</param>
        /// <param name="membershipId">DepartmentId (Guid)</param>
        /// <returns>DepartmentMemberDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/{membershipId:Guid}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DepartmentMemberDetailsResponseVm>> GetDepartmentMember(Guid departmentId, Guid membershipId)
        {
            var query = new GetDepartmentMemberDetailsQuery
            {
                DepartmentId = departmentId,
                MembershipId = membershipId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create a Department
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Post /Departments
        /// {
        ///     name: "Name of a Department",
        ///     decription: "Description of a Department"
        /// }
        /// </remarks>
        /// <param name="createDepartmentDto">createDepartmentDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> CreateDepartment([FromBody] CreateDepartmentDto createDepartmentDto)
        {
            var commad = _mapper.Map<CreateDepartmentCommand>(createDepartmentDto);
            var departmentId = await Mediator.Send(commad);
            return CreatedAtAction(nameof(GetDepartment), new { departmentId }, null);
        }

        /// <summary>
        /// Create a Department Member
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Post /Departments/A5DC9FC3-438B-43C8-B562-09552D22E211/Members/
        /// {
        ///     UserId: "EF23D499-B69D-479C-A4D8-2B8B39871978"
        /// }
        /// </remarks>
        /// <param name="departmentId">departmentId (Guid)</param>
        /// <param name="createDeartmentMemberDto">createDeartmentMemberDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> CreateDepartmentMember([FromBody] CreateDeartmentMemberDto createDeartmentMemberDto,
                Guid departmentId)
        {
            var command = _mapper.Map<CreateDepartmentMemberCommand>(createDeartmentMemberDto);
            command.DepartmentId = departmentId;
            var membershipId = await Mediator.Send(command);

            var cliaimCommand = new CreateClaimsCommand
            {
                UserId = createDeartmentMemberDto.UserId,
                Claims = new List<Claim>()
                {
                    new Claim(ClaimLevel.Type, ClaimLevel.Medium),
                    new Claim(ClaimLevel.Type, ClaimLevel.Low)
                }
            };
            await Mediator.Send(cliaimCommand);
            return CreatedAtAction(nameof(GetDepartmentMember), new { departmentId, membershipId }, null);
        }

        /// <summary>
        /// Update the Department
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Put /Departments/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// {
        ///     name: "Name of the Department",
        ///     description: "Description of the Department"
        ///     active: "State of the Department"
        /// }
        /// </remarks>
        /// <param name="departmentId">Department Id (Guid)</param>
        /// <param name="updateDepartmentDto">updateDepartmentDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut("{departmentId:Guid}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentDto updateDepartmentDto, Guid departmentId)
        {
            var command = _mapper.Map<UpdateDepartmentCommand>(updateDepartmentDto);
            command.DepartmentId = departmentId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update the Department Member
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Put /Departments/A5DC9FC3-438B-43C8-B562-09552D22E211/Members/EF23D499-B69D-479C-A4D8-2B8B39871978
        /// {
        ///     name: "Name of the Department",
        ///     description: "Description of the Department"
        ///     active: "State of the Department"
        /// }
        /// </remarks>
        /// <param name="departmentId">departmentId {Guid}</param>
        /// <param name="membershipId">membershipId {Guid}</param>
        /// <param name="updateDepartmentMemberDto">updateDepartmentMemberDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/{membershipId:Guid}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateDepartmentMember ([FromBody] UpdateDepartmentMemberDto updateDepartmentMemberDto,
            Guid departmentId, Guid membershipId)
        {
            var command = _mapper.Map<UpdateDepartmentMemberCommand>(updateDepartmentMemberDto);
            command.DepartmentId = departmentId;
            command.MembershipId = membershipId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the Department
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Departents/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="departmentId">Department Id</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete("{departmentId:Guid}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteDepartment(Guid departmentId)
        {
            var command = new DeleteDepartmentCommand
            {
                DepartmentId = departmentId
            };
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the Department Member
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Departents/A5DC9FC3-438B-43C8-B562-09552D22E211/Members/EF23D499-B69D-479C-A4D8-2B8B39871978
        /// </remarks>
        /// <param name="departmentId">departmentId (Guid)</param>
        /// <param name="membershipId">Membership Id (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/{membershipId:Guid}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteDepartmentMember(Guid departmentId, Guid membershipId)
        {
            var command = new DeleteDepartmentMemberCommand
            {
                DepartmentId = departmentId,
                MembershipId = membershipId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
