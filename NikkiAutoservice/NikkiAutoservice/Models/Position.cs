using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NikkiAutoservice.Models
{
    public class Position
    {
        [Key]
        public int PositionID { get; set; }

        [Display(Name = "Position")]
        public string Name { get; set; }
        public Nullable<decimal> Salary { get; set; }
                
        public virtual ICollection<Employee> Employees { get; set; }
    }
}