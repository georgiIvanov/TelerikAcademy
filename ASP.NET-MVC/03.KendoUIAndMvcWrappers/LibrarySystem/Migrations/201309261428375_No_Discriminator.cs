namespace LibrarySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class No_Discriminator : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.Haha", c => new
                {
                    Fu = c.String(nullable: true, maxLength:100)
                });
        }
        
        public override void Down()
        {
            DropTable("dbo.Haha");
        }
    }
}
