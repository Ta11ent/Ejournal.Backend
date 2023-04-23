using AutoMapper;
using Ejournal.Application.Application.Command.Mark_s.CreateMark;
using Ejournal.Application.Application.Command.Mark_s.DeleteMark;
using Ejournal.Application.Application.Command.Mark_s.UpdateMark;
using Ejournal.Application.Application.Queries.Mark_s.GetMarkDetails;
using Ejournal.Application.Application.Queries.Mark_s.GetMarkList;
using Ejournal.AuthenticationManager.Helpers;
using Ejournal.WebApi.Models.Mark;
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
    public class MarksController : BaseController
    {
        private readonly IMapper _mapper;
        public MarksController(IMapper mapper) => _mapper = mapper;

        /// <summary>Get the list of Mark</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Marks
        /// </remarks>
        /// <param name="filterDto">Filter params</param>
        /// <returns>MarkListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<MarkListResponseVm>> GetAll([FromQuery] GetMarkListDto filterDto)
        {
            var query = _mapper.Map<GetMarkListQuery>(filterDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        /// <summary>Get the Mark by Id</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Marks/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="markId">MarkId (Guid)</param>
        /// <returns>MarkDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet("{markId}")]
        [Authorize(Policy.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<MarkDetailsResponseVm>> Get(Guid markId)
        {
            var query = new GetMarkDetailsQuery
            {
                MarkId = markId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>Create a Mark</summary>
        /// <remarks>
        /// Simple request:
        /// Post /Marks
        /// {
        ///     name: "Name of Mark"
        /// }
        /// </remarks>
        /// <param name="createMarkDto">createMarkDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Authorize(Policy.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMarkDto createMarkDto)
        {
            var command = _mapper.Map<CreateMarkCommand>(createMarkDto);
            var markId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { markId }, null);
        }

        /// <summary>Update the Mark</summary>
        /// <remarks>
        /// Simple request:
        /// Put /Marks/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// {
        ///     name: "Name of Mark"
        /// }
        /// </remarks>
        /// <param name="markId">Mark Id</param>
        /// <param name="updateMarkDto">updateMarkDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut("{markId}")]
        [Authorize(Policy.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Update([FromBody] UpdateMarkDto updateMarkDto, Guid markId)
        {
            var command = _mapper.Map<UpdateMarkCommand>(updateMarkDto);
            command.MarkId = markId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>Delete the Mark</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Marks/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="markId">Mark Id</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete("{markId}")]
        [Authorize(Policy.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(Guid markId)
        {
            var command = new DeleteMarkCommand
            {
                MarkId = markId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
