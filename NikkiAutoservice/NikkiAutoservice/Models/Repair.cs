using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NikkiAutoservice.Models
{
    public class Repair
    {
        [Key]
        public int RepairID { get; set; }

        [Display(Name = "Repairs")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}