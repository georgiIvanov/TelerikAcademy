namespace CodeJewels.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodeJewels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        AuthorEmail = c.String(),
                        Rating = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        JewelCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JewelCategories", t => t.JewelCategory_Id)
                .Index(t => t.JewelCategory_Id);
            
            CreateTable(
                "dbo.JewelCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CodeJewels", new[] { "JewelCategory_Id" });
            DropForeignKey("dbo.CodeJewels", "JewelCategory_Id", "dbo.JewelCategories");
            DropTable("dbo.JewelCategories");
            DropTable("dbo.CodeJewels");
        }
    }
}
