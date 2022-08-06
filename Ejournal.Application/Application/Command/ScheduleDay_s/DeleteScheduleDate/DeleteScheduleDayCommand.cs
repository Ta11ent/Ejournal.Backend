using MediatR;
using System;


namespace Ejournal.Application.Application.Command.ScheduleDay_s.DeleteScheduleDate
{
    public  class DeleteScheduleDayCommand : IRequest
    {
        public Guid ScheduleId { get; set; }
        public DayOfWeek Day { get; set; }
    }
}
