using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Helpers.Responses;
using Ejournal.Application.Interfaces;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.Goup_s.GetGroupList
{
    public class GroupListResponseVm : PageResponse<List<GroupLookupDto>>
    {
        public GroupListResponseVm(List<GroupLookupDto> data, IPaginationParams parametrs)
            :base(data, parametrs) { }
    }
}
