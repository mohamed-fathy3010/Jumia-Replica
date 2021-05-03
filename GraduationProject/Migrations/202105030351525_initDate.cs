namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SellerInfoes", "ExpiredDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SellerInfoes", "ExpiredDate");
        }
    }
}
