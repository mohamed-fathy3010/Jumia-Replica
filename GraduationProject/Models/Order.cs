using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduation_project
{
   public class Order
    {   
        [Key]
        public int ID { get; set; }
        [Column(TypeName ="money")]
        public int Freught { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }

        public float Longtitude { get; set; }
        public float Attitude { get; set; }
        [NotMapped]
        public OrderStatus Status { get; set; }
        [ForeignKey("Customer")]
        public string CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        //[ForeignKey("Employee")]
        //public int EmployeeID { get; set; }
        //crete employee
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
