using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public bool Active { get; set; }
        public IEnumerable<DepartmentMember> DepartmentMembers { get; set; }
        public IEnumerable<StudentGroupMember> GroupMembers { get; set; }
    }
}
