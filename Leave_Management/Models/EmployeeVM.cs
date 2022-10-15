using System;

namespace Leave_Management.Models
{
    public class EmployeeVM
    {
        //Models are an abstract of DB
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int TaxId { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime DateofJoined { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
