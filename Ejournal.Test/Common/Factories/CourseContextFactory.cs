using Ejournal.Persistence;
using Ejournal.Test.Common.DataDomains;
using System;

namespace Ejournal.Test.Common.Factories
{
    public class CourseContextFactory : ContextFactory
    {
        public override async void FillContext(EjournalDbContext context)
        {
            DataCourse course1 = new(IdForDelete);
            DataCourse course2 = new(IdForUpdate);
            await context.Courses.AddRangeAsync(
                course1.Data,
                course2.Data
                );

            await context.SaveChangesAsync();
        }
    }
}