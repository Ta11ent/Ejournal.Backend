using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Application.Queries.Schedule_s.GetScheduleDetails
{
    public class ScheduleDetailsResponseVm : Response<ScheduleDetailsDto>
    {
        public ScheduleDetailsResponseVm(ScheduleDetailsDto data)
            : base(data) { }
    }
}
