namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableproductpromotionID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "PromotionsID", "dbo.Promotions");
            DropIndex("dbo.Products", new[] { "PromotionsID" });
            AlterColumn("dbo.Products", "PromotionsID", c => c.Int());
            CreateIndex("dbo.Products", "PromotionsID");
            AddForeignKey("dbo.Products", "PromotionsID", "dbo.Promotions", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PromotionsID", "dbo.Promotions");
            DropIndex("dbo.Products", new[] { "PromotionsID" });
            AlterColumn("dbo.Products", "PromotionsID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "PromotionsID");
            AddForeignKey("dbo.Products", "PromotionsID", "dbo.Promotions", "ID", cascadeDelete: true);
        }
    }
}
