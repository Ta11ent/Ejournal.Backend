using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class ScheduleDay
    {
        public string ScheduleDayId { get; set; }
        public bool Active { get; set; }
        public int Day { get; set; }

        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public IEnumerable<ScheduleSubject> ScheduleSubjects { get; set; }

    }
}
