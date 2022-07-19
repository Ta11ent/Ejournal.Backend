using System;

namespace Ejournal.Domain
{
    public class RatingLog
    { 
        public Guid RaitingLogId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        //Subject
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        //MArk
        public Guid MarkId { get; set; }
        public Mark Mark { get; set; }

        //StudentGroupMember
        public Guid? StudentGroupMemberId { get; set; }
        public StudentGroupMember StudentGroupMember { get; set; }

        //DepartmentMember
        public Guid? DepartmentMemberId { get; set; }
        public DepartmentMember DepartmentMember { get; set; }

    }
}
