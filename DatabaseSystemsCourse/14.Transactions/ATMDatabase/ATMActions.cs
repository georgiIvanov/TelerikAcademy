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
    public static class ATMActions
    {
        public static bool WithdrawMoney(int PIN, int cardNumber, decimal moneyToWithdraw, ATMContext db)
        {
            bool success = true;
            int cardNumberToRecord = 0;

            
            using (var scope = new TransactionScope(
                        TransactionScopeOption.RequiresNew,
                        new TransactionOptions()
                        {
                            IsolationLevel = IsolationLevel.RepeatableRead
                        }
                    ))
            {
                var card = (from c in db.CardAccounts
                            where c.CardNumber == cardNumber
                            select c).First();


                if (card == null || card.CardPIN != PIN || card.CardCash < moneyToWithdraw)
                {
                    success = false;
                }
                else
                {
                    card.CardCash -= moneyToWithdraw;
                    cardNumberToRecord = card.CardNumber;
                    scope.Complete();
                }
            }

            if (success)
            {
                RecordWithdrawal(cardNumberToRecord, moneyToWithdraw, db);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static void RecordWithdrawal(int cardNumber, decimal ammount, ATMContext db)
        {
            using (var scope = new TransactionScope(
                        TransactionScopeOption.RequiresNew,
                        new TransactionOptions()
                        {
                            IsolationLevel = IsolationLevel.RepeatableRead
                        }))
            {
                db.TransactionsHistory.Add(new TransactionHistory()
                {
                    TransactionDate = DateTime.Now,
                    Ammount = ammount,
                    CardNumber = cardNumber
                });
                scope.Complete();
            }

        }

        public static void ShowCards()
        {
            using (ATMContext db = new ATMContext())
            {
                foreach (var item in db.CardAccounts)
                {
                    Console.WriteLine("ID:{0}, Monies: {1}", item.Id, item.CardCash);
                }
            }
        }
    }
}
