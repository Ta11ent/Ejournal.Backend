using Ejournal.Persistence;
using Ejournal.Test.Common.DataDomains;
using System;

namespace Ejournal.Test.Common.Factories
{
    public class DepartmentMemberContextFactory : ContextFactory
    {
        public override async void FillContext(EjournalDbContext context)
        {
            DataDepartment department = new(IdParent);

            DataUser user = new(IdUser);

            DataDepartmentMember departmentMr1 = new(IdParent, IdForDelete, IdUser);
            DataDepartmentMember departmentMr2 = new(IdParent, IdForUpdate, IdUser);
            DataDepartmentMember departmentMr3 = new(IdParent, Guid.NewGuid(), IdUser, false);

            await context.Departments.AddRangeAsync(department.Data);
            await context.Users.AddRangeAsync(user.Data);
            await context.DepartmentMembers.AddRangeAsync(
                departmentMr1.Data,
                departmentMr2.Data,
                departmentMr3.Data
                );

            await context.SaveChangesAsync();
        }
    }
}
