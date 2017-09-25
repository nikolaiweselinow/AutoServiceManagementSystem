namespace NikkiAutoservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        PositionID = c.Int(),
                        Name = c.String(),
                        AppointmentDate = c.DateTime(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Positions", t => t.PositionID)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Salary = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PositionID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        RepairID = c.Int(),
                        EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .ForeignKey("dbo.Repairs", t => t.RepairID)
                .Index(t => t.RepairID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(),
                        PaymentMethodsID = c.Int(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodsID)
                .Index(t => t.CustomerID)
                .Index(t => t.PaymentMethodsID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PaymentMethodID);
            
            CreateTable(
                "dbo.Repairs",
                c => new
                    {
                        RepairID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RepairID);
            
            CreateTable(
                "dbo.ReplacementParts",
                c => new
                    {
                        ReplacementPartID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ReplacementPartID);
            
            CreateTable(
                "dbo.InvoiceServices",
                c => new
                    {
                        Invoice_InvoiceID = c.Int(nullable: false),
                        Service_ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Invoice_InvoiceID, t.Service_ServiceID })
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Service_ServiceID, cascadeDelete: true)
                .Index(t => t.Invoice_InvoiceID)
                .Index(t => t.Service_ServiceID);
            
            CreateTable(
                "dbo.ReplacementPartServices",
                c => new
                    {
                        ReplacementPart_ReplacementPartID = c.Int(nullable: false),
                        Service_ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReplacementPart_ReplacementPartID, t.Service_ServiceID })
                .ForeignKey("dbo.ReplacementParts", t => t.ReplacementPart_ReplacementPartID, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Service_ServiceID, cascadeDelete: true)
                .Index(t => t.ReplacementPart_ReplacementPartID)
                .Index(t => t.Service_ServiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReplacementPartServices", "Service_ServiceID", "dbo.Services");
            DropForeignKey("dbo.ReplacementPartServices", "ReplacementPart_ReplacementPartID", "dbo.ReplacementParts");
            DropForeignKey("dbo.Services", "RepairID", "dbo.Repairs");
            DropForeignKey("dbo.InvoiceServices", "Service_ServiceID", "dbo.Services");
            DropForeignKey("dbo.InvoiceServices", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "PaymentMethodsID", "dbo.PaymentMethods");
            DropForeignKey("dbo.Invoices", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Services", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "PositionID", "dbo.Positions");
            DropIndex("dbo.ReplacementPartServices", new[] { "Service_ServiceID" });
            DropIndex("dbo.ReplacementPartServices", new[] { "ReplacementPart_ReplacementPartID" });
            DropIndex("dbo.InvoiceServices", new[] { "Service_ServiceID" });
            DropIndex("dbo.InvoiceServices", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.Invoices", new[] { "PaymentMethodsID" });
            DropIndex("dbo.Invoices", new[] { "CustomerID" });
            DropIndex("dbo.Services", new[] { "EmployeeID" });
            DropIndex("dbo.Services", new[] { "RepairID" });
            DropIndex("dbo.Employees", new[] { "PositionID" });
            DropTable("dbo.ReplacementPartServices");
            DropTable("dbo.InvoiceServices");
            DropTable("dbo.ReplacementParts");
            DropTable("dbo.Repairs");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Customers");
            DropTable("dbo.Invoices");
            DropTable("dbo.Services");
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
        }
    }
}
