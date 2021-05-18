using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class ProductWishlist
    {
        [Key,Column(Order=1)]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("Wishlist")]
        public string wishListId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Wishlist Wishlist { get; set; }
    }
}