using Ejournal.Domain;
using System;

namespace Ejournal.Test.Common.DataDomain
{
    public class DataCourse
    {
        public Course GetCourse(Guid id)
        {
            return new Course
            {
                CourseId = id,
                Name = "Test Name " + id.ToString().Substring(0, 5),
                Active = true
            };
        }
    }
}
