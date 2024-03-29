﻿using AutoMapper;
using Ejournal.Application.Application.Command.Subject_s.CreateSubject;
using Ejournal.Application.Application.Command.Subject_s.DeleteSubject;
using Ejournal.Application.Application.Command.Subject_s.UpdateSubject;
using Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectDetails;
using Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectList;
using Ejournal.AuthenticationManager.Helpers;
using Ejournal.WebApi.Models.Subject;
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
    public class SubjectsController : BaseController
    {
        private readonly IMapper _mapper;
        public SubjectsController(IMapper mapper) => _mapper = mapper;

        /// <summary>Get the list of Subjects</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Subjects
        /// </remarks>
        /// <param name="filterDto">Filter params</param>
        /// <returns>SubjectListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Authorize(Policy.Student)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<SubjectListResponseVm>> GetAll([FromQuery] GetSubjectListDto filterDto)
        {
            var query = _mapper.Map<GetSubjectListQuery>(filterDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        /// <summary>Get the Subject  by Id</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Subjects/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="subjectId">SubjectId (Guid)</param>
        /// <returns>SubjectDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet("{subjectId}")]
        [Authorize(Policy.Student)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<SubjectDetailsResponseVm>> Get(Guid subjectId)
        {
            var query = new GetSubjectDetailsQuery
            {
                SubjectId = subjectId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>Create a Subject</summary>
        /// <remarks>
        /// Simple request:
        /// Post /Subjects
        /// {
        ///     name: "name of a Subject",
        ///     description: "Description of a Specialiation",
        ///     departmentId: "id of Department"
        /// }
        /// </remarks>
        /// <param name="createSubjectDto">createSubjectDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSubjectDto createSubjectDto)
        {
            var command = _mapper.Map<CreateSubjectCommand>(createSubjectDto);
            var subjectId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { subjectId }, null);
        }

        /// <summary>Update the Subject</summary>
        /// <remarks>
        /// Simple request:
        /// Put /Subjects/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// {
        ///     name: "name of a Specialiation",
        ///     description: "Description of a Specialiation",
        ///     departmentId: "id of Department"
        ///     active: "state"
        /// }
        /// </remarks>
        /// <param name="subjectId">SubjectId (Guid)</param>
        /// <param name="updateSubjectDto">updateSubjectDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut("{subjectId}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Update([FromBody] UpdateSubjectDto updateSubjectDto, Guid subjectId)
        {
            var command = _mapper.Map<UpdateSubjectCommand>(updateSubjectDto);
            command.SubjectId = subjectId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>Delete the Subject</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Subjects/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="subjectId">SubjectId (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete("{subjectId}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(Guid subjectId)
        {
            var command = new DeleteSubjectCommand
            {
                SubjectId = subjectId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
