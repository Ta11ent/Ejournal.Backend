using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Helpers.Responses;
using System.Collections.Generic;

namespace Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationList
{
    public class SpecializationListResponseVm : PageResponse<List<SpecializationLookupDto>>
    {
        public SpecializationListResponseVm(List<SpecializationLookupDto> data, PaginationParams paginationParams)
            : base(data, paginationParams) { }
    }
}
