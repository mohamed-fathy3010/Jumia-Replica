namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "OrderDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.OrderDetails", "shippedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderDetails", "shippedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderDetails", "OrderDate", c => c.DateTime(nullable: false));
        }
    }
}
