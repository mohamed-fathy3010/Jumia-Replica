using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraduationProject.Models
{
    public class FinancialAccount
    {
        [Key]
        [ForeignKey("SellerInfo")]
        public string ID { set; get; }
        [Required]
        public float Avalaible { get; set; }
        public float Pending { get; set; }
        [Required]
        public float AdditionalFees { get; set; }
        public SellerInfo SellerInfo { get; set; }
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
