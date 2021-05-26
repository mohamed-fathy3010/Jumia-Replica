using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class HomeViewModel
    {
        public List<Product> HotSale { get; set; }
        public List<Product> Laptops { get; set; }
        public List<Product> SmartPhones { get; set; }
    }
}