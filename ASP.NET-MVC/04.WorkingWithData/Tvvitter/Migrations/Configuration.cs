namespace Tvvitter.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Tvvitter.Data.TvvitterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Tvvitter.Data.TvvitterContext context)
        {
            if (context.Roles.FirstOrDefault() == null)
            {
                context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX UX_TagName ON Tags (Name)");

                context.Roles.AddOrUpdate(r => r.Name,
                new Role("User"),
                new Role("Admin")
            );
            }

            

            

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
