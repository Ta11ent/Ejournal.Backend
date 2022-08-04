using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Schedule_s.DeleteSchedule
{
    public class DeleteScheduleComamnd : IRequest
    {
        public Guid ScheduleId { get; set; }
    }
}
