using AutoMapper;
using Ejournal.Application.Application.Command.Claim_s.CreateClaim;
using Ejournal.Application.Application.Command.User_s.CreateUser;
using Ejournal.Application.Application.Command.User_s.DeleteUser;
using Ejournal.Application.Application.Command.User_s.UpdateUser;
using Ejournal.Application.Application.Command.UserClaim_s.DeleteClaim;
using Ejournal.Application.Application.Queries.User_s.GetUserDetails;
using Ejournal.Application.Application.Queries.User_s.GetUserslist;
using Ejournal.Application.Application.Queries.UserClaim_s.GetUserClaimsList;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.WebApi.Helpers;
using Ejournal.WebApi.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet]
        [Authorize(Policy.Management)]
        public async Task<ActionResult<UserListResponseVm>> GetAllUsers([FromQuery] FilterParams parametrs)
        {
            var query = new GetUserListQuery { Parametrs = parametrs };
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{userId:Guid}/Claims/")]
        [Authorize(Policy.Management)]
        public async Task<ActionResult<UserListResponseVm>> GetUserClaims([FromQuery] FilterParams parametrs, Guid userId)
        {
            var query = new GetClaimListQuery { Parametrs = parametrs, UserId = userId };
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        [HttpGet("{Id}")]
        [Authorize(Policy.Management)]
        public async Task<ActionResult<UserDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetUserDetailsQuery { UserId = Id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        [Authorize(Policy.Management)]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserDto userDto)
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
        [Authorize(Policy.Management)]
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

        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{userId:Guid}/Claims/")]
        [Authorize(Policy.Admin)]
        public async Task<IActionResult> CreateClaim([FromBody] CreateUserClaimDto createUserClaimDto, Guid userId)
        {
            createUserClaimDto.UserId = userId;
            var claimCommand = _mapper.Map<CreateClaimCommand>(createUserClaimDto);
            await Mediator.Send(claimCommand);
            return Ok();
        }

        [HttpPut("{userId:Guid}")]
        [Authorize(Policy.Management)]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto, Guid userId)
        {
            updateUserDto.UserId = userId;
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            await Mediator.Send(command);
            if (updateUserDto.HasAccount)
            {
                var identityCommand = new UpdateAspNetUserCommand { UserId = userId };
                await Mediator.Send(identityCommand);
            }
            return NoContent();
        }

        [HttpDelete("{userId:Guid}")]
        [Authorize(Policy.Management)]
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
        [Authorize(Policy.Management)]
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

        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{userId:Guid}/Claims/{id:int}")]
        [Authorize(Policy.Admin)]
        public async Task<IActionResult> DeleteClaim(Guid userId, int id)
        {
            var claimCommand = new DeleteClaimCommand { UserId = userId, Id = id};
            await Mediator.Send(claimCommand);
            return NoContent();
        }

    }
}
