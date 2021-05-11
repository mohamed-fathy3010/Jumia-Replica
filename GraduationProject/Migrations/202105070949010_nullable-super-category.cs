namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablesupercategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "SuperCatgeoryID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "SuperCatgeoryID", c => c.Int(nullable: false));
        }
    }
}
