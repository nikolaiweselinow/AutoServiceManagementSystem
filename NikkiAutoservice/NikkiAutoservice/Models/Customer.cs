using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NikkiAutoservice.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}