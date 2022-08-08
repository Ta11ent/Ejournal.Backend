using System;

namespace Ejournal.Domain
{
    public class CurriculumPartSubject
    {
        public Guid CurriculumPartSubjectId { get; set; }
        public int Time { get; set; }

        public Guid CurriculumPartId { get; set; }
        public CurriculumPart CurriculumPart { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
