using AutoMapper;
using Ejournal.Application.Application.Command.Subject_s.CreateSubject;
using Ejournal.Application.Application.Command.Subject_s.DeleteSubject;
using Ejournal.Application.Application.Command.Subject_s.UpdateSubject;
using Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectDetails;
using Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectList;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.WebApi.Helpers;
using Ejournal.WebApi.Models.Subject;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize(Policy.Student)]
        public async Task<ActionResult<SubjectListResponseVm>> GetAll([FromQuery] FilterParams parametrs)
        {
            var query = new GetSubjectListQuery
            {
                Parametrs = parametrs,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        [HttpGet("{Id}")]
        [Authorize(Policy.Student)]
        public async Task<ActionResult<SubjectDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetSubjectDetailsQuery
            {
                SubjectId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize(Policy.Management)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSubjectDto createSubjectDto)
        {
            var command = _mapper.Map<CreateSubjectCommand>(createSubjectDto);
            var subjectId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = subjectId }, null);
        }

        [HttpPut("{Id}")]
        [Authorize(Policy.Management)]
        public async Task<IActionResult> Update([FromBody] UpdateSubjectDto updateSubjectDto, Guid Id)
        {
            var command = _mapper.Map<UpdateSubjectCommand>(updateSubjectDto);
            command.SubjectId = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        [Authorize(Policy.Management)]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeleteSubjectCommand
            {
                SubjectId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
