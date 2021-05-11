using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraduationProject.Models
{
    public class FeedBack
    {
        [Key]
        [ForeignKey("OrderDetails")]
        public int ID { set; get; }
        
        public decimal Rate {set; get;}
        [MaxLength(500)]
        public string PositiveComment { set; get; }
        [MaxLength(500)]
        public string NegativeComment { set; get; }
        public OrderDetails OrderDetails { get; set; }

    }
}
