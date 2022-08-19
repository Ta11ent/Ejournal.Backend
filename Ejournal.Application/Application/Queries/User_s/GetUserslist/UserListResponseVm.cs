using Ejournal.Application.Common.Helpers.Responses;
using Ejournal.Application.Interfaces;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.User_s.GetUserslist
{
    public class UserListResponseVm : PageResponse<List<UserLookupDto>>
    {
     public UserListResponseVm(List<UserLookupDto> data, IPaginationParams parametrs)
            : base(data, parametrs) { }
    }
}
