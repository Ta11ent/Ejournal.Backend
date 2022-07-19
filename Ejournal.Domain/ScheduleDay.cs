using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class ScheduleDay
    {
        public Guid ScheduleDayId { get; set; }
        public bool Active { get; set; }
        public DayOfWeek Day { get; set; }

        //Schedule
        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        //ScheduleSubject 
        public IEnumerable<ScheduleSubject> ScheduleSubjects { get; set; }

    }
}
