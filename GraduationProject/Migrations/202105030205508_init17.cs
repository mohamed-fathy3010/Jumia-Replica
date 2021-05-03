namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SellerInfoes", "CompanyRegistration", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SellerInfoes", "CompanyRegistration", c => c.String(nullable: false));
        }
    }
}
