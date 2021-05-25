namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class birthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Date");
        }
    }
}
