using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Model;

namespace ATMDatabase.Data
{
    public class ATMContext : DbContext
    {
        public ATMContext()
            : base("ATM")
        {

        }

        public DbSet<CardAccount> CardAccounts { get; set; }
        public DbSet<TransactionHistory> TransactionsHistory { get; set; }
    }
}
