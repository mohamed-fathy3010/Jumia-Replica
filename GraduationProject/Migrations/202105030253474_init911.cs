namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init911 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SellerInfoes", "FrontImage", c => c.String());
            AlterColumn("dbo.SellerInfoes", "BackImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SellerInfoes", "BackImage", c => c.String(nullable: false));
            AlterColumn("dbo.SellerInfoes", "FrontImage", c => c.String(nullable: false));
        }
    }
}
