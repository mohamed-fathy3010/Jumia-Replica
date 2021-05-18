using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class Wishlist
    {
        [Key]
        [ForeignKey("Customer")]
        public string Id { get; set; }

        public virtual List<ProductWishlist> ProductWishlists { get; set; } = new List<ProductWishlist>();

        public virtual Customer Customer { get; set; }
    }
}