using AutoMapper;
using Ejournal.Application.Application.Command.DepartmentMember_s.CreateDepartmetMember;
using Ejournal.Application.Application.Command.DepartmentMember_s.DeleteDepartmentMember;
using Ejournal.Application.Application.Command.DepartmentMember_s.UpdateDepartmentMember;
using Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberDetails;
using Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Ejournal.Command.Department_s.CreateDepartment;
using Ejournal.Application.Ejournal.Command.Department_s.DeleteDepartment;
using Ejournal.Application.Ejournal.Command.Department_s.UpdateDepartment;
using Ejournal.Application.Ejournal.Queries.Department_s.GetDeparmentDetails;
using Ejournal.Application.Ejournal.Queries.Department_s.GetDepartmentList;
using Ejournal.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<ActionResult<DepartmentListResponseVm>> GetAllDeprtments([FromQuery] PaginationParams parametrs)
        {
            var query = new GetDepartmentListQuery
            {
                Parametrs = parametrs,
                Active = true
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/")]
        public async Task<ActionResult<DepartmentMemberListResponseVm>> GetDepartmentMembers(Guid departmentId, 
            [FromQuery] PaginationParams parametrs)
        {
            var query = new GetDepartmentMemberListQuery
            {
                DepartmentId = departmentId,
                Parametrs = parametrs,
                 Active = true
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{Id:Guid}")]
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
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/{memberId:Guid}")]
        public async Task<ActionResult<DepartmentMemberDetailsResponseVm>> GetDepartmentMember(Guid departmentId, Guid memberId)
        {
            var query = new GetDepartmentMemberDetailsQuery
            {
                DepartmentId = departmentId,
                DepartmentMemberId = memberId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateDepartment([FromBody] CreateDepartmentDto createDepartmentDto)
        {
            var commad = _mapper.Map<CreateDepartmentCommand>(createDepartmentDto);
            var departmentId = await Mediator.Send(commad);
            return CreatedAtAction(nameof(GetDepartment), new { Id = departmentId }, null);
        }

        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/")]
        public async Task<ActionResult<Guid>> CreateDepartmentMember([FromBody] CreateDeartmentMemberDto createDeartmentMemberDto,
                Guid departmentId)
        {
            var command = _mapper.Map<CreateDepartmentMemberCommand>(createDeartmentMemberDto);
            command.DepartmentId = departmentId;
            var memberId = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetDepartmentMember), new { departmentId, memberId }, null);
        }

        [HttpPut("{Id:Guid}")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentDto updateDepartmentDto, Guid Id)
        {
            var command = _mapper.Map<UpdateDepartmentCommand>(updateDepartmentDto);
            command.DepartmentId = Id;
            command.Active = true;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/{memberId:Guid}")]
        public async Task<IActionResult> UpdateDepartmentMember([FromBody] UpdateDepartmentMemberDto updateDepartmentMemberDto,
            Guid departmentId, Guid memberId)
        {
            var command = _mapper.Map<UpdateDepartmentMemberCommand>(updateDepartmentMemberDto);
            command.DepartmentId = departmentId;
            command.DepartmentMemberId = memberId;
            command.Active = true;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id:Guid}")]
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
        [Route("/api/v{version:apiVersion}/[controller]/{departmentId:Guid}/Members/{memberId:Guid}")]
        public async Task<IActionResult> DeleteDepartmentMember(Guid departmentId, Guid memberId)
        {
            var command = new DeleteDepartmentMemberCommand
            {
                DepartmentId = departmentId,
                DepartmentMemberId = memberId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
