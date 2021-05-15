using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GraduationProject.Models
{
   public class OrderDetails
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public float? UnitPrice { get; set; }
        
        public float? Discount { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ShippedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ConfirmedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DeliveredDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CanceledDate { get; set; }
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
