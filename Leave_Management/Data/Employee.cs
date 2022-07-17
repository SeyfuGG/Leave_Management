using Microsoft.AspNetCore.Identity;
using System;

namespace Leave_Management.Data
{
    public class Employee: IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int TaxId { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime DateofJoined { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
