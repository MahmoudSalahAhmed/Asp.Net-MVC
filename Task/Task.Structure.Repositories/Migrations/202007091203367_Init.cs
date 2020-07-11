namespace Task.Structure.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Orman.Admin",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Orman.Client",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Orman.Group", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "Orman.Group",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Orman.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Orman.Client", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
            CreateTable(
                "Orman.OrderItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Orman.Item", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("Orman.Order", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "Orman.Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Orman.OrderItem", "OrderID", "Orman.Order");
            DropForeignKey("Orman.OrderItem", "ItemID", "Orman.Item");
            DropForeignKey("Orman.Order", "ClientID", "Orman.Client");
            DropForeignKey("Orman.Client", "GroupID", "Orman.Group");
            DropIndex("Orman.OrderItem", new[] { "ItemID" });
            DropIndex("Orman.OrderItem", new[] { "OrderID" });
            DropIndex("Orman.Order", new[] { "ClientID" });
            DropIndex("Orman.Client", new[] { "GroupID" });
            DropTable("Orman.Item");
            DropTable("Orman.OrderItem");
            DropTable("Orman.Order");
            DropTable("Orman.Group");
            DropTable("Orman.Client");
            DropTable("Orman.Admin");
        }
    }
}
