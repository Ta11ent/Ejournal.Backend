using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class StudentGroup
    {
        public Guid StudentGroupId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }

        public Guid SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        public IEnumerable<StudentGroupMember> StudentGoupMembers { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
        public IEnumerable<HomeWork> HomeWorks { get; set; }
    }
}
