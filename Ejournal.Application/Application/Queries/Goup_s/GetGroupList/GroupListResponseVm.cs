using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Helpers.Responses;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.Goup_s.GetGroupList
{
    public class GroupListResponseVm : PageResponse<List<GroupLookupDto>>
    {
        public GroupListResponseVm(List<GroupLookupDto> data, PaginationParams parametrs)
            :base(data, parametrs) { }
    }
}
