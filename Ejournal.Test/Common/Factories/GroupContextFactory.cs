using Ejournal.Persistence;
using Ejournal.Test.Common.DataDomains;
using System;

namespace Ejournal.Test.Common.Factories
{
    public class GroupContextFactory : ContextFactory
    {
        public async override void FillContext(EjournalDbContext context)
        {
            DataGroup group1 = new(IdForDelete);
            DataGroup group2 = new(IdForUpdate);
            DataGroup group3 = new(Guid.NewGuid());

            await context.StudentGroups.AddRangeAsync(
                group1.Data,
                group2.Data,
                group3.Data
                );

            await context.SaveChangesAsync();
        }
    }
}
