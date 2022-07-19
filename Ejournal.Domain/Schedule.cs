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
        
        //StudentGroup
        public Guid StudentGroupId { get; set; }
        public StudentGroup StudentGroup { get; set; }

        //Part
        public Guid? PartId { get; set; }
        public Part Part { get; set; }

        //ScheduleDays
        public IEnumerable<ScheduleDay> ScheduleDays { get; set; }
    }
}
