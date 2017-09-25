using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NikkiAutoservice.Models
{
    public class ReplacementPart
    {
        [Key]
        public int ReplacementPartID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}