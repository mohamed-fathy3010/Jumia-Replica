using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduation_project
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [MaxLe­ngt­h(50)]
        public string Name { get; set; }
        //foreign key
        //[ForeignKey("SuperCategory")]
        public int? SuperCatgeoryID { get; set; }
        //Navigation
        public List<Product> Products { get; set; } = new List<Product>();
        public virtual Category SuperCategory { get; set; }
        public virtual List<BrandCategories> BrandCategories { set; get; }

        //public List<Category> ChildCategories { get; set; } = new List<Category>();
    }
}
