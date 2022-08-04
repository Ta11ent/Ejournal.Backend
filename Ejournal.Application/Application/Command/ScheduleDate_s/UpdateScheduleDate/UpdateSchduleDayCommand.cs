using MediatR;
using System;

namespace Ejournal.Application.Application.Command.ScheduleDate_s.UpdateScheduleDate
{
    internal class UpdateSchduleDayCommand : IRequest
    {
        internal Guid ScheduleId { get; set; }
        internal DayOfWeek Day { get; set; }
        internal bool Active {get;set;}
    }
}
