using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Helpers.Responses;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList
{
    public class DepartmentMemberListResponseVm : PageResponse<List<DepartmentMemberLookupDto>>
    {
        public DepartmentMemberListResponseVm(List<DepartmentMemberLookupDto> data, PaginationParams parametrs) 
            : base(data, parametrs) { }
       // public List<DepartmentMemberLookupDto> DepartmentMembers { get; set; }
    }
}
