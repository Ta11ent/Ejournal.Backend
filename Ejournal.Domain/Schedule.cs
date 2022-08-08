using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class Schedule
    {
        public Guid ScheduleId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime Date { get; set; } 
        
        public Guid StudentGroupId { get; set; }
        public StudentGroup StudentGroup { get; set; }

        public Guid? PartId { get; set; }
        public Part Part { get; set; }

        public IEnumerable<ScheduleDay> ScheduleDays { get; set; }
    }
}
