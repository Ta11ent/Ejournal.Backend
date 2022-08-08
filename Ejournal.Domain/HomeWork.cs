using System;

namespace Ejournal.Domain
{
    public class HomeWork
    {
        public Guid HomeWorkId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Guid StudentGroupId { get; set; }
        public StudentGroup StudentGroup { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

    }
}
