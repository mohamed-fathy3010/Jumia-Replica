using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class ProductWithQuantityViewModel
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}