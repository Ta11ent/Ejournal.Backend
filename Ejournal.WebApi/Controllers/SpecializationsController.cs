using AutoMapper;
using Ejournal.Application.Common.Helpers.Enums;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Ejournal.Command.Specialization_s.CreateSpecialization;
using Ejournal.Application.Ejournal.Command.Specialization_s.DeleteSpecialization;
using Ejournal.Application.Ejournal.Command.Specialization_s.UpdateSpecialization;
using Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationDetails;
using Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationList;
using Ejournal.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SpecializationsController : BaseController
    {
        private readonly IMapper _mapper;
        public SpecializationsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<SpecializationListResponseVm>> GetAll([FromQuery] PaginationParams parametrs)
        {
            var query = new GetSpecializationListQuery
            {
                Parametrs = parametrs,
                Active = true
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
          
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<SpecializationDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetSpecializationDetailsQuery
            {
                SpecializationId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]

        public async Task<ActionResult<Guid>> Create([FromBody] CreateSpecializationDto createSpecializationDto)
        {
            var command = _mapper.Map<CreateSpecializationCommand>(createSpecializationDto);
            var specializationId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = specializationId }, null);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePartDto updateSpecializationDto)
        {
            var command = _mapper.Map<UpdateSpecializationCommand>(updateSpecializationDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeleteSpecializationCommand
            {
                SpecialiationId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}