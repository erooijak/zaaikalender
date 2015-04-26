﻿using System;

using Zk.Services;

namespace Zk.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }	
        public string FullName { get; set; }
        public string Email { get; set; }
        public AuthenticatedStatus AuthenticationStatus { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
