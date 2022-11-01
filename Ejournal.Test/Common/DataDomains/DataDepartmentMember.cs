using Ejournal.Domain;
using System;

namespace Ejournal.Test.Common.DataDomains
{
    internal class DataDepartmentMember : IDomain<DepartmentMember>
    {
        public DepartmentMember Data { get; private set; }
        private Guid ParentId { get; }
        private Guid Id { get; }
        internal Guid UserId { get; set; }
        internal bool Active { get; set; }
        internal DataDepartmentMember(Guid parentId, Guid id)
        {
            ParentId = parentId;
            Id = id;
            Active = true;
            UserId = Guid.NewGuid();
        }

        internal void Create()
        {
            Data = new DepartmentMember
            {
                DepartmentId = ParentId,
                DepartmentMemberId = Id,
                UserId = UserId,
                Active = Active
            };
        }
    }
}
