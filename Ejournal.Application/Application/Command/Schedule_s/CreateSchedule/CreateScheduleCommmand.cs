using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Schedule_s.CreateSchedule
{
    public class CreateScheduleCommmand : IRequest<Guid>
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid GroupId { get; set; }
        public Guid PartId { get; set; }
    }
}
