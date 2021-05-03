namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sellerinfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sellers", "ID", "dbo.AspNetUsers");
            DropForeignKey("dbo.BankAccounts", "ID", "dbo.Sellers");
            DropForeignKey("dbo.Inventories", "SellerID", "dbo.Sellers");
            DropForeignKey("dbo.FinancialAccounts", "ID", "dbo.Sellers");
            DropForeignKey("dbo.Promotions", "SellerID", "dbo.Sellers");
            DropForeignKey("dbo.SellerInfoes", "ID", "dbo.Sellers");
            DropIndex("dbo.Sellers", new[] { "ID" });
            AddColumn("dbo.SellerInfoes", "BusinessName", c => c.String(nullable: false, maxLength: 256));
            AddForeignKey("dbo.SellerInfoes", "ID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BankAccounts", "ID", "dbo.SellerInfoes", "ID");
            AddForeignKey("dbo.Inventories", "SellerID", "dbo.SellerInfoes", "ID");
            AddForeignKey("dbo.FinancialAccounts", "ID", "dbo.SellerInfoes", "ID");
            AddForeignKey("dbo.Promotions", "SellerID", "dbo.SellerInfoes", "ID");
            DropTable("dbo.Sellers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        BusinessName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.Promotions", "SellerID", "dbo.SellerInfoes");
            DropForeignKey("dbo.FinancialAccounts", "ID", "dbo.SellerInfoes");
            DropForeignKey("dbo.Inventories", "SellerID", "dbo.SellerInfoes");
            DropForeignKey("dbo.BankAccounts", "ID", "dbo.SellerInfoes");
            DropForeignKey("dbo.SellerInfoes", "ID", "dbo.AspNetUsers");
            DropColumn("dbo.SellerInfoes", "BusinessName");
            CreateIndex("dbo.Sellers", "ID");
            AddForeignKey("dbo.SellerInfoes", "ID", "dbo.Sellers", "ID");
            AddForeignKey("dbo.Promotions", "SellerID", "dbo.Sellers", "ID");
            AddForeignKey("dbo.FinancialAccounts", "ID", "dbo.Sellers", "ID");
            AddForeignKey("dbo.Inventories", "SellerID", "dbo.Sellers", "ID");
            AddForeignKey("dbo.BankAccounts", "ID", "dbo.Sellers", "ID");
            AddForeignKey("dbo.Sellers", "ID", "dbo.AspNetUsers", "Id");
        }
    }
}
