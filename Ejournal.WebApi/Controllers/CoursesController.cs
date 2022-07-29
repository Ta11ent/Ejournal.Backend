using AutoMapper;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Ejournal.Command.Course_s.CreateCourse;
using Ejournal.Application.Ejournal.Command.Course_s.DeleteCourse;
using Ejournal.Application.Ejournal.Command.Course_s.UpdateCourse;
using Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseDetails;
using Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseList;
using Ejournal.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CoursesController : BaseController
    {
        private readonly IMapper _mapper;
        public CoursesController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<CourseListResponseVm>> GetAll([FromQuery] FilterParams parametrs)
        {
            var query = new GetCourseListQuery
            {
                Parametrs = parametrs,
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CourseDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetCourseDetailsQuery
            {
                CourseId = Id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCourseDto createCourseDto)
        {
            var command = _mapper.Map<CreateCourseCommand>(createCourseDto);
            var courseId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = courseId }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseDto updateCourseDto, Guid CourseId)
        {
            var command = _mapper.Map<UpdateCourseCommand>(updateCourseDto);
            command.CourseId = CourseId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeleteCourseCommand
            {
                CourseId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
