namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropdiscountvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "Discount", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "Discount", c => c.Single(nullable: false));
        }
    }
}
