using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NikkiAutoservice.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        public Nullable<int> PositionID { get; set; }

        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> AppointmentDate { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        [ForeignKey("PositionID")]
        public virtual Position Position { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}