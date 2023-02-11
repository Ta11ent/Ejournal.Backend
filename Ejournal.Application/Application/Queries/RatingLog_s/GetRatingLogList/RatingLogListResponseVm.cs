using Ejournal.Application.Common.Helpers.Responses;
using Ejournal.Application.Interfaces;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogList
{
    public class RatingLogListResponseVm : PageResponse<List<RatingLogLookupDto>>
    {
        public RatingLogListResponseVm(List<RatingLogLookupDto> data, IPaginationParams parametrs, int count)
            : base(data, parametrs, count) { }
    }
}
