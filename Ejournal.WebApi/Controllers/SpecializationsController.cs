using AutoMapper;
using Ejournal.Application.Ejournal.Command.Specialization_s.CreateSpecialization;
using Ejournal.Application.Ejournal.Command.Specialization_s.DeleteSpecialization;
using Ejournal.Application.Ejournal.Command.Specialization_s.UpdateSpecialization;
using Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationDetails;
using Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationList;
using Ejournal.AuthenticationManager.Helpers;
using Ejournal.WebApi.Models.Specialization;
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
    public class SpecializationsController : BaseController
    {
        private readonly IMapper _mapper;
        public SpecializationsController(IMapper mapper) => _mapper = mapper;

        /// <summary>Get the list of Specialiation</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Specialiations
        /// </remarks>
        /// <param name="filterDto">Filter params</param>
        /// <returns>SpecialiationListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<SpecializationListResponseVm>> GetAll([FromQuery] GetSpecializationListDto filterDto)
        {
            var query = _mapper.Map<GetSpecializationListQuery>(filterDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);
          
        }

        /// <summary>Get the Specialiation by Id</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Specialiations/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="Id">SpecialiationId (Guid)</param>
        /// <returns>SpecialiationDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet("{Id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<SpecializationDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetSpecializationDetailsQuery
            {
                SpecializationId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>Create a Specialiation</summary>
        /// <remarks>
        /// Simple request:
        /// Post /Specialiations
        /// {
        ///     name: "name of a Specialiation",
        ///     description: "Description of a Specialiation"
        /// }
        /// </remarks>
        /// <param name="createSpecializationDto">createSpecializationDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSpecializationDto createSpecializationDto)
        {
            var command = _mapper.Map<CreateSpecializationCommand>(createSpecializationDto);
            var specializationId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = specializationId }, null);
        }

        /// <summary>Update the Specialiation</summary>
        /// <remarks>
        /// Simple request:
        /// Put /Specialiations/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// {
        ///     name: "name of a Specialiation",
        ///     description: "Description of a Specialiation",
        ///     active: "state"
        /// }
        /// </remarks>
        /// <param name="Id">SpecialiationId (Guid)</param>
        /// <param name="updateSpecializationDto">updateSpecializationDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut("{Id}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Update([FromBody] UpdateSpecializationDto updateSpecializationDto, Guid Id)
        {
            var command = _mapper.Map<UpdateSpecializationCommand>(updateSpecializationDto);
            command.SpecializationId = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>Delete the Specialiation</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Specialiations/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="Id">SpecialiationId (Guid)</param>
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
            var command = new DeleteSpecializationCommand
            {
                SpecialiationId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}