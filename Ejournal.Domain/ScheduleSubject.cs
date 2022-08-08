using System;

namespace Ejournal.Domain
{
    public class ScheduleSubject
    {
        public Guid ScheduleSubjectId { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }

        public string ScheduleDayId { get; set; }
        public ScheduleDay ScheduleDay { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid? DepartmentMemberId { get; set; }
        public DepartmentMember DepartmentMember { get; set; }
    }
}
