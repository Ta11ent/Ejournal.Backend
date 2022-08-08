using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class StudentGroupMember
    {
        public Guid StudentGroupMemberId { get; set; }
        public bool Active { get; set; }

        //StudentGroup
        public Guid StudentGroupId { get; set; }
        public StudentGroup StudentGroup { get; set; }

        //User
        public Guid UserId { get; set; }
        public User User { get; set; }

        //RairingLog
        public IEnumerable<RatingLog> RaitingLogs { get; set; }
    }
}
