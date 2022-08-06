using MediatR;
using System;

namespace Ejournal.Application.Application.Command.ScheduleSubject_s.CreateScheduleSubject
{
    public class CreateScheduleSubjectCommand : IRequest<Guid>
    {
        public int Order { get; set; }
        public bool Active { get; set; }
        public Guid ScheduleId { get; set; }
        public DayOfWeek Day { get; set; }
        public Guid SubjectId { get; set; }
        public Guid? DepartmentMemberId { get; set; }
    }
}
