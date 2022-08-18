using MediatR;
using System;

namespace Ejournal.Application.Application.Command.User_s.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
    }
}
