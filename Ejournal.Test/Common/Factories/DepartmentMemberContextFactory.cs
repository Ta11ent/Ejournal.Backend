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
            department.Create();

            DataUser user = new(IdParent);
            user.Create();

            DataDepartmentMember departmentMr1 = new(IdParent, IdForDelete);
            departmentMr1.UserId = IdParent;
            departmentMr1.Create();

            DataDepartmentMember departmentMr2 = new(IdParent, IdForUpdate);
            departmentMr2.UserId = IdParent;
            departmentMr2.Create();

            DataDepartmentMember departmentMr3 = new(IdParent, Guid.NewGuid());
            departmentMr3.UserId = IdParent;
            departmentMr3.Active = false;
            departmentMr3.Create();

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
