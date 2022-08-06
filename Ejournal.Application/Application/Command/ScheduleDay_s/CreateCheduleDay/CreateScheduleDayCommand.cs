using MediatR;
using System;


namespace Ejournal.Application.Application.Command.ScheduleDay_s.CreateCheduleDate
{
    public class CreateScheduleDayCommand : IRequest<int>
    {
        public Guid ScheduleId { get; set; }
        public DayOfWeek Day { get; set; }
    }
}
