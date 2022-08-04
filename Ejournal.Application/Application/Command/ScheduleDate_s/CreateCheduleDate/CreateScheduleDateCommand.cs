using MediatR;
using System;


namespace Ejournal.Application.Application.Command.ScheduleDate_s.CreateCheduleDate
{
    internal class CreateScheduleDateCommand : IRequest<Guid>
    {
        internal Guid ScheduleId { get; set; }
        internal DayOfWeek Day { get; set; }
    }
}
