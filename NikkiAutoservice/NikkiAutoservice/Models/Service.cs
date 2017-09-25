using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NikkiAutoservice.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        public Nullable<int> RepairID { get; set; }
        public Nullable<int> EmployeeID { get; set; }

        [ForeignKey("RepairID")]
        public virtual Repair Repair { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }        

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<ReplacementPart> ReplacementParts { get; set; }
    }
}