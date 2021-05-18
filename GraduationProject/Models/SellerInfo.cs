using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraduationProject.Models
{
    public class SellerInfo
    {
        [ForeignKey("ApplicationUser")]
        [Key]
        public string ID { get; set; }
        [Required(ErrorMessage ="thisfield is required")]
        [StringLength(14, ErrorMessage = "NAtional ID Must be 14 characters", MinimumLength = 14)]
        public string NationalID { get; set; }
        
        public string CompanyRegistration { get; set; }
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ExpiredDate { get; set; }
        
        public string FrontImage { get; set; }
       
        public string BackImage { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(256)]
        public string BusinessName { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Inventory Inventory { get; set; }



    }
}
