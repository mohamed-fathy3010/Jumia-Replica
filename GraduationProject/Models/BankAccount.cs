using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraduationProject.Models
{
    public class BankAccount
    {
        [ForeignKey("SellerInfo")]
        [Key]
        public string ID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(256)]
        public string BankName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(256)]
        public string BranchName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(29, ErrorMessage = "IBAN Must be 29 characters", MinimumLength = 29)]
        [RegularExpression(@"^EG[0-9]{27}$")]
        public string  IBAN { get; set; }
        public SellerInfo SellerInfo { get; set; }

    }
}
