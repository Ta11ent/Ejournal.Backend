using AutoMapper;
using Ejournal.Application.Application.Command.Schedule_s.CreateSchedule;
using Ejournal.Application.Application.Command.Schedule_s.DeleteSchedule;
using Ejournal.Application.Application.Command.Schedule_s.UpdateSchedule;
using Ejournal.Application.Application.Command.ScheduleDate_s.DeleteScheduleDate;
using Ejournal.Application.Application.Command.ScheduleDate_s.UpdateScheduleDate;
using Ejournal.Application.Application.Command.ScheduleDay_s.CreateCheduleDate;
using Ejournal.Application.Application.Queries.Schedule_s.GetScheduleDetails;
using Ejournal.Application.Application.Queries.Schedule_s.GetScheduleList;
using Ejournal.Application.Application.Queries.ScheduleDay_s.GetScheduleDayDetails;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.WebApi.Models;
using Ejournal.WebApi.Models.ScheduleDay;
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

        [HttpGet]
        public async Task<ActionResult<ScheduleListResponseVm>> GetAll([FromQuery] FilterParams parametrs)
        {
            var query = new GetScheduleListQuery
            {
                Parametrs = parametrs
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


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

        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}")]
        public async Task<ActionResult<ScheduleDayDetailsResponseVm>> GetScheduleDay(Guid scheduleId, int day)
        {
            var query = new GetScheduleDayDetailsQuery
            {
                ScheduleId = scheduleId,
                Day = (DayOfWeek)day
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateScheduleDto createScheduleDto)
        {
            var command = _mapper.Map<CreateScheduleCommmand>(createScheduleDto);
            var scheduleId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = scheduleId }, null);
        }

        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/")]
        public async Task<ActionResult<Guid>> CreateScheduleDay([FromBody] CreateScheduleDayDto createScheduleDayDto,
               Guid scheduleId)
        {
            createScheduleDayDto.ScheuleId = scheduleId;
            var command = _mapper.Map<CreateScheduleDayCommand>(createScheduleDayDto);
            var day = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetScheduleDay), new { scheduleId, day }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateScheduleDto updateScheduleDto, Guid Id)
        {
            updateScheduleDto.ScheduleId = Id;
            var command = _mapper.Map<UpdateScheduleCommand>(updateScheduleDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}")]
        public async Task<IActionResult> UpdateScheduleDay([FromBody] UpdateScheduleDayDto updateScheduleDayDto,
            Guid scheduleId, int day)
        {
            updateScheduleDayDto.ScheduleId = scheduleId;
            updateScheduleDayDto.Day = (DayOfWeek)day;
            var command = _mapper.Map<UpdateSchduleDayCommand>(updateScheduleDayDto);
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

        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}")]
        public async Task<IActionResult> DeleteScheduleDay(Guid scheduleId, int day)
        {
            var command = new DeleteScheduleDayCommand
            {
                ScheduleId = scheduleId,
                Day = (DayOfWeek)day
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
