using Ejournal.Application.Common.Helpers.Filters;
using MediatR;

namespace Ejournal.Application.Application.Queries.User_s.GetUserslist
{
    public class GetUserListQuery : IRequest<UserListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
    }
}
