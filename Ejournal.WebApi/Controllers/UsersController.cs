using AutoMapper;
using Ejournal.Application.Application.Command.Claim_s.CreateClaim;
using Ejournal.Application.Application.Command.User_s.CreateUser;
using Ejournal.Application.Application.Command.User_s.DeleteUser;
using Ejournal.Application.Application.Command.User_s.UpdateUser;
using Ejournal.Application.Application.Command.UserClaim_s.DeleteClaim;
using Ejournal.Application.Application.Queries.User_s.GetUserDetails;
using Ejournal.Application.Application.Queries.User_s.GetUserslist;
using Ejournal.Application.Application.Queries.UserClaim_s.GetUserClaimsList;
using Ejournal.AuthenticationManager.Helpers;
using Ejournal.WebApi.Models.User;
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
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;
        public UsersController(IMapper mapper) => _mapper = mapper;

        /// <summary>Get the list of Users</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Users
        /// </remarks>
        /// <param name="filterDto">Filter params</param>
        /// <returns>UserListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UserListResponseVm>> GetAllUsers([FromQuery] GetUserListDto filterDto)
        {
            var query = _mapper.Map<GetUserListQuery>(filterDto);
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        /// <summary>Get the list of UsersClaim</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Users/A5DC9FC3-438B-43C8-B562-09552D22E211/Claims
        /// </remarks>
        /// /// <param name="userId">UserId (Guid)</param>
        /// <param name="filterDto">Filter params</param>
        /// <returns>UserListResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/[controller]/{userId:Guid}/Claims/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy.Management)]
        public async Task<ActionResult<UserListResponseVm>> GetUserClaims([FromQuery] GetUserClaimListDto filterDto, Guid userId)
        {
            var query = _mapper.Map<GetClaimListQuery>(filterDto);
            query.UserId = userId;
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        /// <summary>Get the User by Id</summary>
        /// <remarks>
        /// Simple request:
        /// Get /Users/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="Id">UserId (Guid)</param>
        /// <returns>UserDetailsResponseVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpGet("{Id}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UserDetailsResponseVm>> Get(Guid Id)
        {
            var query = new GetUserDetailsQuery { UserId = Id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>Create a User</summary>
        /// <remarks>
        /// Simple request:
        /// Post /Users
        /// {
        ///     FirstName: "name of a User",
        ///     MiddleName "MiddleName of a User",
        ///     LastName: "LastName of a USer",
        ///     Gender: "Gender of a User",
        ///     Birthday: "date of birthd",
        ///     CreateIdentity: "flag create or not an account",
        ///     Email: "filled in if CreateIdentity = ture",
        ///     PhoneNumber: "filled in if CreateIdentity = ture",
        ///     Password: "filled in if CreateIdentity = ture"
        /// }
        /// </remarks>
        /// <param name="userDto">CreateUserDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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


        /// <summary>Create a UserAccount</summary>
        /// <remarks>
        /// Simple request:
        /// Post /Useres/A5DC9FC3-438B-43C8-B562-09552D22E211/Account
        /// {
        ///     Email: "user email",
        ///     PhoneNumber: "user phoneNUmber",
        ///     Password: "user password"
        /// }
        /// </remarks>
        /// /// <param name="userId">userId (Guid)</param>
        /// <param name="identityUserDto">identityUserDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{userId:Guid}/Accounts/")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAccount([FromBody] CreateIdentityUserDto identityUserDto, Guid userId)
        {
            var identityCommand = _mapper.Map<CreateAspNetUserCommand>(identityUserDto);
            identityCommand.Id = userId;
            await Mediator.Send(identityCommand);
            var command = new UpdateUserHasAccountFlagCommand
            {
                UserId = userId,
                HasAccount = true
            };
            await Mediator.Send(command);
            return Ok();
        }

        /// <summary>Create a UserClaims</summary>
        /// <remarks>
        /// Simple request:
        /// Post /Users/A5DC9FC3-438B-43C8-B562-09552D22E211/Claims
        /// {
        ///     ClaimType: "type of Claim",
        ///     ClaimValue: "valueof Claim"
        /// }
        /// </remarks>
        /// /// <param name="userId">userId (Guid)</param>
        /// <param name="createUserClaimDto">createUserClaimDto object</param>
        /// <returns>Returns Id (Guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPost]
        [Route("/api/v{version:apiVersion}/[controller]/{userId:Guid}/Claims/")]
        [Authorize(Policy.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UserClaim([FromBody] CreateUserClaimDto createUserClaimDto, Guid userId)
        {
            var claimCommand = _mapper.Map<CreateClaimCommand>(createUserClaimDto);
            claimCommand.UserId = userId;
            await Mediator.Send(claimCommand);
            return Ok();
        }

        /// <summary>Update the User</summary>
        /// <remarks>
        /// Simple request:
        /// Put /Users/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// {
        ///     FirstName: "name of a User",
        ///     MiddleName "MiddleName of a User",
        ///     LastName: "LastName of a USer",
        ///     Gender: "Gender of a User",
        ///     Birthday: "date of birthd",
        ///     UserActive: "state of user",
        ///     AccountActive: "state of Account",
        ///     HasAccount: "Account availability"
        ///     
        /// }
        /// </remarks>
        /// <param name="userId">UserID (Guid)</param>
        /// <param name="updateUserDto">updateUserDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpPut("{userId:Guid}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto, Guid userId)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            command.UserId = userId;
            await Mediator.Send(command);
            if (updateUserDto.HasAccount)
            {
                var identityCommand = new UpdateAspNetUserCommand { UserId = userId };
                await Mediator.Send(identityCommand);
            }
            return NoContent();
        }

        /// <summary>Delete the User</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Users/A5DC9FC3-438B-43C8-B562-09552D22E211
        /// </remarks>
        /// <param name="userId">UserId (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete("{userId:Guid}")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

        /// <summary>Delete the UserAccount</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Users/A5DC9FC3-438B-43C8-B562-09552D22E211/Accounts/
        /// </remarks>
        /// <param name="userId">UserId (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{userId:Guid}/Accounts/")]
        [Authorize(Policy.Management)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

            var claimCommand = new DeleteClaimCommand { UserId = userId };
            await Mediator.Send(claimCommand);

            return NoContent();
        }


        /// <summary>Delete the UserClaim</summary>
        /// <remarks>
        /// Simple request:
        /// Delete /Users/A5DC9FC3-438B-43C8-B562-09552D22E211/Claims/EF23D499-B69D-479C-A4D8-2B8B39871978
        /// </remarks>
        /// <param name="userId">UserId (Guid)</param>
        ///  <param name="id">ClaimId (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">NoContent</response>
        /// <response code="401">If the user unauthorized</response>
        /// <response code="403">If the user does not have the necessary permissions</response>
        [HttpDelete]
        [Route("/api/v{version:apiVersion}/[controller]/{userId:Guid}/Claims/{id:int}")]
        [Authorize(Policy.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteClaim(Guid userId, int id)
        {
            var claimCommand = new DeleteClaimCommand { UserId = userId, Id = id};
            await Mediator.Send(claimCommand);
            return NoContent();
        }

    }
}
