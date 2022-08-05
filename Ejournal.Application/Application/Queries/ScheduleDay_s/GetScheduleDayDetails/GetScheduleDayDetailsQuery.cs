using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.ScheduleDay_s.GetScheduleDayDetails
{
    public class GetScheduleDayDetailsQuery : IRequest<ScheduleDayDetailsResponseVm>
    {
        public DayOfWeek Day { get; set; }
    }
}
