using MediatR;
using System;

namespace Ejournal.Application.Application.Command.ScheduleSubject_s.UpdateScheduleSubject
{
    public class UpdateScheduleSubjectCommand : IRequest
    {
        public Guid ScheduleId { get; set; }
        public int Day { get; set; }
        public Guid ScheduleSubjectId { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }
        public Guid SubjectId { get; set; }
        public Guid? DepartmentMemberId { get; set; }
    }
}
