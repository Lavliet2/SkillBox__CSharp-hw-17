namespace Homework_16.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        ClientId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 128),
                        ProductCode = c.Int(nullable: false),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Clients", t => t.Email)
                .Index(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Email", "dbo.Clients");
            DropIndex("dbo.Products", new[] { "Email" });
            DropTable("dbo.Products");
            DropTable("dbo.Clients");
        }
    }
}
