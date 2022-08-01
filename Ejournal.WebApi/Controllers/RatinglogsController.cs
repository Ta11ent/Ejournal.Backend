using Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogDetails;
using Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogList;
using Ejournal.Application.Common.Helpers.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RatinglogsController : BaseController
    {
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
    }
}
