using System;

namespace Ejournal.Domain
{
    public class RatingLog
    { 
        public Guid RaitingLogId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid MarkId { get; set; }
        public Mark Mark { get; set; }

        public Guid? StudentGroupMemberId { get; set; }
        public StudentGroupMember StudentGroupMember { get; set; }

        public Guid? DepartmentMemberId { get; set; }
        public DepartmentMember DepartmentMember { get; set; }

    }
}
