namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_more_columns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "StockDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "ExpiredDate", c => c.DateTime());
            AddColumn("dbo.Products", "IsTaxable", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.ProductTypes", "Name", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductTypes", "Name", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "IsTaxable");
            DropColumn("dbo.Products", "ExpiredDate");
            DropColumn("dbo.Products", "StockDate");
        }
    }
}
