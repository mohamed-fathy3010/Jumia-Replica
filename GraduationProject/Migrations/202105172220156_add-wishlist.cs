namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwishlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ProductWishlists",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        wishListId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProductId, t.wishListId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Wishlists", t => t.wishListId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.wishListId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductWishlists", "wishListId", "dbo.Wishlists");
            DropForeignKey("dbo.ProductWishlists", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Wishlists", "Id", "dbo.Customers");
            DropIndex("dbo.ProductWishlists", new[] { "wishListId" });
            DropIndex("dbo.ProductWishlists", new[] { "ProductId" });
            DropIndex("dbo.Wishlists", new[] { "Id" });
            DropTable("dbo.ProductWishlists");
            DropTable("dbo.Wishlists");
        }
    }
}
