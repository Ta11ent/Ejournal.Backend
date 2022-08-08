using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class Part
    {
        public Guid PartId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<CurriculumPart> CurriculumParts { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }

    }
}
