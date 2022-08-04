using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Schedule_s.UpdateSchedule
{
    public class UpdateScheduleCommand : IRequest
    {
        public Guid ScheduleId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid GroupId { get; set; }
        public Guid PartId { get; set; }
        public bool Active { get; set; }
    }
}
