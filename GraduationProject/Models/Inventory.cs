using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduation_project
{
    public class Inventory
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Street should be minimum 3 characters")]
        [DataType(DataType.Text)]
        public string Street { get; set; }
        public string BuildingNum { get; set; }
        [ForeignKey("SellerInfo")]
        public string SellerID { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string LandLineNum { get; set; }
        public virtual SellerInfo SellerInfo { get; set; }
    }
}
