using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject.Models
{
    public class Inventory
    {
        [Key]
        [ForeignKey("SellerInfo")]
        public String ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Street should be minimum 3 characters")]
        [DataType(DataType.Text)]
        public string Street { get; set; }
        public string BuildingNum { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string LandLineNum { get; set; }
        public virtual SellerInfo SellerInfo { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
