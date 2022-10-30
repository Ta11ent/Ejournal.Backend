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
            course1.Create();

            DataCourse course2 = new(IdForUpdate);
            course2.Create();

            DataCourse course3 = new(Guid.NewGuid());
            course3.Active = false;
            course3.Create();

            await context.Courses.AddRangeAsync(
                course1.Data,
                course2.Data,
                course3.Data
                );

            await context.SaveChangesAsync();
        }
    }
}