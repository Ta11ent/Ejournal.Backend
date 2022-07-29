using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Helpers.Responses;
using Ejournal.Application.Interfaces;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList
{
    public class DepartmentMemberListResponseVm : PageResponse<List<DepartmentMemberLookupDto>>
    {
        public DepartmentMemberListResponseVm(List<DepartmentMemberLookupDto> data, IPaginationParams parametrs) 
            : base(data, parametrs) { }
    }
}
