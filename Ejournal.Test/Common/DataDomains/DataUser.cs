using Ejournal.Domain;
using System;


namespace Ejournal.Test.Common.DataDomains
{
    internal class DataUser : IDomain<User>
    {
        public User Data { get; private set; }
        private Guid Id { get; }
        private bool Active { get; set; }
        private bool HasAccount { get; set; }
        public DataUser(Guid id, bool active = true, bool hasAccount = false)
        {
            Id = id;
            Active = active;
            HasAccount = hasAccount;
            Data = Create();
        }

        private User Create()
        {
            return new User
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