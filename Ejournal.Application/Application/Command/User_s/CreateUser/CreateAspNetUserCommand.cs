using MediatR;
using System;

namespace Ejournal.Application.Application.Command.User_s.CreateUser
{
    public class CreateAspNetUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
