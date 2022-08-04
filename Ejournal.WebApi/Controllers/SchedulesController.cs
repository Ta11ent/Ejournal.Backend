﻿using AutoMapper;
using Ejournal.Application.Application.Command.Schedule_s.CreateSchedule;
using Ejournal.Application.Application.Command.Schedule_s.DeleteSchedule;
using Ejournal.Application.Application.Command.Schedule_s.UpdateSchedule;
using Ejournal.Application.Application.Queries.Schedule_s.GetScheduleDetails;
using Ejournal.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SchedulesController : BaseController
    {
        private readonly IMapper _mapper;
        public SchedulesController(IMapper mapper) => _mapper = mapper;


        [HttpGet("{Id}")]
        public async Task<ActionResult<ScheduleDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetScheduleDetailsQuery
            {
                ScheduleId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateScheduleDto createScheduleDto)
        {
            var command = _mapper.Map<CreateScheduleCommmand>(createScheduleDto);
            var ratingLogId = await Mediator.Send(command);
            return Ok();
           // return CreatedAtAction(nameof(Get), new { Id = ratingLogId }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateScheduleDto updateScheduleDto, Guid Id)
        {
            updateScheduleDto.ScheduleId = Id;
            var command = _mapper.Map<UpdateScheduleCommand>(updateScheduleDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeleteScheduleComamnd
            {
                ScheduleId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
