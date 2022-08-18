using MediatR;
using System;

namespace Ejournal.Application.Application.Command.User_s.DeleteUser
{
    public class DeleteAspNetUserCommand : IRequest
    {
        public Guid UserId { get; set; }
    }
}
