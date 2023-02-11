using Ejournal.Application.Common.Helpers.Responses;
using Ejournal.Application.Interfaces;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.Mark_s.GetMarkList
{
    public class MarkListResponseVm : PageResponse<List<MarkLookupDto>>
    {
        public MarkListResponseVm(List<MarkLookupDto> data, IPaginationParams parametrs, int count)
            :base(data, parametrs, count) { }
    }
}
