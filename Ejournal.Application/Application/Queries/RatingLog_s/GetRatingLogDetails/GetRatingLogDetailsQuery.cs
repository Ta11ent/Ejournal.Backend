using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogDetails
{
    public class GetRatingLogDetailsQuery : IRequest<RatingLogDetailsReponseVm>
    {
        public Guid RatingLogId { get; set; }
    }
}
