using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class Curriculum
    {
        public Guid CurriculumId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        //Specialization
        public Guid SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        //Course
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        //CurriculumPart
        public IEnumerable<CurriculumPart> CurriculumParts { get; set; }
    }
}