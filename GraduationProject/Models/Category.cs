using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [MaxLe­ngt­h(50)]
        public string Name { get; set; }
        public virtual List<BrandCategories> BrandCategories { set; get; }
        public List<Product> Products { get; set; } = new List<Product>();

        //foreign key
        //[ForeignKey("SuperCategory")]
        //public int? SuperCatgeoryID { get; set; }
        //Navigation
        //   public virtual Category SuperCategory { get; set; }


        //public List<Category> ChildCategories { get; set; } = new List<Category>();
    }
}
