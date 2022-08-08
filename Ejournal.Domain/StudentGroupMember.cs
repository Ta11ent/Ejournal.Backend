using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class StudentGroupMember
    {
        public Guid StudentGroupMemberId { get; set; }
        public bool Active { get; set; }

        public Guid StudentGroupId { get; set; }
        public StudentGroup StudentGroup { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<RatingLog> RaitingLogs { get; set; }
    }
}
