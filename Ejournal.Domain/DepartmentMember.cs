﻿using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class DepartmentMember
    {
        public Guid DepartmentMemberId { get; set; }
        public bool Active { get; set; }

        //Department
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        //Professor - User
        public Guid ProfessorId { get; set; } //only id because user data located on  another context
        public User Professor { get; set; }

        //ScheduleSubject
        public IEnumerable<ScheduleSubject> ScheduleSubjects { get; set; }

        //RairingLog
        public IEnumerable<RatingLog> RaitingLogs { get; set; }
    }
}
