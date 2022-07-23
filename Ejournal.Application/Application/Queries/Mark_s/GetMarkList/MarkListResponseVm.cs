using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Helpers.Responses;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.Mark_s.GetMarkList
{
    public class MarkListResponseVm : PageResponse<List<MarkLookupDto>>
    {
        public MarkListResponseVm(List<MarkLookupDto> data, PaginationParams parametrs)
            :base(data, parametrs) { }
    }
}
