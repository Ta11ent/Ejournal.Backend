using Ejournal.Domain;
using System;

namespace Ejournal.Test.Common.DataDomains
{
    internal class DataCourse : IDomain<Course>
    {
        public Course Data { get; }
        internal DataCourse(Guid Id)
        {
            Data = new Course
            {
                CourseId = Id,
                Name = "Test Name " + Id.ToString().Substring(0, 5),
                Active = true
            };
        }
    }
}