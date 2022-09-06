using AutoMapper;
using Ejournal.Application.Ejournal.Command.Course_s.CreateCourse;
using Ejournal.Application.Ejournal.Command.Course_s.DeleteCourse;
using Ejournal.Application.Ejournal.Command.Course_s.UpdateCourse;
using Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseDetails;
using Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseList;
using Ejournal.WebApi.Helpers;
using Ejournal.WebApi.Models.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
 
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CoursesController : BaseController
    {
        private readonly IMapper _mapper;
        public CoursesController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Get the list of Courses
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Get /Courses
        /// </remarks>
        /// <param name="filterDto">Filter params</param>
        /// <returns>CourseListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<CourseListResponseVm>> GetAll([FromQuery] GetCoursesFilterDto filterDto)
        {
            var query = _mapper.Map<GetCourseListQuery>(filterDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Get the Course by Id
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Get /Courses/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="Id">Course Id (Guid)</param>
        /// <returns>CourseDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet("{Id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<CourseDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetCourseDetailsQuery
            {
                CourseId = Id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create a course
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Post /Courses
        /// {
        ///     name: "Name of Course"
        /// }
        /// </remarks>
        /// <param name="createCourseDto">CreateCourseDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCourseDto createCourseDto)
        {
            var command = _mapper.Map<CreateCourseCommand>(createCourseDto);
            var courseId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = courseId }, null);
        }

        /// <summary>
        /// Update the Course
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Put /Courses/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// {
        ///     name: "Name of Course",
        ///     active: "State of Course"
        /// }
        /// </remarks>
        /// <param name="updateCourseDto">updateCourseDto object</param>
        /// <param name="CourseId">Course Id</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut("{Id}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Update([FromBody] UpdateCourseDto updateCourseDto, Guid CourseId)
        {
            var command = _mapper.Map<UpdateCourseCommand>(updateCourseDto);
            command.CourseId = CourseId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update the Course
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Courses/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="Id">Course Id</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete("{Id}")]
        [Authorize(Policy.Management)]
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
