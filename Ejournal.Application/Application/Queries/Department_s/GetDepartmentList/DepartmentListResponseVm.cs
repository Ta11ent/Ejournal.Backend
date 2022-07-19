using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Helpers.Responses;
using System.Collections.Generic;

namespace Ejournal.Application.Ejournal.Queries.Department_s.GetDepartmentList
{
    public class DepartmentListResponseVm : PageResponse<List<DepartmentLookupDto>>
    {
        public DepartmentListResponseVm(List<DepartmentLookupDto> data, PaginationParams paginationParams) 
            : base(data, paginationParams) { }
    }
}
