using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        //DepartmentMember
        public IEnumerable<DepartmentMember> DepartmentMembers { get; set; }

        //Subjects
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
