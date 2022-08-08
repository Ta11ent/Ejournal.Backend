using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class Subject
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public IEnumerable<CurriculumPartSubject> CurriculumPartSubjects { get; set; }
        public IEnumerable<ScheduleSubject> ScheduleSubjects { get; set; }
        public IEnumerable<RatingLog> RaitingLogs { get; set; }
        public IEnumerable<HomeWork> HomeWorks { get; set; }
    }
}
