using Ejournal.Domain;
using System;

namespace Ejournal.Test.Common.DataDomains
{
    internal class DataDepartment : IDomain<Department>
    {
        public Department Data { get; private set; }
        private Guid Id { get; }
        internal bool Active { get; set; }
        internal DataDepartment(Guid id)
        {
            Id = id;
            Active = true;
        }
        internal void Create()
        {
            Data = new Department
            {
                DepartmentId = Id,
                Name = "Test Name " + Id.ToString().Substring(0, 5),
                Description = "Test Description " + Id.ToString().Substring(0, 5),
                Active = Active
            };
        }
    }
}
