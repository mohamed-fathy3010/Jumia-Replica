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



        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

    }
}