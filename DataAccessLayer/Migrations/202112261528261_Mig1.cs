namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CartItems", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Users", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropIndex("dbo.CartItems", new[] { "Cart_Id" });
            DropIndex("dbo.Users", new[] { "Cart_Id" });
            AlterColumn("dbo.Products", "UnitPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Users", "Cart_Id");
            DropTable("dbo.CartItems");
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Color = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Int(nullable: false),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Cart_Id", c => c.Int());
            AlterColumn("dbo.Products", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Users", "Cart_Id");
            CreateIndex("dbo.CartItems", "Cart_Id");
            CreateIndex("dbo.CartItems", "ProductId");
            AddForeignKey("dbo.Users", "Cart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.CartItems", "Cart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.CartItems", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
