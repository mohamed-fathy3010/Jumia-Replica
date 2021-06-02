using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GraduationProject.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLe­ngt­h(50)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Price")]
        [Column("money")]
        public float Cost { get; set; }

        [Required]

        //public byte[] Image { get; set; }
        public string Image { get; set; }

        [Required]
        [AllowHtml]
        public string Description { get; set; }

        //forigen key
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [ForeignKey("Promotion")]
        public int? PromotionsID { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        [ForeignKey("Inventory")]
        public string InventoryId { get; set; }
        [NotMapped]
        public float OrderDetailsCost { get; set; }
        [NotMapped]
        public decimal Rate { get; set; }
        //Navigation
        public Category Category { get; set; }
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
        public virtual Inventory Inventory { get; set; } 
        public Promotion Promotion { get; set; }
        public virtual List<Album> Albums { get; set; } = new List<Album>();
        public virtual List<ProductWishlist> ProductWishlists { get; set; } = new List<ProductWishlist>();
        public virtual Brand Brand { get; set; }



    }
}
