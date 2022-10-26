using Ejournal.Persistence;
using Ejournal.Test.Common.DataDomains;
using System;

namespace Ejournal.Test.Common.Factories
{
    public class CourseContextFactory : ContextFactory
    {
        public override EjournalDbContext GetContext()
        {
            DataCourse course1 = new(Guid.Parse("0FC0E16A-5C13-465B-9362-6C63A4B35688"));
            DataCourse course2 = new(Guid.Parse("F0580A10-BC8B-4C2D-83CA-18732B01DBA5"));
            Context.Courses.AddRange(
                course1.GetData(),
                course2.GetData());

            Context.SaveChanges();
            return Context;
        }
    }
}