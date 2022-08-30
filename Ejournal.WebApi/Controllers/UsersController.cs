using AutoMapper;
using Ejournal.Application.Application.Command.User_s.CreateUser;
using Ejournal.Application.Application.Command.User_s.DeleteUser;
using Ejournal.Application.Application.Command.User_s.UpdateUser;
using Ejournal.Application.Application.Queries.User_s.GetUserDetails;
using Ejournal.Application.Application.Queries.User_s.GetUserslist;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.WebApi.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ejournal.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;
        public UsersController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<UserListResponseVm>> GetAll([FromQuery] FilterParams parametrs)
        {
            var query = new GetUserListQuery { Parametrs = parametrs };
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UserDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetUserDetailsQuery { UserId = Id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
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
                    PhoneNumber = userDto.PhoneNumber,
                    Password = userDto.Password
                };

                await Mediator.Send(identityUser);
            }
            return CreatedAtAction(nameof(Get), new { Id = userId }, null);
        }

        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{userId:Guid}/Accounts/")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateIdentityUserDto identityUserDto, Guid userId)
        {
            identityUserDto.Id = userId;
            var identityCommand = _mapper.Map<CreateAspNetUserCommand>(identityUserDto);
            await Mediator.Send(identityCommand);
            var command = new UpdateUserHasAccountFlagCommand
            {
                UserId = userId,
                HasAccount = true
            };
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut("{userId:Guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto, Guid userId)
        {
            updateUserDto.UserId = userId;
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            await Mediator.Send(command);
            if (updateUserDto.HasAccount)
            {
                var identityCommand = new UpdateAspNetUserCommannd { UserId = userId };
                await Mediator.Send(identityCommand);
            }
            return NoContent();
            //добавить логику, если диактивируют пользователя, то и аккаунт надо даективировать. (active = false)
        }

        [HttpDelete("{userId:Guid}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var command = new DeleteUserCommand { UserId = userId };
            var hasAccount = await Mediator.Send(command);
            if (hasAccount)
            {
                var identityCommand = new DeleteAspNetUserCommand { UserId = userId };
                await Mediator.Send(identityCommand);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{userId:Guid}/Accounts/")]
        public async Task<IActionResult> DeleteAccount(Guid userId)
        {
            var identityCommand = new DeleteAspNetUserCommand { UserId = userId };
            await Mediator.Send(identityCommand);
            var command = new UpdateUserHasAccountFlagCommand
            {
                UserId = userId,
                HasAccount = false
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
