using AutoMapper;
using Ejournal.Application.Application.Command.HomeWork_s.CreateHomeWork;
using Ejournal.Application.Application.Command.HomeWork_s.DeleteHomeWork;
using Ejournal.Application.Application.Command.HomeWork_s.UpdateHomeWork;
using Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkDetails;
using Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkList;
using Ejournal.AuthenticationManager.Helpers;
using Ejournal.WebApi.Models.HomeWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        /// <summary>Get the list of HomeWork</summary>
        /// <remarks>
        /// Simple request:
        /// Get /HomeWorks
        /// </remarks>
        /// <param name="filterDto">Filter params</param>
        /// <returns>HomeWorkListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Authorize(Policy.Student)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<HomeWorkListResponseVm>> GetAll([FromQuery] GetHomeWorkListDto filterDto)
        {
            var query = _mapper.Map<GetHomeWorkListQuery>(filterDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        /// <summary>Get the HomeWork by Id</summary>
        /// <remarks>
        /// Simple request:
        /// Get /HomeWorks/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="homeWorkId">HomeWorkId (Guid)</param>
        /// <returns>HomeWorkDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet("{homeWorkId}")]
        [Authorize(Policy.Student)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<HomeWorkDetailsResponseVm>> Get(Guid homeWorkId)
        {
            var query = new GetHomeWorkDetailsQuery
            {
                HomeWorkId = homeWorkId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>Create a HomeWork</summary>
        /// <remarks>
        /// Simple request:
        /// Post /HomeWorks
        /// {
        ///     Date: "Date of a HomeWork",
        ///     Description : "Description of a HomeWork",
        ///     GroupId : "Id by Group",
        ///     SubjectId: "Id by Subject"
        ///     
        /// }
        /// </remarks>
        /// <param name="createHomeWorkDto">CreateHomeWorkDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateHomeWorkDto createHomeWorkDto)
        {
            var command = _mapper.Map<CreateHomeWorkCommand>(createHomeWorkDto);
            var homeWorkId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { homeWorkId }, null);
        }

        /// <summary>Update the HomeWork</summary>
        /// <remarks>
        /// Simple request:
        /// Put /HomeWorks/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// {
        ///     Date: "Date of a HomeWork",
        ///     Description : "Description of a HomeWork",
        ///     GroupId : "Id by Group",
        ///     SubjectId: "Id by Subject"
        /// }
        /// </remarks>
        /// <param name="homeWorkId">HomeWork Id</param>
        /// <param name="updateHomeWorkDto">updateCourseDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut("{homeWorkId}")]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Update([FromBody] UpdateHomeWorkDto updateHomeWorkDto, Guid homeWorkId)
        {
            var command = _mapper.Map<UpdateHomeWorkCommand>(updateHomeWorkDto);
            command.HomeWorkId = homeWorkId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the HomeWork
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// Delete /HomeWorks/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="homeWorkId">HomeWork Id</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete("{homeWorkId}")]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(Guid homeWorkId)
        {
            var command = new DeleteHomeWorkCommand
            {
                HomeWorkId = homeWorkId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
