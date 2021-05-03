namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class brand : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrandCategories",
                c => new
                    {
                        BrandID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BrandID, t.CategoryID })
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.BrandID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BrandCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.BrandCategories", "BrandID", "dbo.Brands");
            DropIndex("dbo.BrandCategories", new[] { "CategoryID" });
            DropIndex("dbo.BrandCategories", new[] { "BrandID" });
            DropTable("dbo.Brands");
            DropTable("dbo.BrandCategories");
        }
    }
}
