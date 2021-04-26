namespace PCHut_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 150),
                        BranchManager_BranchManagerId = c.Int(),
                    })
                .PrimaryKey(t => t.BranchId)
                .ForeignKey("dbo.BranchManagers", t => t.BranchManager_BranchManagerId)
                .Index(t => t.BranchManager_BranchManagerId);
            
            CreateTable(
                "dbo.BranchManagers",
                c => new
                    {
                        BranchManagerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchManagerId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        BranchManagerId = c.Int(nullable: false),
                        AddedSubTotal = c.Double(nullable: false),
                        DiscountId = c.Int(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.BranchManagers", t => t.BranchManagerId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Discounts", t => t.DiscountId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.BranchManagerId)
                .Index(t => t.DiscountId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                        AddressDivision = c.String(nullable: false, maxLength: 50),
                        AddressDetails = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.SalesRecords",
                c => new
                    {
                        SalesRecordId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        DeliveryStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesRecordId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 150),
                        BrandId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Details = c.String(nullable: false),
                        Special = c.String(nullable: false),
                        Warranty = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Image = c.String(),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.BrandId)
                .Index(t => t.CategoryId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Vendor_name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Percentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountId);
            
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        CredentialId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CredentialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "DiscountId", "dbo.Discounts");
            DropForeignKey("dbo.SalesRecords", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Products", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.SalesRecords", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "BranchManagerId", "dbo.BranchManagers");
            DropForeignKey("dbo.Invoices", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Branches", "BranchManager_BranchManagerId", "dbo.BranchManagers");
            DropIndex("dbo.Products", new[] { "BranchId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.SalesRecords", new[] { "ProductId" });
            DropIndex("dbo.SalesRecords", new[] { "CustomerId" });
            DropIndex("dbo.Invoices", new[] { "BranchId" });
            DropIndex("dbo.Invoices", new[] { "DiscountId" });
            DropIndex("dbo.Invoices", new[] { "BranchManagerId" });
            DropIndex("dbo.Invoices", new[] { "CustomerId" });
            DropIndex("dbo.Branches", new[] { "BranchManager_BranchManagerId" });
            DropTable("dbo.Credentials");
            DropTable("dbo.Discounts");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
            DropTable("dbo.Products");
            DropTable("dbo.SalesRecords");
            DropTable("dbo.Customers");
            DropTable("dbo.Invoices");
            DropTable("dbo.BranchManagers");
            DropTable("dbo.Branches");
            DropTable("dbo.Admins");
        }
    }
}
