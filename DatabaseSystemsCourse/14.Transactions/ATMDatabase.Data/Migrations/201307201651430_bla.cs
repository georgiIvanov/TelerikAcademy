namespace ATMDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bla : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        CardPIN = c.Int(nullable: false),
                        CardCash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnnecessaryProp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CardAccounts");
        }
    }
}
