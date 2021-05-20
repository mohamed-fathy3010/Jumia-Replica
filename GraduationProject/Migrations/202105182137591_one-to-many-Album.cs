namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetomanyAlbum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Id", "dbo.Products");
            DropIndex("dbo.Albums", new[] { "Id" });
            DropPrimaryKey("dbo.Albums");
            AddColumn("dbo.Albums", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Albums", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Albums", "Id");
            CreateIndex("dbo.Albums", "ProductId");
            AddForeignKey("dbo.Albums", "ProductId", "dbo.Products", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "ProductId", "dbo.Products");
            DropIndex("dbo.Albums", new[] { "ProductId" });
            DropPrimaryKey("dbo.Albums");
            AlterColumn("dbo.Albums", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Albums", "ProductId");
            AddPrimaryKey("dbo.Albums", "Id");
            CreateIndex("dbo.Albums", "Id");
            AddForeignKey("dbo.Albums", "Id", "dbo.Products", "ID");
        }
    }
}
