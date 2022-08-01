using AutoMapper;
using Ejournal.Application.Application.Command.RatingLog_s.CreateRatingLog;
using Ejournal.Application.Application.Command.RatingLog_s.DeleteRatingLog;
using Ejournal.Application.Application.Command.RatingLog_s.UpdateRatingLog;
using Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogDetails;
using Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogList;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.WebApi.Models;
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

        [HttpGet]
        public async Task<ActionResult<RatingLogListResponseVm>> GetAll([FromQuery] FilterParams parametrs)
        {
            var query = new GetRatingLogListQuery
            {
                Parametrs = parametrs,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RatingLogDetailsReponseVm>> Get(Guid Id)
        {
            var query = new GetRatingLogDetailsQuery
            {
                RatingLogId = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRatingLogDto createRatingLogDto)
        {
            var command = _mapper.Map<CreateRatingLogCommand>(createRatingLogDto);
            var ratingLogId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = ratingLogId }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdatePartDto updateSpecializationDto, Guid Id)
        {
            var command = _mapper.Map<UpdateRatingLogCommand>(updateSpecializationDto);
            command.RatingLogId = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
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
