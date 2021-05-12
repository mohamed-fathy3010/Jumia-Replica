﻿using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduation_project
{
    public class Product
    {
        
        public int ID { get; set; }

        [Required]
        [MaxLe­ngt­h(50)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Price")]
        [Column("money")]
        public decimal Cost { get; set; }

        [Required]

        //public byte[] Image { get; set; }
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        //forigen key
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [ForeignKey("Promotion")]
        public int? PromotionsID { get; set; }

        //Navigation
        public Category Category { get; set; }
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
        public List<InventoryProducts> InventoryProducts { get; set; } = new List<InventoryProducts>();
        public Promotion Promotion { get; set; }
        public List<CustomerProduct> CustomerProducts { get; set; } = new List<CustomerProduct>();




    }
}
