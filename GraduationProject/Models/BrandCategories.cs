using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class BrandCategories
    {
        [Key]
        [Column(Order =0)]
        [ForeignKey("Brand")]
        public int BrandID { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public virtual Category Category { set; get; }
        public virtual Brand Brand { set; get; }

    }
}