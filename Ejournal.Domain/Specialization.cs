using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class Specialization
    {
        public Guid SpecializationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }

        //Curriculum
        public IEnumerable<Curriculum> Curriculums { get; set; }

        //StudentGroup
        public IEnumerable<StudentGroup> StudentGroups { get; set; }
    }
}
