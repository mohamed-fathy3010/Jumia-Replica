namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcoupons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Discount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            AddColumn("dbo.Orders", "CouponCode", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "CouponCode");
            AddForeignKey("dbo.Orders", "CouponCode", "dbo.Coupons", "Code");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CouponCode", "dbo.Coupons");
            DropIndex("dbo.Orders", new[] { "CouponCode" });
            DropColumn("dbo.Orders", "CouponCode");
            DropTable("dbo.Coupons");
        }
    }
}
