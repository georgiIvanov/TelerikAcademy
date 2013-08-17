namespace CodeJewels.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CodeJewels.DataLayer.CodeJewelsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(CodeJewels.DataLayer.CodeJewelsContext context)
        {
            context.Database.ExecuteSqlCommand("ALTER TABLE JewelCategories ADD UNIQUE (Category)"); //USE CodeJewels 

            //context.Database.ExecuteSqlCommand("ALTER TABLE Users ADD CONSTRAINT uc_Delivery UNIQUE(DeliveryAddressId)");

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
