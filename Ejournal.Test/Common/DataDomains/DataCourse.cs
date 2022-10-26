using Ejournal.Domain;
using System;

namespace Ejournal.Test.Common.DataDomains
{
    internal class DataCourse : IDomain<Course>
    {
        public Guid Id { get; }
        internal DataCourse(Guid Id) => this.Id = Id;
        public Course GetData()
        {
            return new Course
            {
                CourseId = Id,
                Name = "Test Name " + Id.ToString().Substring(0, 5),
                Active = true
            };
        }
    }
}