using MediatR;
using System;

namespace Ejournal.Application.Application.Command.ScheduleDay_s.UpdateScheduleDate
{
    public class UpdateSchduleDayCommand : IRequest
    {
        public Guid ScheduleId { get; set; }
        public DayOfWeek Day { get; set; }
        public bool Active {get;set;}
    }
}
