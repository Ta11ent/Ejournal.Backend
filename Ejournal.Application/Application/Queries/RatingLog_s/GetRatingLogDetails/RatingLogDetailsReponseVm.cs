using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogDetails
{
    public class RatingLogDetailsReponseVm : Response<RatingLogDetailsDto>
    {
        public RatingLogDetailsReponseVm(RatingLogDetailsDto data)
            : base(data) { }
    }
}
