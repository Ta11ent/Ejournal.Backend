using Ejournal.Domain;
using System;

namespace Ejournal.Test.Common.DataDomains
{
    internal class DataGroup : IDomain<StudentGroup>
    {
        public StudentGroup Data { get;}
        private Guid Id { get; }
        private bool Active { get; }
        internal DataGroup(Guid id, bool active = true)
        {
            Id = id;
            Active = active;
            Data = Create();
        }

        private StudentGroup Create()
        {
            return new StudentGroup
            {
                StudentGroupId = Id,
                Name = "Test Name " + Id.ToString().Substring(0, 5),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Active = Active,
                SpecializationId = Guid.NewGuid()
            };
        }
    }
}
