﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Default Number Of Days")]
        [Range(1,25, ErrorMessage ="Please Enter valid number")]
         public int DefaultDays { get; set; }
        [Display (Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
    }

    //public class CreateLeaveTypeVM
    //{
    //    [Required]
    //    public string Name { get; set; }
       
    //}
}

