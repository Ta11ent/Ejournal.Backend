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
using Ejournal.WebApi.Models.Schedule;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Ejournal.Application.Application.Command.ScheduleSubject_s.CreateScheduleSubject;
using Ejournal.Application.Application.Command.ScheduleSubject_s.UpdateScheduleSubject;
using Ejournal.Application.Application.Command.ScheduleSubject_s.DeleteScheduleSubject;
using Microsoft.AspNetCore.Authorization;
using Ejournal.AuthenticationManager.Helpers;
using Microsoft.AspNetCore.Http;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SchedulesController : BaseController
    {
        private readonly IMapper _mapper;
        public SchedulesController(IMapper mapper) => _mapper = mapper;

        /// <summary>Get the list of Schedules</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Schedules
        /// </remarks>
        /// <param name="filterDto">Filter params</param>
        /// <returns>ScheduleListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Authorize(Policy.Student)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ScheduleListResponseVm>> GetAll([FromQuery] GetScheduleListDto filterDto)
        {
            var query = _mapper.Map<GetScheduleListQuery>(filterDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>Get the Schedule by Id</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Schedules/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="Id">ScheduleId (Guid)</param>
        /// <returns>ScheduleDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet("{Id}")]
        [Authorize(Policy.Student)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ScheduleDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetScheduleDetailsQuery
            {
                ScheduleId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>Get the ScheduleDay by Id</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Schedules/A5DC9FC3-438B-43C8-B562-09552D22E211/Days/1
        /// </remarks>
        /// <param name="scheduleId">ScheduleId (Guid)</param>
        /// <param name="day">day (int)</param>
        /// <returns>ScheduleDayDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}")]
        [Authorize(Policy.Student)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

        /// <summary>Get the ScheduleDaySubject by Id</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Schedules/A5DC9FC3-438B-43C8-B562-09552D22E211/Days/1/Subjects/EF23D499-B69D-479C-A4D8-2B8B39871978
        /// </remarks>
        /// <param name="scheduleId">scheduleId (Guid)</param>
        /// <param name="day">day (int)</param>
        /// <param name="subjectId">subjectId (Guid)</param>
        /// <returns>ScheduleDayDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}/Subjects/{subjectId:Guid}")]
        [Authorize(Policy.Student)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

        /// <summary>Create a Schedule</summary>
        /// <remarks>
        /// Simple request:
        /// Post /Schedules
        /// {
        ///     description: "Description of a Schedule",
        ///     date: "Date of a Schedule",
        ///     groupId: "Id by Group",
        ///     partId: "Id by Part"
        /// }
        /// </remarks>
        /// <param name="modelDto">CreateScheduleDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateScheduleDto modelDto)
        {
            var command = _mapper.Map<CreateScheduleCommand>(modelDto);
            var scheduleId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = scheduleId }, null);
        }

        /// <summary>Create a SchedulDay</summary>
        /// <remarks>
        /// Simple request:
        /// Post /Schedules/A5DC9FC3-438B-43C8-B562-09552D22E211/Days
        /// {
        ///     day: "day";
        /// }
        /// </remarks>
        /// <param name="scheduleId">ScheduleId (Guid)</param>
        /// <param name="modelDto">CreateScheduleDayDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> CreateScheduleDay([FromBody] CreateScheduleDayDto modelDto,
               Guid scheduleId)
        {
            var command = _mapper.Map<CreateScheduleDayCommand>(modelDto);
            command.ScheduleId = scheduleId;
            var day = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetScheduleDay), new { scheduleId, day }, null);
        }

        /// <summary>Create a ScheduleDaySubject</summary>
        /// <remarks>
        /// Simple request:
        /// Post /Schedules/A5DC9FC3-438B-43C8-B562-09552D22E211/Days/1/Subjects
        /// {
        ///     order: "order",
        ///     SubjectId: "id of Subject",
        ///     MembershipId: "Id of membership"
        /// }
        /// </remarks>
        /// <param name="scheduleId">ScheduleId (Guid)</param>
        /// <param name="day">day of week (int)</param>
        /// <param name="modelDto">CreateScheduleDaySubjectDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}/Subjects/")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> CreateScheduleDaySubject([FromBody] CreateScheduleSubjectDto modelDto,
              Guid scheduleId, int day)
        {
            var command = _mapper.Map<CreateScheduleSubjectCommand>(modelDto);
            command.ScheduleId = scheduleId;
            command.Day = day;
            var schDaySubjectId = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetScheduleDaySbject), new { scheduleId, day, schDaySubjectId }, null);
        }

        /// <summary>Update the Schedule</summary>
        /// <remarks>
        /// Simple request:
        /// Put /Schedules/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// {
        ///     description: "Description of a Schedule",
        ///     date: "Date of a Schedule",
        ///     groupId: "Id by Group",
        ///     partId: "Id by Part",
        ///     active: "state"
        /// }
        /// </remarks>
        /// <param name="Id">ScheduleID (Guid)</param>
        /// <param name="modelDto">UpdateScheduleDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut("{Id}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Update([FromBody] UpdateScheduleDto modelDto, Guid Id)
        {
            var command = _mapper.Map<UpdateScheduleCommand>(modelDto);
            command.ScheduleId = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>Update the ScheduleDay</summary>
        /// <remarks>
        /// Simple request:
        /// Put /Schedules/A5DC9FC3-438B-43C8-B562-09552D22E211/Days/1
        /// {
        ///     active: "state"
        /// }
        /// </remarks>
        /// <param name="scheduleId">ScheduleId (Guid)</param>
        /// <param name="day">Day (int)</param>
        /// <param name="modelDto">UpdateScheduleDayDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateScheduleDay([FromBody] UpdateScheduleDayDto modelDto,
            Guid scheduleId, int day)
        {
            var command = _mapper.Map<UpdateSchduleDayCommand>(modelDto);
            command.ScheduleId = scheduleId;
            command.Day = day;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>Update the ScheduleSubject</summary>
        /// <remarks>
        /// Simple request:
        /// Put /Schedules/A5DC9FC3-438B-43C8-B562-09552D22E211/Days/1/Subjects/EF23D499-B69D-479C-A4D8-2B8B39871978
        /// {
        ///     order: "order",
        ///     subjectId: "id of Subject",
        ///     membershipId: "Id of membership",
        ///     active: "state"
        /// }
        /// </remarks>
        /// <param name="scheduleId">ScheduleId (Guid)</param>
        /// <param name="day">Day (int)</param>
        /// /// <param name="schSubjectId">SchduleSubject (int)</param>
        /// <param name="modelDto">UpdateScheduleDayDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}/Subjects/{subjectId:Guid}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateScheduleDaySubject([FromBody] UpdateScheduleSubjectDto modelDto,
            Guid scheduleId, int day, Guid schSubjectId)
        {
            var command = _mapper.Map<UpdateScheduleSubjectCommand>(modelDto);
            command.ScheduleId = scheduleId;
            command.Day = day;
            command.ScheduleSubjectId = schSubjectId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>Delete the Schedule</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Schedules/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="Id">ScheduleID (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete("{Id}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeleteScheduleComamnd
            {
                ScheduleId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>Delete the ScheduleDay</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Schedules/A5DC9FC3-438B-43C8-B562-09552D22E211/Days/1
        /// </remarks>
        /// <param name="scheduleId">ScheduleID (Guid)</param>
        /// <param name="day">Day (int)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

        /// <summary>Delete the ScheduleDaySubject</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Schedules/A5DC9FC3-438B-43C8-B562-09552D22E211/Days/1/Subjects/EF23D499-B69D-479C-A4D8-2B8B39871978
        /// </remarks>
        /// <param name="scheduleId">ScheduleID (Guid)</param>
        /// <param name="day">Day (int)</param>
        /// <param name="subjectId">SubjectId (int)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{scheduleId:Guid}/Days/{day:int}/Subjects/{subjectId:Guid}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
