using MediatR;
using System;

namespace Ejournal.Application.Application.Command.ScheduleSubject_s.DeleteScheduleSubject
{
    public class DeleteScheduleSubjectCommand : IRequest
    {
        public Guid ScheduleId { get; set; }
        public int Day { get; set; }
        public Guid ScheduleSubjectId { get; set; }
    }
}
