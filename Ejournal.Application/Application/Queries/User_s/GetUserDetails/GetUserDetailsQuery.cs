using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.User_s.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsResponseVm>
    {
        public Guid UserId { get; set; }
    }
}
