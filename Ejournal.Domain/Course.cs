using System;


namespace Ejournal.Domain
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
