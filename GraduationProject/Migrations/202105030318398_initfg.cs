namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initfg : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SellerInfoes", "ExpiredDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SellerInfoes", "ExpiredDate", c => c.DateTime(nullable: false));
        }
    }
}
