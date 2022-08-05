using MediatR;
using System;


namespace Ejournal.Application.Application.Command.ScheduleDate_s.DeleteScheduleDate
{
    public  class DeleteScheduleDayCommand : IRequest
    {
        public DayOfWeek Day { get; set; }
    }
}
