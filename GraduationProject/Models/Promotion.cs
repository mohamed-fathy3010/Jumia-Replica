using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduation_project
{
    public class Promotion
    {
       
        public int ID { get; set; }
        [Required]
        public string ReasonforDiscounts { get; set; }
       
        [ForeignKey("SellerInfo")]
        public string SellerID { get; set; }
        //constraint for percentage
        public float DiscountValue { get; set; }
        public SellerInfo SellerInfo { get; set; }
        public List<Product> Products { get; set; }
    }
}
