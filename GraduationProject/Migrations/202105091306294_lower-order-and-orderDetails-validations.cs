namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lowerorderandorderDetailsvalidations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Lattitude", c => c.Single());
            AlterColumn("dbo.Products", "money", c => c.Single(nullable: false));
            AlterColumn("dbo.Orders", "Longtitude", c => c.Single());
            DropColumn("dbo.Orders", "Attitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Attitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Orders", "Longtitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "money", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "Lattitude");
            DropColumn("dbo.Orders", "Date");
        }
    }
}
