using Ejournal.Application.Application.Queries.User_s.GetUserDetails;
using Ejournal.Application.Application.Queries.User_s.GetUserslist;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class IdentityController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<UserListVm>> GetAll()
        {
            var query = new GetUserListQuery
            {
                Active = false
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UserDetailsVm>> Get(Guid Id)
        {
            var query = new GetUserDetailsQuery
            {
                Id = Id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
