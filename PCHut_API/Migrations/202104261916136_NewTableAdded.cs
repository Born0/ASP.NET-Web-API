namespace PCHut_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BranchId", "dbo.Branches");
            DropIndex("dbo.Products", new[] { "BranchId" });
            RenameColumn(table: "dbo.Products", name: "BranchId", newName: "Branch_BranchId");
            CreateTable(
                "dbo.DistributedProducts",
                c => new
                    {
                        DistributedProductId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistributedProductId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.BranchId);
            
            AlterColumn("dbo.Products", "Branch_BranchId", c => c.Int());
            CreateIndex("dbo.Products", "Branch_BranchId");
            AddForeignKey("dbo.Products", "Branch_BranchId", "dbo.Branches", "BranchId");
            DropColumn("dbo.Products", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "Branch_BranchId", "dbo.Branches");
            DropForeignKey("dbo.DistributedProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.DistributedProducts", "BranchId", "dbo.Branches");
            DropIndex("dbo.DistributedProducts", new[] { "BranchId" });
            DropIndex("dbo.DistributedProducts", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "Branch_BranchId" });
            AlterColumn("dbo.Products", "Branch_BranchId", c => c.Int(nullable: false));
            DropTable("dbo.DistributedProducts");
            RenameColumn(table: "dbo.Products", name: "Branch_BranchId", newName: "BranchId");
            CreateIndex("dbo.Products", "BranchId");
            AddForeignKey("dbo.Products", "BranchId", "dbo.Branches", "BranchId", cascadeDelete: true);
        }
    }
}
