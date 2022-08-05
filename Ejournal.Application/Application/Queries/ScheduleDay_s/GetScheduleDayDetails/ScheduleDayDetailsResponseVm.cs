using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Application.Queries.ScheduleDay_s.GetScheduleDayDetails
{
    public class ScheduleDayDetailsResponseVm : Response<ScheduleDayDetailsDto>
    {
        public ScheduleDayDetailsResponseVm(ScheduleDayDetailsDto data)
            : base(data) { }
    }
}
