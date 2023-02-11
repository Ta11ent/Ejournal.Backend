using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Helpers.Responses;
using Ejournal.Application.Interfaces;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.Part_s.GetPartList
{
    public class PartListResponseVm : PageResponse<List<PartLookupDto>>
    {
        public PartListResponseVm(List<PartLookupDto> data, IPaginationParams parametrs, int count)
            : base(data, parametrs, count) { }
    }
}
