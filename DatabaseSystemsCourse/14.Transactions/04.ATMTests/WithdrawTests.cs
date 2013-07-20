using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATMDatabase.Data;
using ATMDatabase.Data.Migrations;
using ATM.Model;
using ATMDatabase;
using System.Data.Entity;

namespace _04.ATMTests
{
    [TestClass]
    public class WithdrawTests
    {
        [TestMethod]
        public void WithdrawTo0()
        {
            Database.SetInitializer(
                new DropCreateDatabaseAlways<ATMContext>());

            decimal money = 1000;
            int number = 1111111111;
            int cardPin = 1111;

            using (var db = new ATMContext())
            {
                db.CardAccounts.Add(new CardAccount() { CardCash = money, CardNumber = number, CardPIN = cardPin });
                db.SaveChanges();

                ATMActions.WithdrawMoney(cardPin, number, money, db);
                db.SaveChanges();

                var actual = (from c in db.CardAccounts
                                select c).First();

                Assert.AreEqual(0, actual.CardCash);
                db.Dispose();
            }
        }

        [TestMethod]
        public void CheckRecordNumber()
        {
            Database.SetInitializer(
                new DropCreateDatabaseAlways<ATMContext>());

            decimal money = 2000;
            decimal toWithdraw = 1000;
            int number = 1111111111;
            int cardPin = 1111;

            using (var db = new ATMContext())
            {
                db.CardAccounts.Add(new CardAccount() 
                { CardCash = money, CardNumber = number, CardPIN = cardPin });

                db.SaveChanges();

                ATMActions.WithdrawMoney(cardPin, number, toWithdraw, db);
                db.SaveChanges();

                var actual = (from c in db.TransactionsHistory
                              select c).First();

                Assert.AreEqual(number, actual.CardNumber);
                db.Dispose();
            }
        }

        [TestMethod]
        public void CheckRecordAmount()
        {
            Database.SetInitializer(
                new DropCreateDatabaseAlways<ATMContext>());

            decimal money = 2000;
            decimal toWithdraw = 1000;
            int number = 1111111111;
            int cardPin = 1111;

            using (var db = new ATMContext())
            {
                db.CardAccounts.Add(new CardAccount() { CardCash = money, CardNumber = number, CardPIN = cardPin });

                db.SaveChanges();

                ATMActions.WithdrawMoney(cardPin, number, toWithdraw, db);
                db.SaveChanges();

                var actual = (from c in db.TransactionsHistory
                              select c).First();

                Assert.AreEqual(1000, actual.Ammount);
                db.Dispose();
            }
        }
    }
}
