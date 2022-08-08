using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class DepartmentMember
    {
        public Guid DepartmentMemberId { get; set; }
        public bool Active { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public Guid UserId { get; set; } //only id because user data located on  another context
        public User User { get; set; }

        public IEnumerable<ScheduleSubject> ScheduleSubjects { get; set; }
        public IEnumerable<RatingLog> RaitingLogs { get; set; }
    }
}
