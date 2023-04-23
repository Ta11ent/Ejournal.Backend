using AutoMapper;
using Ejournal.Application.Application.Command.Part_s.CreatePart;
using Ejournal.Application.Application.Command.Part_s.DeletePart;
using Ejournal.Application.Application.Command.Part_s.UpdatePart;
using Ejournal.Application.Application.Queries.Part_s.GetPartDetails;
using Ejournal.Application.Application.Queries.Part_s.GetPartList;
using Ejournal.AuthenticationManager.Helpers;
using Ejournal.WebApi.Models.Part;
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
    public class PartsController : BaseController
    {
        private readonly IMapper _mapper;
        public PartsController(IMapper mapper) => _mapper = mapper;

        /// <summary>Get the list of Parts</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Parts
        /// </remarks>
        /// <param name="filterDto">Filter params</param>
        /// <returns>PartListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PartListResponseVm>> GetAll([FromQuery] GetPartListDto filterDto)
        {
            var query = _mapper.Map<GetPartListQuery>(filterDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>Get the Part by Id</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Parts/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="partId">PartId (Guid)</param>
        /// <returns>PartDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet("{partId:Guid}")]
        [Authorize(Policy.Professor)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<PartDetailsResponseVm>> Get(Guid partId)
        {
            var query = new GetPartDetailsQuery
            {
                PartId = partId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>Create a Part</summary>
        /// <remarks>
        /// Simple request:
        /// Post /Parts
        /// {
        ///     name: "Name of Part",
        ///     startDate: "Start date of a Part",
        ///     endDate: "End Daate of a Part"
        /// }
        /// </remarks>
        /// <param name="createPartDto">createPartDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePartDto createPartDto)
        {
            var command = _mapper.Map<CreatePartCommand>(createPartDto);
            var partId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { partId }, null);
        }

        /// <summary>Update the Part</summary>
        /// <remarks>
        /// Simple request:
        /// Put /Parts/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// {
        ///     name: "Name of Part",
        ///     startDate: "Start date of a Part",
        ///     endDate: "End Daate of a Part"
        /// }
        /// </remarks>
        /// <param name="partId">Part Id</param>
        /// <param name="updatePartDto">updateMarkDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut("{partId}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Update([FromBody] UpdatePartDto updatePartDto, Guid partId)
        {
            var command = _mapper.Map<UpdatePartCommand>(updatePartDto);
            command.PartId = partId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>Delete the Part</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Parts/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="Id">Part Id</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete("{partId:Guid}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(Guid partId)
        {
            var command = new DeletePartCommand
            {
                PartId = partId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
