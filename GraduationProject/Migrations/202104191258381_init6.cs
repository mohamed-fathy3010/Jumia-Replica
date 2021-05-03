namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Address", c => c.String(maxLength: 15));
            AlterColumn("dbo.Customers", "City", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
