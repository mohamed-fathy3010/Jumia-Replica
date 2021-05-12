using graduation_project;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class CustomerProduct
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Product")]

        public int ProductID { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Customer")]
        public string CustomerID { get; set; }

        //navigation
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}