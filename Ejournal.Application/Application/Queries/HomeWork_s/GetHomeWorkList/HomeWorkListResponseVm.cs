using Ejournal.Application.Common.Helpers.Responses;
using Ejournal.Application.Interfaces;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkList
{
    public class HomeWorkListResponseVm : PageResponse<List<HomeWorkLookupDto>>
    {
        public HomeWorkListResponseVm(List<HomeWorkLookupDto> data, IPaginationParams parametrs, int count)
            : base(data, parametrs, count) { }
    }
}
