using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}