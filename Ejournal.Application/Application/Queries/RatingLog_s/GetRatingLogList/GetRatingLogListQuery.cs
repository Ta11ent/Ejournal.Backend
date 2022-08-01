using Ejournal.Application.Common.Helpers.Filters;
using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogList
{
    public class GetRatingLogListQuery : IRequest<RatingLogListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
    }
}
