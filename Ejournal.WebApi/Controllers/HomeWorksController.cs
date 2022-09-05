using AutoMapper;
using Ejournal.Application.Application.Command.HomeWork_s.CreateHomeWork;
using Ejournal.Application.Application.Command.HomeWork_s.DeleteHomeWork;
using Ejournal.Application.Application.Command.HomeWork_s.UpdateHomeWork;
using Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkDetails;
using Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkList;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.WebApi.Helpers;
using Ejournal.WebApi.Models.HomeWork;
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
    public class HomeWorksController : BaseController
    {
        private readonly IMapper _mapper;
        public HomeWorksController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Authorize(Policy.Student)]
        public async Task<ActionResult<HomeWorkListResponseVm>> GetAll([FromQuery] FilterParams parametrs)
        {
            var query = new GetHomeWorkListQuery
            {
                Parametrs = parametrs,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        [HttpGet("{Id}")]
        [Authorize(Policy.Student)]
        public async Task<ActionResult<HomeWorkDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetHomeWorkDetailsQuery
            {
                HomeWorkId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize(Policy.Professor)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateHomeWorkDto createHomeWorkDto)
        {
            var command = _mapper.Map<CreateHomeWorkCommand>(createHomeWorkDto);
            var homeWorkId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = homeWorkId }, null);
        }

        [HttpPut("{Id}")]
        [Authorize(Policy.Professor)]
        public async Task<IActionResult> Update([FromBody] UpdateHomeWorkDto updateHomeWorkDto, Guid Id)
        {
            var command = _mapper.Map<UpdateHomeWorkCommand>(updateHomeWorkDto);
            command.HomeWorkId = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        [Authorize(Policy.Professor)]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeleteHomeWorkCommand
            {
                HomeWorkId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
