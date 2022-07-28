using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Helpers.Responses;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberList
{
    public class GroupMemberListResponseVm : PageResponse<List<GroupMemberLookupDto>>
    {
        public GroupMemberListResponseVm(List<GroupMemberLookupDto> data, PaginationParams parametrs)
            : base(data, parametrs) { }
    }
}
