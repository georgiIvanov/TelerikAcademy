namespace CodeJewels.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lala : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CodeJewels", "JewelCategory_Id", "dbo.JewelCategories");
            DropIndex("dbo.CodeJewels", new[] { "JewelCategory_Id" });
            RenameColumn(table: "dbo.CodeJewels", name: "JewelCategory_Id", newName: "CategoryId");
            AlterColumn("dbo.CodeJewels", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.JewelCategories", "Category", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AddForeignKey("dbo.CodeJewels", "CategoryId", "dbo.JewelCategories", "Id", cascadeDelete: true);
            CreateIndex("dbo.CodeJewels", "CategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CodeJewels", new[] { "CategoryId" });
            DropForeignKey("dbo.CodeJewels", "CategoryId", "dbo.JewelCategories");
            AlterColumn("dbo.JewelCategories", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.CodeJewels", "Rating", c => c.Int());
            RenameColumn(table: "dbo.CodeJewels", name: "CategoryId", newName: "JewelCategory_Id");
            CreateIndex("dbo.CodeJewels", "JewelCategory_Id");
            AddForeignKey("dbo.CodeJewels", "JewelCategory_Id", "dbo.JewelCategories", "Id");
        }
    }
}
