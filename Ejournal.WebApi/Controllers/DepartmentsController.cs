﻿using AutoMapper;
using Ejournal.Application.Application.Command.Claim_s.CreateClaim;
using Ejournal.Application.Application.Command.DepartmentMember_s.CreateDepartmetMember;
using Ejournal.Application.Application.Command.DepartmentMember_s.DeleteDepartmentMember;
using Ejournal.Application.Application.Command.DepartmentMember_s.UpdateDepartmentMember;
using Ejournal.Application.Application.Command.UserClaim_s.DeleteClaim;
using Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberDetails;
using Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Ejournal.Command.Department_s.CreateDepartment;
using Ejournal.Application.Ejournal.Command.Department_s.DeleteDepartment;
using Ejournal.Application.Ejournal.Command.Department_s.UpdateDepartment;
using Ejournal.Application.Ejournal.Queries.Department_s.GetDeparmentDetails;
using Ejournal.Application.Ejournal.Queries.Department_s.GetDepartmentList;
using Ejournal.WebApi.Helpers;
using Ejournal.WebApi.Models.Department;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<DepartmentListResponseVm>> GetAllDeprtments([FromQuery] FilterParams parametrs)
        {
            var query = new GetDepartmentListQuery
            {
                Parametrs = parametrs,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/")]
        [Authorize]
        public async Task<ActionResult<DepartmentMemberListResponseVm>> GetDepartmentMembers(Guid departmentId, 
            [FromQuery] FilterParams parametrs)
        {
            var query = new GetDepartmentMemberListQuery
            {
                DepartmentId = departmentId,
                Parametrs = parametrs,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{Id:Guid}")]
        [Authorize(Policy.Professor)]
        public async Task<ActionResult<DepartmentDetailsResponseVm>> GetDepartment(Guid Id)
        {
            var query = new GetDepartmentDetailsQuery
            {
                DepartmentId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/{membershipId:Guid}")]
        [Authorize(Policy.Management)]
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

        [HttpPost]
        [Authorize(Policy.Management)]
        public async Task<ActionResult<Guid>> CreateDepartment([FromBody] CreateDepartmentDto createDepartmentDto)
        {
            var commad = _mapper.Map<CreateDepartmentCommand>(createDepartmentDto);
            var departmentId = await Mediator.Send(commad);
            return CreatedAtAction(nameof(GetDepartment), new { Id = departmentId }, null);
        }

        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/")]
        [Authorize(Policy.Management)]
        public async Task<ActionResult<Guid>> CreateDepartmentMember([FromBody] CreateDeartmentMemberDto createDeartmentMemberDto,
                Guid departmentId)
        {
            createDeartmentMemberDto.MembershipId = departmentId;
            var command = _mapper.Map<CreateDepartmentMemberCommand>(createDeartmentMemberDto);
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

        [HttpPut("{Id:Guid}")]
        [Authorize(Policy.Management)]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentDto updateDepartmentDto, Guid Id)
        {
            var command = _mapper.Map<UpdateDepartmentCommand>(updateDepartmentDto);
            command.DepartmentId = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/{membershipId:Guid}")]
        [Authorize(Policy.Management)]
        public async Task<IActionResult> UpdateDepartmentMember ([FromBody] UpdateDepartmentMemberDto updateDepartmentMemberDto,
            Guid departmentId, Guid membershipId)
        {
            var command = _mapper.Map<UpdateDepartmentMemberCommand>(updateDepartmentMemberDto);
            command.DepartmentId = departmentId;
            command.MembershipId = membershipId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id:Guid}")]
        [Authorize(Policy.Management)]
        public async Task<IActionResult> DeleteDepartment(Guid Id)
        {
            var command = new DeleteDepartmentCommand
            {
                DepartmentId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/{membershipId:Guid}")]
        [Authorize(Policy.Management)]
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
