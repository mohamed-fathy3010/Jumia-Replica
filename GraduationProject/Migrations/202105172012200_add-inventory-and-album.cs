namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinventoryandalbum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InventoryProducts", "InventoryID", "dbo.Inventories");
            DropForeignKey("dbo.InventoryProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.InventoryProducts", new[] { "ProductID" });
            DropIndex("dbo.InventoryProducts", new[] { "InventoryID" });
            DropIndex("dbo.Inventories", new[] { "SellerID" });
            DropForeignKey("dbo.Products", "InventoryId", "dbo.Inventories");
            DropPrimaryKey("dbo.Inventories");
            DropColumn("dbo.Inventories", "ID");
            RenameColumn(table: "dbo.Inventories", name: "SellerID", newName: "ID");
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Products", "InventoryId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Inventories", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Inventories", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Inventories", "ID");
            CreateIndex("dbo.Products", "InventoryId");
            CreateIndex("dbo.Inventories", "ID");
            AddForeignKey("dbo.Products", "InventoryId", "dbo.Inventories", "ID");
            DropTable("dbo.InventoryProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InventoryProducts",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        InventoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.InventoryID });
            
            DropForeignKey("dbo.Albums", "Id", "dbo.Products");
            DropForeignKey("dbo.Products", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.Inventories", new[] { "ID" });
            DropIndex("dbo.Products", new[] { "InventoryId" });
            DropIndex("dbo.Albums", new[] { "Id" });
            DropPrimaryKey("dbo.Inventories");
            AlterColumn("dbo.Inventories", "ID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Inventories", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Products", "InventoryId");
            DropTable("dbo.Albums");
            AddPrimaryKey("dbo.Inventories", "ID");
            RenameColumn(table: "dbo.Inventories", name: "ID", newName: "SellerID");
            AddColumn("dbo.Inventories", "ID", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Inventories", "SellerID");
            CreateIndex("dbo.InventoryProducts", "InventoryID");
            CreateIndex("dbo.InventoryProducts", "ProductID");
            AddForeignKey("dbo.InventoryProducts", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
            AddForeignKey("dbo.InventoryProducts", "InventoryID", "dbo.Inventories", "ID", cascadeDelete: true);
        }
    }
}
