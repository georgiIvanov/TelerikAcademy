namespace LaptopSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<LaptopSystem.Data.LaptopsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LaptopSystem.Data.LaptopsDbContext context)
        {
            if (context.Roles.FirstOrDefault() == null)
            {
                context.Roles.AddOrUpdate(r => r.Name,
                new Role("User"),
                new Role("Admin")
            );
                //if (context.Users.FirstOrDefault() == null)
                //{
                //    context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX UX_ManufacturerName ON Manufacturers (Name)");
                //}
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
}
