using Ejournal.Persistence;
using Ejournal.Test.Common.DataDomain;
using Microsoft.EntityFrameworkCore;
using System;


namespace Ejournal.Test.Common
{
    internal class ContextFactory
    {
        internal static Guid IdForDelete = Guid.NewGuid();
        internal static Guid IdForUpdate = Guid.NewGuid();

        public static EjournalDbContext Create()
        {
            var options = new DbContextOptionsBuilder<EjournalDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new EjournalDbContext(options);
            context.Database.EnsureCreated();

            //Course
            var Course = new DataCourse();
            context.Courses.AddRange(
                    Course.GetCourse(Guid.Parse("0FC0E16A-5C13-465B-9362-6C63A4B35688")),
                    Course.GetCourse(Guid.Parse("F0580A10-BC8B-4C2D-83CA-18732B01DBA5"))
                );
            context.SaveChanges();
            return context;
        } 

        public static void Destroy(EjournalDbContext context)
        {
            context.Database.EnsureCreated();
            context.Dispose();
        }

    }
}
