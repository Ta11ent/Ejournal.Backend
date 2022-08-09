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
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto userDto)
        {
            var command = _mapper.Map<CreateUserCommand>(userDto);
            var userId = await Mediator.Send(command);
            if (userDto.CreateIdentity)
            {
                var identityUser = new CreateAspNetUserCommand
                {
                    Id = userId,
                    Email = userDto.Email,
                    PhoneNumber = userDto.PhoneNumber
                };
                
               
                //var newCommand = _mapper.Map<CreateIdentityUserDto>(identityUser);
                await Mediator.Send(identityUser);
            }

                       
            return Ok();
          //  return CreatedAtAction(nameof(Get), new { Id = specializationId }, null);
        }
    }
}
