using AutoMapper;
using Ejournal.Application.Application.Command.RatingLog_s.CreateRatingLog;
using Ejournal.Application.Application.Command.RatingLog_s.DeleteRatingLog;
using Ejournal.Application.Application.Command.RatingLog_s.UpdateRatingLog;
using Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogDetails;
using Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogList;
using Ejournal.AuthenticationManager.Helpers;
using Ejournal.WebApi.Models.RatingLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RatingLogsController : BaseController
    {
        private readonly IMapper _mapper;
        public RatingLogsController(IMapper mapper) => _mapper = mapper;

        /// <summary>Get the list of RatingLog</summary>
        /// <remarks>
        /// Simple request:
        /// Get /RatingLogs
        /// </remarks>
        /// <param name="filterDto">Filter params</param>
        /// <returns>RatingLogListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Authorize(Policy.Student)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<RatingLogListResponseVm>> GetAll([FromQuery] GetRatingLogListDto filterDto)
        {
            var query = _mapper.Map<GetRatingLogListQuery>(filterDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        /// <summary>Get the RatingLog by Id</summary>
        /// <remarks>
        /// Simple request:
        /// Get /RatingLogs/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="Id">RatingLogId (Guid)</param>
        /// <returns>RatingLogDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet("{Id}")]
        [Authorize(Policy.Student)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<RatingLogDetailsReponseVm>> Get(Guid Id)
        {
            var query = new GetRatingLogDetailsQuery
            {
                RatingLogId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>Create a RatingLog</summary>
        /// <remarks>
        /// Simple request:
        /// Post /RatingLogs
        /// {
        ///     date: "Date of a RatingLog",
        ///     description: "Description of a RatingLog",
        ///     subjectId: "Id by Subject",
        ///     markId: "Id by Mark",
        ///     classMemberId: "id by ClassMember",
        ///     membershipId : "Id by DepartmentMember"
        /// }
        /// </remarks>
        /// <param name="createRatingLogDto">CreateRatingLogDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRatingLogDto createRatingLogDto)
        {
            var command = _mapper.Map<CreateRatingLogCommand>(createRatingLogDto);
            var ratingLogId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = ratingLogId }, null);
        }

        /// <summary>Update the RatingLog</summary>
        /// <remarks>
        /// Simple request:
        /// Put /RatingLogs/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// {
        ///     date: "Date of a RatingLog",
        ///     description: "Description of a RatingLog",
        ///     subjectId: "Id by Subject",
        ///     markId: "Id by Mark",
        ///     classMemberId: "id by ClassMember",
        ///     membershipId : "Id by DepartmentMember"
        /// }
        /// </remarks>
        /// <param name="Id">RatingLogId (Guid)</param>
        /// <param name="updateRatingLogDto">updateRatingLogDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut("{Id}")]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Update([FromBody] UpdateRatingLogDto updateRatingLogDto, Guid Id)
        {
            var command = _mapper.Map<UpdateRatingLogCommand>(updateRatingLogDto);
            command.RatingLogId = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>Delete the RatingLog</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /RatingLogs/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="Id">RatingLogId (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete("{Id}")]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeleteRatingLogCommand
            {
                RatingLogId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
