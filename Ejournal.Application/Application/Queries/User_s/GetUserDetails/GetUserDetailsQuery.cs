using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.User_s.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
