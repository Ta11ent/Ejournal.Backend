using Ejournal.Domain;
using System;

namespace Ejournal.Test.Common.DataDomains
{
    internal class DataDepartmentMember : IDomain<DepartmentMember>
    {
        public DepartmentMember Data { get; private set; }
        private Guid ParentId { get; }
        private Guid Id { get; }
        private Guid UserId { get; set; }
        private bool Active { get; set; }
        internal DataDepartmentMember(Guid parentId, Guid id, Guid? userId = null, bool active = true)
        {
            ParentId = parentId;
            Id = id;
            Active = active;
            UserId = userId ?? Guid.NewGuid();
            Data = Create();
        }

        private DepartmentMember Create()
        {
            return new DepartmentMember
            {
                DepartmentId = ParentId,
                DepartmentMemberId = Id,
                UserId = UserId,
                Active = Active
            };
        }
    }
}
