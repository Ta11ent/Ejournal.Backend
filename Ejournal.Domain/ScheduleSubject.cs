using System;

namespace Ejournal.Domain
{
    public class ScheduleSubject
    {
        public Guid ScheduleSubjectId { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }

        //ScheduleDay
        public Guid ScheduleDayId { get; set; }
        public ScheduleDay ScheduleDay { get; set; }

        //Subject
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        //DEpartmentMember
        public Guid? DepartmentMemberId { get; set; }
        public DepartmentMember DepartmentMember { get; set; }
    }
}
