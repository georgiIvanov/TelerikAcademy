using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMDatabase.Data;
using ATM.Model;
using System.Data.Entity;
using ATMDatabase.Data.Migrations;
using System.Transactions;

namespace ATMDatabase
{
    class Program
    {
        public static void Main()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ATMContext, Configuration>());

            // Uncomment the seed method in Configuration to populate.
            ATMActions.ShowCards();

            int pin = 2222;
            int cardNumber = 1222222222;
            decimal moneyToWithdraw = 300m;

            using (ATMContext db = new ATMContext())
            {
                if (ATMActions.WithdrawMoney(pin, cardNumber, moneyToWithdraw, db))
                {
                    Console.WriteLine("Money withdrawn");
                }
                else
                {
                    Console.WriteLine("Money withdrawn");
                }
            }


            Console.WriteLine("\nNew cards: ");
            ATMActions.ShowCards();

        }

        
    }
}
