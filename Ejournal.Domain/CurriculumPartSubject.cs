using System;

namespace Ejournal.Domain
{
    public class CurriculumPartSubject
    {
        public Guid CurriculumPartSubjectId { get; set; }
        public int Time { get; set; }

        //CurriculumPart
        public Guid CurriculumPartId { get; set; }
        public CurriculumPart CurriculumPart { get; set; }

        //Subject
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
