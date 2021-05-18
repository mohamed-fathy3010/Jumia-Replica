using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<FeedBack> FeedBacks { get; set; }
        public List<Album> Albums { get; set; }
        public string SellerName { get; set; }
        public string BrandName { get; set; }
        public List<Product> OtherProducts { get; set; }
        public bool isWished { get; set; }
        public bool isAddedToCart { get; set; }
    }
}