using Ejournal.Persistence;
using Ejournal.Test.Common.DataDomains;
using System;

namespace Ejournal.Test.Common.Factories
{
    public class DepartmentContextFactory : ContextFactory
    {
        public override async void FillContext(EjournalDbContext context)
        {
            DataDepartment department1 = new(IdForDelete);
            department1.Create();

            DataDepartment department2 = new(IdForUpdate);
            department2.Create();

            DataDepartment department3 = new(Guid.NewGuid());
            department3.Active = false;
            department3.Create();

            await context.Departments.AddRangeAsync(
                department1.Data,
                department2.Data,
                department3.Data
                );

            await context.SaveChangesAsync();
        }
    }
}
