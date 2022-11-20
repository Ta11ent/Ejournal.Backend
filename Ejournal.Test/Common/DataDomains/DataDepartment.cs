using Ejournal.Domain;
using System;

namespace Ejournal.Test.Common.DataDomains
{
    internal class DataDepartment : IDomain<Department>
    {
        public Department Data { get; private set; }
        private Guid Id { get; }
        private bool Active { get; set; }
        internal DataDepartment(Guid id, bool active = true)
        {
            Id = id;
            Active = active;
            Data = Create();

        }
        private Department Create()
        {
            return new Department
            {
                DepartmentId = Id,
                Name = "Test Name " + Id.ToString().Substring(0, 5),
                Description = "Test Description " + Id.ToString().Substring(0, 5),
                Active = Active
            };
        }
    }
}
