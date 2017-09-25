using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NikkiAutoservice.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodID { get; set; }
        [Display(Name = "Payment Method")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}