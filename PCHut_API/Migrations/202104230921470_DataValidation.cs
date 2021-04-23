namespace PCHut_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Admins", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Phone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Branch_Manager", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Branch_Manager", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Branch_Manager", "Phone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Branches", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Branches", "Address", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Customers", "Address_division", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Address_details", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Products", "Product_name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Products", "Details", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Special", c => c.String(nullable: false));
            AlterColumn("dbo.Brands", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Brands", "Vendor_name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Discounts", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Credentials", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Credentials", "Password", c => c.String());
            AlterColumn("dbo.Discounts", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Brands", "Vendor_name", c => c.String());
            AlterColumn("dbo.Brands", "Name", c => c.String());
            AlterColumn("dbo.Products", "Special", c => c.String());
            AlterColumn("dbo.Products", "Details", c => c.String());
            AlterColumn("dbo.Products", "Product_name", c => c.String());
            AlterColumn("dbo.Customers", "Address_details", c => c.String());
            AlterColumn("dbo.Customers", "Address_division", c => c.String());
            AlterColumn("dbo.Customers", "Phone", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            AlterColumn("dbo.Branches", "Address", c => c.String());
            AlterColumn("dbo.Branches", "Name", c => c.String());
            AlterColumn("dbo.Branch_Manager", "Phone", c => c.String());
            AlterColumn("dbo.Branch_Manager", "Email", c => c.String());
            AlterColumn("dbo.Branch_Manager", "Name", c => c.String());
            AlterColumn("dbo.Admins", "Phone", c => c.String());
            AlterColumn("dbo.Admins", "Email", c => c.String());
            AlterColumn("dbo.Admins", "Name", c => c.String());
        }
    }
}
