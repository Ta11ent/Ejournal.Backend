using Ejournal.Domain;
using System;


namespace Ejournal.Test.Common.DataDomains
{
    internal class DataUser : IDomain<User>
    {
        public User Data { get; private set; }
        private Guid Id { get; }
        internal bool Active { get; set; }
        internal bool HasAccount { get; set; }
        public DataUser(Guid id)
        {
            Id = id;
            Active = true;
            HasAccount = false;
        }

        internal void Create()
        {
            Data = new User
            {
                UserId = Id,
                FirstName = "FirstName " + Id.ToString().Substring(0, 5),
                MiddleName = "MiddleName " + Id.ToString().Substring(0, 5),
                LastName = "LastName " + Id.ToString().Substring(0, 5),
                Gender = true,
                Birthday = DateTime.Today,
                HasAccount = HasAccount,
                Active = Active
            };
        }
    }
}