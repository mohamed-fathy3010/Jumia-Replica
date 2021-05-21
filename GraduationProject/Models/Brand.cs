using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<BrandCategories> BrandCategories { set; get; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}