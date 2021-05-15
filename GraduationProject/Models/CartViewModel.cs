using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class CartViewModel
    {
        public Coupon Coupon  { get; set; }
        public List<ProductWithQuantityViewModel> ProductsWithQuantity { get; set; }
        public float TotalPrice { get; set; }
        public int totalQuantity { get; set; }
    }
}