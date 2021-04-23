namespace PCHut_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerEmailValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Email", c => c.String());
        }
    }
}
