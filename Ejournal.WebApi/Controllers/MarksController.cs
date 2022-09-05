using AutoMapper;
using Ejournal.Application.Application.Command.Mark_s.CreateMark;
using Ejournal.Application.Application.Command.Mark_s.DeleteMark;
using Ejournal.Application.Application.Command.Mark_s.UpdateMark;
using Ejournal.Application.Application.Queries.Mark_s.GetMarkDetails;
using Ejournal.Application.Application.Queries.Mark_s.GetMarkList;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.WebApi.Helpers;
using Ejournal.WebApi.Models.Mark;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MarksController : BaseController
    {
        private readonly IMapper _mapper;
        public MarksController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Authorize(Policy.Professor)]
        public async Task<ActionResult<MarkListResponseVm>> GetAll([FromQuery] FilterParams parametrs)
        {
            var query = new GetMarkListQuery
            {
                Parametrs = parametrs,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        [HttpGet("{Id}")]
        [Authorize(Policy.Admin)]
        public async Task<ActionResult<MarkDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetMarkDetailsQuery
            {
                MarkId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize(Policy.Admin)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMarkDto createMarkDto)
        {
            var command = _mapper.Map<CreateMarkCommand>(createMarkDto);
            var markId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = markId }, null);
        }

        [HttpPut("{Id}")]
        [Authorize(Policy.Admin)]
        public async Task<IActionResult> Update([FromBody] UpdateMarkDto updateMarkDto, Guid Id)
        {
            var command = _mapper.Map<UpdateMarkCommand>(updateMarkDto);
            command.MarkId = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        [Authorize(Policy.Admin)]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeleteMarkCommand
            {
                MarkId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
