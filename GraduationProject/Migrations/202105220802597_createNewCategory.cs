namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createNewCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "SuperCategory_CategoryID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "SuperCategory_CategoryID" });
            DropIndex("dbo.Categories", "IX_SuperCatgeoryID");
            DropColumn("dbo.Categories", "SuperCatgeoryID");
           // DropColumn("dbo.Categories", "SuperCategory_CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "SuperCategory_CategoryID", c => c.Int());
            AddColumn("dbo.Categories", "SuperCatgeoryID", c => c.Int());
            CreateIndex("dbo.Categories", "SuperCategory_CategoryID");
            AddForeignKey("dbo.Categories", "SuperCategory_CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
