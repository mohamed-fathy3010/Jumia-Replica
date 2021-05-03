namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SellerInfoes", "ExpiredDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SellerInfoes", "ExpiredDate", c => c.DateTime());
        }
    }
}
