using MediatR;
using System;

namespace Ejournal.Application.Application.Command.User_s.UpdateUser
{
    public class UpdateUserHasAccountFlagCommand : IRequest
    {
        public Guid UserId { get; set; }
        public bool HasAccount { get; set; }
    }
}
