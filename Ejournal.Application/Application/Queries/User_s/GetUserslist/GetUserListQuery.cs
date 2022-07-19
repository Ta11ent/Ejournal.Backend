using MediatR;

namespace Ejournal.Application.Application.Queries.User_s.GetUserslist
{
    public class GetUserListQuery : IRequest<UserListVm>
    {
        public bool Active { get; set; }
    }
}
