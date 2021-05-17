namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcanceleddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "CanceledDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "CanceledDate");
        }
    }
}
