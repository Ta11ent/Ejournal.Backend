using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Helpers.Responses;
using Ejournal.Application.Interfaces;
using System.Collections.Generic;

namespace Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationList
{
    public class SpecializationListResponseVm : PageResponse<List<SpecializationLookupDto>>
    {
        public SpecializationListResponseVm(List<SpecializationLookupDto> data, IPaginationParams paginationParams, int count)
            : base(data, paginationParams, count) { }
    }
}
