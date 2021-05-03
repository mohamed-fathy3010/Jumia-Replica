using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace graduation_project
{
   public class InventoryProducts
    {
        [Key]
        [Column(Order =0)]
        [ForeignKey("Product")]
        
        public int ProductID { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Inventory")]
        public int InventoryID { get; set; }


        //navigation
        public Product Product { get; set; }
        public Inventory Inventory { get; set; }
    }
}
