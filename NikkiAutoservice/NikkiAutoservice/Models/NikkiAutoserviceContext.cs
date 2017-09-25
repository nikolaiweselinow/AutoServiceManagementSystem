using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NikkiAutoservice.Models
{
    public class NikkiAutoserviceContext : DbContext
    {
           
        public NikkiAutoserviceContext() : base("name=NikkiAutoserviceContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<ReplacementPart> ReplacementParts { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<Repair> Repairs { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<UserAccount> userAccount { get; set; }
    }
}
