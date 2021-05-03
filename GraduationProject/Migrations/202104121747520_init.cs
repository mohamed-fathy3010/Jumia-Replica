namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        BankName = c.String(nullable: false, maxLength: 256),
                        BranchName = c.String(nullable: false, maxLength: 256),
                        IBAN = c.String(nullable: false, maxLength: 29),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sellers", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        BusinessName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        SuperCatgeoryID = c.Int(nullable: false),
                        SuperCategory_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Categories", t => t.SuperCategory_CategoryID)
                .Index(t => t.SuperCategory_CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        PromotionsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Promotions", t => t.PromotionsID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.PromotionsID);
            
            CreateTable(
                "dbo.InventoryProducts",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        InventoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.InventoryID })
                .ForeignKey("dbo.Inventories", t => t.InventoryID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.InventoryID);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 20),
                        BuildingNum = c.String(),
                        SellerID = c.String(maxLength: 128),
                        LandLineNum = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sellers", t => t.SellerID)
                .Index(t => t.SellerID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UnitPrice = c.Single(nullable: false),
                        Discount = c.Single(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        shippedDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        FinancialAccountID = c.String(maxLength: 128),
                        ProductID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FinancialAccounts", t => t.FinancialAccountID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.FinancialAccountID)
                .Index(t => t.ProductID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Complaints",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderDetails", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PositiveComment = c.String(maxLength: 500),
                        NegativeComment = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderDetails", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.FinancialAccounts",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Avalaible = c.Single(nullable: false),
                        Pending = c.Single(nullable: false),
                        AdditionalFees = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sellers", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Freught = c.Decimal(nullable: false, storeType: "money"),
                        Address = c.String(maxLength: 500),
                        Longtitude = c.Single(nullable: false),
                        Attitude = c.Single(nullable: false),
                        CustomerID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Gender = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 15),
                        City = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReasonforDiscounts = c.String(nullable: false),
                        SellerID = c.String(maxLength: 128),
                        DiscountValue = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sellers", t => t.SellerID)
                .Index(t => t.SellerID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SellerInfoes",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        NationalID = c.String(nullable: false, maxLength: 14),
                        CompanyRegistration = c.String(nullable: false),
                        ExpiredDate = c.DateTime(nullable: false),
                        FrontImage = c.String(nullable: false),
                        BackImage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sellers", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellerInfoes", "ID", "dbo.Sellers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Categories", "SuperCategory_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "PromotionsID", "dbo.Promotions");
            DropForeignKey("dbo.Promotions", "SellerID", "dbo.Sellers");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "ID", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "FinancialAccountID", "dbo.FinancialAccounts");
            DropForeignKey("dbo.FinancialAccounts", "ID", "dbo.Sellers");
            DropForeignKey("dbo.FeedBacks", "ID", "dbo.OrderDetails");
            DropForeignKey("dbo.Complaints", "ID", "dbo.OrderDetails");
            DropForeignKey("dbo.InventoryProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.InventoryProducts", "InventoryID", "dbo.Inventories");
            DropForeignKey("dbo.Inventories", "SellerID", "dbo.Sellers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.BankAccounts", "ID", "dbo.Sellers");
            DropForeignKey("dbo.Sellers", "ID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.SellerInfoes", new[] { "ID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Promotions", new[] { "SellerID" });
            DropIndex("dbo.Customers", new[] { "ID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.FinancialAccounts", new[] { "ID" });
            DropIndex("dbo.FeedBacks", new[] { "ID" });
            DropIndex("dbo.Complaints", new[] { "ID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "FinancialAccountID" });
            DropIndex("dbo.Inventories", new[] { "SellerID" });
            DropIndex("dbo.InventoryProducts", new[] { "InventoryID" });
            DropIndex("dbo.InventoryProducts", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "PromotionsID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Categories", new[] { "SuperCategory_CategoryID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Sellers", new[] { "ID" });
            DropIndex("dbo.BankAccounts", new[] { "ID" });
            DropTable("dbo.SellerInfoes");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Promotions");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.FinancialAccounts");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.Complaints");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Inventories");
            DropTable("dbo.InventoryProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Sellers");
            DropTable("dbo.BankAccounts");
        }
    }
}
