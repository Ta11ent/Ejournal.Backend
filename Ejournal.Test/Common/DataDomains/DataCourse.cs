using Ejournal.Domain;
using System;

namespace Ejournal.Test.Common.DataDomains
{
    internal class DataCourse : IDomain<Course>
    {
        public Course Data { get; private set; }
        private Guid Id { get;}
        internal bool Active { get; set; }

        internal DataCourse(Guid id)
        {
            Id = id;
            Active = true;
        }
        internal void Create()
        {
            Data = new Course
            {
                CourseId = Id,
                Name = "Test Name " + Id.ToString().Substring(0, 5),
                Active = Active
            };
        }
    }

}