using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class CurriculumPart
    {
        public Guid CurriculumPartId { get; set; }
        public bool Active { get; set; }

        public Guid CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }

        public Guid PartId { get; set;}
        public Part Part { get; set; }

    }
}
