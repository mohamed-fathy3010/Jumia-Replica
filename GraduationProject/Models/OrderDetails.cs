using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace graduation_project
{
   public class OrderDetails
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public float? UnitPrice { get; set; }
        
        [Required]
        public float? Discount { get; set; }
       [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime shippedDate { get; set; }
        [Required]
        public OrderDetailsStatus Status { get; set; }
        [ForeignKey("FinancialAccount")]
        public string FinancialAccountID { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public virtual FinancialAccount FinancialAccount { get; set; }
        public virtual FeedBack FeedBack { get; set; }
        public virtual Product Product { get; set; }
        public virtual Complaint Complaint { get; set; }

    }
}
