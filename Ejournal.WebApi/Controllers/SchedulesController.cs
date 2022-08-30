using AutoMapper;
using Ejournal.Application.Application.Command.Schedule_s.CreateSchedule;
using Ejournal.Application.Application.Command.Schedule_s.DeleteSchedule;
using Ejournal.Application.Application.Command.Schedule_s.UpdateSchedule;
using Ejournal.Application.Application.Command.ScheduleDay_s.DeleteScheduleDate;
using Ejournal.Application.Application.Command.ScheduleDay_s.UpdateScheduleDate;
using Ejournal.Application.Application.Command.ScheduleDay_s.CreateCheduleDate;
using Ejournal.Application.Application.Queries.Schedule_s.GetScheduleDetails;
using Ejournal.Application.Application.Queries.Schedule_s.GetScheduleList;
using Ejournal.Application.Application.Queries.ScheduleDay_s.GetScheduleDayDetails;
using Ejournal.Application.Application.Queries.ScheduleSubject_s.GetScheduleSubjectDetails;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.WebApi.Models.Schedule;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Ejournal.Application.Application.Command.ScheduleSubject_s.CreateScheduleSubject;
using Ejournal.Application.Application.Command.ScheduleSubject_s.UpdateScheduleSubject;
using Ejournal.Application.Application.Command.ScheduleSubject_s.DeleteScheduleSubject;
using Microsoft.AspNetCore.Authorization;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [Authorize]
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
                Day = day
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}/Subjects/{subjectId:Guid}")]
        public async Task<ActionResult<ScheduleDayDetailsResponseVm>> GetScheduleDaySbject(Guid scheduleId, int day, Guid subjectId)
        {
            var query = new GetScheduleSubjectDetailsQuery
            {
                ScheduleId = scheduleId,
                Day = day,
                ScheduleSubjectId = subjectId

            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateScheduleDto modelDto)
        {
            var command = _mapper.Map<CreateScheduleCommmand>(modelDto);
            var scheduleId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = scheduleId }, null);
        }

        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/")]
        public async Task<ActionResult<Guid>> CreateScheduleDay([FromBody] CreateScheduleDayDto modelDto,
               Guid scheduleId)
        {
            modelDto.ScheuleId = scheduleId;
            var command = _mapper.Map<CreateScheduleDayCommand>(modelDto);
            var day = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetScheduleDay), new { scheduleId, day }, null);
        }

        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}/Subjects/")]
        public async Task<ActionResult<Guid>> CreateScheduleDaySubject([FromBody] CreateScheduleSubjectDto modelDto,
              Guid scheduleId, int day)
        {
            modelDto.ScheduleId = scheduleId;
            modelDto.Day = day;
            var command = _mapper.Map<CreateScheduleSubjectCommand>(modelDto);
            var dayId = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetScheduleDay), new { scheduleId, day, dayId }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateScheduleDto modelDto, Guid Id)
        {
            modelDto.ScheduleId = Id;
            var command = _mapper.Map<UpdateScheduleCommand>(modelDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}")]
        public async Task<IActionResult> UpdateScheduleDay([FromBody] UpdateScheduleDayDto modelDto,
            Guid scheduleId, int day)
        {
            modelDto.ScheduleId = scheduleId;
            modelDto.Day = day;
            var command = _mapper.Map<UpdateSchduleDayCommand>(modelDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}/Subjects/{subjectId:Guid}")]
        public async Task<IActionResult> UpdateScheduleDaySubject([FromBody] UpdateScheduleSubjectDto modelDto,
            Guid scheduleId, int day, Guid subjectId)
        {
            modelDto.ScheduleId = scheduleId;
            modelDto.Day = day;
            modelDto.ScheduleSubId = subjectId;
            var command = _mapper.Map<UpdateScheduleSubjectCommand>(modelDto);
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
                Day = day
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}/Subjects/{subjectId:Guid}")]
        public async Task<IActionResult> DeleteScheduleDaySubject(Guid scheduleId, int day, Guid subjectId)
        {
            var command = new DeleteScheduleSubjectCommand
            {
                ScheduleId = scheduleId,
                Day = day,
                ScheduleSubjectId = subjectId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
