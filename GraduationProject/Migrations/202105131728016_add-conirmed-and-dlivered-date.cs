namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addconirmedanddlivereddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "ConfirmedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.OrderDetails", "DeliveredDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.OrderDetails", "ShippedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "ShippedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.OrderDetails", "DeliveredDate");
            DropColumn("dbo.OrderDetails", "ConfirmedDate");
        }
    }
}
