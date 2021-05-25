using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GraduationProject.Models;

namespace GraduationProject.Models { 
    public class Customer
    {

        [Key]
        [ForeignKey("ApplicationUser")]
        public string ID { get; set; }
        [Required]
        public GenderType Gender { get; set; }
        
        
        [StringLength(15,MinimumLength =6)]
       
        public string Address { get; set; }
        
        [StringLength(20)]
        public string City { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}", ApplyFormatInEditMode = true)]

        public DateTime? Date { get; set; }

        //[Column(TypeName = "datetime2")]
        //public DateTime? ShippedDate { get; set; }

        
        public virtual ApplicationUser ApplicationUser { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public virtual Wishlist Wishlist { get; set; }
    }
}
