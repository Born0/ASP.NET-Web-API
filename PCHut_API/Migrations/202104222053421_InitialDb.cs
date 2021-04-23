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
                        Admin_id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Admin_id);
            
            CreateTable(
                "dbo.Branch_Manager",
                c => new
                    {
                        Branch_manager_id = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Branch_manager_id)
                .ForeignKey("dbo.Branches", t => t.Branch_manager_id)
                .Index(t => t.Branch_manager_id);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Branch_id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Branch_id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Invoice_id = c.Int(nullable: false, identity: true),
                        Customer_id = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Branch_manager_id = c.Int(nullable: false),
                        Added_sub_total = c.Double(nullable: false),
                        Discount_id = c.Int(nullable: false),
                        Total_amount = c.Double(nullable: false),
                        Branch_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Invoice_id)
                .ForeignKey("dbo.Branches", t => t.Branch_id, cascadeDelete: true)
                .ForeignKey("dbo.Branch_Manager", t => t.Branch_manager_id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_id, cascadeDelete: true)
                .ForeignKey("dbo.Discounts", t => t.Discount_id, cascadeDelete: true)
                .Index(t => t.Customer_id)
                .Index(t => t.Branch_manager_id)
                .Index(t => t.Discount_id)
                .Index(t => t.Branch_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Customer_id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address_division = c.String(),
                        Address_details = c.String(),
                    })
                .PrimaryKey(t => t.Customer_id);
            
            CreateTable(
                "dbo.Sales_Record",
                c => new
                    {
                        Sales_id = c.Int(nullable: false, identity: true),
                        Customer_id = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Product_id = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Sub_total = c.Double(nullable: false),
                        Delivery_status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sales_id)
                .ForeignKey("dbo.Customers", t => t.Customer_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.Customer_id)
                .Index(t => t.Product_id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Product_id = c.Int(nullable: false, identity: true),
                        Product_name = c.String(),
                        Brand_id = c.Int(nullable: false),
                        Category_id = c.Int(nullable: false),
                        Details = c.String(),
                        Special = c.String(),
                        Warranty = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Image = c.String(),
                        Branch_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Product_id)
                .ForeignKey("dbo.Branches", t => t.Branch_id, cascadeDelete: true)
                .ForeignKey("dbo.Brands", t => t.Brand_id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_id, cascadeDelete: true)
                .Index(t => t.Brand_id)
                .Index(t => t.Category_id)
                .Index(t => t.Branch_id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Brand_id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Vendor_name = c.String(),
                    })
                .PrimaryKey(t => t.Brand_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Category_id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Category_id);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Discount_id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Percentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Discount_id);
            
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        Credential_id = c.Int(nullable: false, identity: true),
                        User_id = c.Int(nullable: false),
                        Password = c.String(),
                        User_type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Credential_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branch_Manager", "Branch_manager_id", "dbo.Branches");
            DropForeignKey("dbo.Invoices", "Discount_id", "dbo.Discounts");
            DropForeignKey("dbo.Sales_Record", "Product_id", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.Products", "Brand_id", "dbo.Brands");
            DropForeignKey("dbo.Products", "Branch_id", "dbo.Branches");
            DropForeignKey("dbo.Sales_Record", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "Branch_manager_id", "dbo.Branch_Manager");
            DropForeignKey("dbo.Invoices", "Branch_id", "dbo.Branches");
            DropIndex("dbo.Products", new[] { "Branch_id" });
            DropIndex("dbo.Products", new[] { "Category_id" });
            DropIndex("dbo.Products", new[] { "Brand_id" });
            DropIndex("dbo.Sales_Record", new[] { "Product_id" });
            DropIndex("dbo.Sales_Record", new[] { "Customer_id" });
            DropIndex("dbo.Invoices", new[] { "Branch_id" });
            DropIndex("dbo.Invoices", new[] { "Discount_id" });
            DropIndex("dbo.Invoices", new[] { "Branch_manager_id" });
            DropIndex("dbo.Invoices", new[] { "Customer_id" });
            DropIndex("dbo.Branch_Manager", new[] { "Branch_manager_id" });
            DropTable("dbo.Credentials");
            DropTable("dbo.Discounts");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
            DropTable("dbo.Products");
            DropTable("dbo.Sales_Record");
            DropTable("dbo.Customers");
            DropTable("dbo.Invoices");
            DropTable("dbo.Branches");
            DropTable("dbo.Branch_Manager");
            DropTable("dbo.Admins");
        }
    }
}
