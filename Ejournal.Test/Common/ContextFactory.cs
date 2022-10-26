using Ejournal.Persistence;
using Ejournal.Test.Common.DataDomains;
using Microsoft.EntityFrameworkCore;
using System;


namespace Ejournal.Test.Common
{
    public abstract class ContextFactory
    {
        internal static Guid IdForDelete = Guid.NewGuid();
        internal static Guid IdForUpdate = Guid.NewGuid();

        protected EjournalDbContext Context;

        public static EjournalDbContext Create()
        {
            var options = new DbContextOptionsBuilder<EjournalDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new EjournalDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        public abstract EjournalDbContext GetContext();
        public static void Destroy(EjournalDbContext context)
        {
            context.Database.EnsureCreated();
            context.Dispose();
        }

    }
}
