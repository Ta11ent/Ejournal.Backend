using AutoMapper;
using Ejournal.Application.Application.Command.User_s.CreateUser;
using Ejournal.WebApi.Models.User;
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
    public class UsersController : BaseController
    {

        private readonly IMapper _mapper;
        public UsersController(IMapper mapper) => _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createUserDto,
            [FromBody] CreateIdentityUserDto createIdentityUser)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDto);
            var userId = await Mediator.Send(command);
            if (createIdentityUser.CreateIdentity)
            {
                createIdentityUser.Id = userId;
                var identityCommand = _mapper.Map<CreateAspNetUserCommand>(createIdentityUser);
            }
            return Ok();
          //  return CreatedAtAction(nameof(Get), new { Id = specializationId }, null);
        }
    }
}
