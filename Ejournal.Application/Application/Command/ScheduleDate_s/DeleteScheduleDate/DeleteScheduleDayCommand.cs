using MediatR;
using System;


namespace Ejournal.Application.Application.Command.ScheduleDate_s.DeleteScheduleDate
{
    internal class DeleteScheduleDayCommand : IRequest
    {
        internal DayOfWeek Day { get; set; }
    }
}
