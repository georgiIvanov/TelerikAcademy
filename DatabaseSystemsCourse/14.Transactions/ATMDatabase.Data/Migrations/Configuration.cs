namespace ATMDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ATM.Model;

    public sealed class Configuration : DbMigrationsConfiguration<ATMDatabase.Data.ATMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ATMDatabase.Data.ATMContext context)
        {
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

            //context.CardAccounts.AddOrUpdate(x => x.CardNumber,
            //    new CardAccount() { CardCash = 1000, CardNumber = 1234567890, CardPIN = 4444 },
            //    new CardAccount() { CardCash = 2000, CardNumber = 1111111111, CardPIN = 1111 },
            //    new CardAccount() { CardCash = 4000, CardNumber = 1222222222, CardPIN = 2222 },
            //    new CardAccount() { CardCash = 10000, CardNumber = 1333333333, CardPIN = 3333 }
            //    );
        }
    }
}
