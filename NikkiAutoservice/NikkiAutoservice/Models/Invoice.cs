using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NikkiAutoservice.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }        
        public Nullable<int> CustomerID { get; set; }        
        public Nullable<int> PaymentMethodsID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

        [ForeignKey("CustomerID")]        
        public virtual Customer Customer { get; set; }

        [ForeignKey("PaymentMethodsID")]        
        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}