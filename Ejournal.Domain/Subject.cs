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

        //Department
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        //CurriculumPartSubject
        public IEnumerable<CurriculumPartSubject> CurriculumPartSubjects { get; set; }

        //ScheduleSubject
        public IEnumerable<ScheduleSubject> ScheduleSubjects { get; set; }

        //RaitingLog
        public IEnumerable<RatingLog> RaitingLogs { get; set; }

        //HomeWork
        public IEnumerable<HomeWork> HomeWorks { get; set; }
    }
}
