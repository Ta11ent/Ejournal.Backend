﻿using System;

namespace Ejournal.Domain
{
    public class AspNetUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public bool Active { get; set; }
    }
}
