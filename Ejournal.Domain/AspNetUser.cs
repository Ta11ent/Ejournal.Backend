using System;

namespace Ejournal.Domain
{
    public class AspNetUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName {get;set;}
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
    }
}
