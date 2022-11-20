using Ejournal.Domain;
using System;

namespace Ejournal.Test.Common.DataDomains
{
    internal class DataCourse : IDomain<Course>
    {
        public Course Data { get; private set; }
        private Guid Id { get;}
        private bool Active { get; set; }
        internal DataCourse(Guid id, bool active = true)
        {
            Id = id;
            Active = active;
            Data = Create();
        }

        private Course Create()
        {
            return new Course
            {
                CourseId = Id,
                Name = "Test Name " + Id.ToString().Substring(0, 5),
                Active = Active
            };
        }
    }

}