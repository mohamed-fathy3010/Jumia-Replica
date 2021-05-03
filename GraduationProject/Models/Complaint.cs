using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduation_project
{
    public class Complaint
    {
        [Key][ForeignKey("OrderDetails")]
        public int ID { get; set; }
        public Status Status { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}
