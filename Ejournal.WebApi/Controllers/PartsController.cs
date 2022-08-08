using AutoMapper;
using Ejournal.Application.Application.Command.Part_s.CreatePart;
using Ejournal.Application.Application.Command.Part_s.DeletePart;
using Ejournal.Application.Application.Command.Part_s.UpdatePart;
using Ejournal.Application.Application.Queries.Part_s.GetPartDetails;
using Ejournal.Application.Application.Queries.Part_s.GetPartList;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.WebApi.Models.Part;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PartsController : BaseController
    {
        private readonly IMapper _mapper;
        public PartsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PartListResponseVm>> GetAll([FromQuery] FilterParams parametrs)
        {
            var query = new GetPartListQuery
            {
                Parametrs = parametrs,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PartDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetPartDetailsQuery
            {
                PartId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePartDto createPartDto)
        {
            var command = _mapper.Map<CreatePartCommand>(createPartDto);
            var partId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = partId }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdatePartDto updatePartDto, Guid Id)
        {
            var command = _mapper.Map<UpdatePartCommand>(updatePartDto);
            command.PartId = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeletePartCommand
            {
                PartId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
