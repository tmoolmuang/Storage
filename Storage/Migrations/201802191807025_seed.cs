namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProductTypes (Name, MaxDiscountPercent) VALUES ('Chemical', 10)");
            Sql("INSERT INTO ProductTypes (Name, MaxDiscountPercent) VALUES ('Auto', 12)");
            Sql("INSERT INTO ProductTypes (Name, MaxDiscountPercent) VALUES ('Produce', 10)");
            Sql("INSERT INTO ProductTypes (Name, MaxDiscountPercent) VALUES ('Toy', 20)");
        }

        public override void Down()
        {
        }
    }
}
