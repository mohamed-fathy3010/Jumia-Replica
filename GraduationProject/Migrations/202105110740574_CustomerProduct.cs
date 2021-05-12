namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerProducts",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProductID, t.CustomerID })
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.CustomerProducts", "CustomerID", "dbo.Customers");
            DropIndex("dbo.CustomerProducts", new[] { "CustomerID" });
            DropIndex("dbo.CustomerProducts", new[] { "ProductID" });
            DropTable("dbo.CustomerProducts");
        }
    }
}
