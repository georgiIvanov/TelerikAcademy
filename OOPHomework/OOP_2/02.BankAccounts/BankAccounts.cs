using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankAccounts
{
    class BankAccounts
    {
        static void Main(string[] args)
        {
            LoanAccount loanAcc = new LoanAccount(13.23m, 4.2m, Customer.personal, new DateTime(2013, 2, 1));
            Console.WriteLine(loanAcc.InterestOverMonths(2));
            Console.WriteLine(loanAcc.GetBalance);
            loanAcc.Deposit(4.54m);
            Console.WriteLine(loanAcc.GetBalance);

            Console.WriteLine("\n\nMortgage account: ");
            MortgageAccount mortAcc = new MortgageAccount(13.23m, 4.2m, Customer.personal, new DateTime(2013, 3, 5));
            Console.WriteLine(mortAcc.InterestOverMonths(8));
            Console.WriteLine(mortAcc.GetBalance);
            mortAcc.Deposit(55.3m);
            Console.WriteLine(mortAcc.InterestOverMonths(8));

            Console.WriteLine("\n\nDeposit account: ");
            DepositAccount deposAcc = new DepositAccount(1200m, 3.2m, Customer.company, new DateTime(2012, 3, 5));
            Console.WriteLine(deposAcc.InterestOverMonths(5));
            Console.WriteLine(deposAcc.GetBalance);
            deposAcc.Deposit(200m);
            Console.WriteLine(deposAcc.GetBalance);

        }
    }

    enum AccountType
    {
        deposit, loan, mortgage
    }
    enum Customer
    {
        personal, company
    }

    abstract class BaseAccount
    {
        protected AccountType accType;
        protected DateTime timeCreated;
        protected Customer customerType;
        

        protected decimal balance;
        protected decimal interest;

        public BaseAccount(decimal balance, decimal interest, Customer customer, DateTime dateCreated)
        {
            this.balance = balance;
            this.interest = interest;
            this.customerType = customer;
            this.timeCreated = dateCreated;
        }

        public abstract decimal InterestOverMonths(int numberMonths);
        public void Deposit(decimal amount)
        {
            this.balance += amount;

        }
        public decimal GetBalance
        {
            get { return balance; }
        }
        
    }


    class LoanAccount : BaseAccount
    {
        DateTime paymentStarts;

        public LoanAccount(decimal balance, decimal interest, Customer customer, DateTime dateCreated)
            : base(balance, interest, customer, dateCreated)
        {
            accType = AccountType.loan;

            if (this.customerType == Customer.personal)
            {
                paymentStarts = dateCreated.AddDays(90);
            }
            else if (this.customerType == Customer.company)
            {
                paymentStarts = dateCreated.AddDays(60);
            }
        }

        public override decimal InterestOverMonths(int numberMonths)
        {
            if (paymentStarts < DateTime.Now.AddMonths(numberMonths))
            {
                DateTime afteraddedm = DateTime.Now.AddMonths(numberMonths);
                int diffm = afteraddedm.Month - paymentStarts.Month;
                if (diffm == 0)
                {
                    if (afteraddedm.Day - paymentStarts.Day > 0)
                        return interest;
                }
                return diffm * interest;
            }
            else
            {
                return 0;
            }
        }
        
    }

    class MortgageAccount : BaseAccount
    {
        DateTime fullPaymentStarts;

        public MortgageAccount(decimal balance, decimal interest, Customer customer, DateTime dateCreated)
            : base(balance, interest, customer, dateCreated)
        {
            accType = AccountType.mortgage;

            if (this.customerType == Customer.personal)
            {
                fullPaymentStarts = DateTime.Now.AddDays(178);
            }
            else if (this.customerType == Customer.company)
            {
                fullPaymentStarts = DateTime.Now.AddDays(356);
            }
        }

        public override decimal InterestOverMonths(int numberMonths)
        {
            if (this.customerType == Customer.personal)
            {
                if (fullPaymentStarts < DateTime.Now.AddMonths(numberMonths))
                {
                    DateTime afterAddedm = DateTime.Now.AddMonths(numberMonths);
                    int months = afterAddedm.Month - fullPaymentStarts.Month;
                    if (months == 0)
                    {
                        if (afterAddedm.Day - fullPaymentStarts.Day > 0) return interest;
                    }

                    return months * interest;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (fullPaymentStarts > DateTime.Now.AddMonths(numberMonths))
                {
                    DateTime afterAddedm = DateTime.Now.AddMonths(numberMonths);
                    int Fullmonths = afterAddedm.Month - fullPaymentStarts.Month;
                    int halfMonths = 0;
                    DateTime today = DateTime.Now;
                    if (today < fullPaymentStarts)
                    {
                        halfMonths = fullPaymentStarts.Month - today.Month;
                        if (halfMonths == 0 && fullPaymentStarts.Day - today.Day > 0) halfMonths = 1;
                    }

                    return (halfMonths * interest / 2) + Fullmonths * interest;
                }
                else
                {
                    DateTime afterAddedm = DateTime.Now.AddMonths(numberMonths);
                    int months = afterAddedm.Month - fullPaymentStarts.Month;
                    if (months == 0)
                    {
                        if (afterAddedm.Day - fullPaymentStarts.Day > 0) return interest;
                    }

                    return months * interest/2;
                }
            }
        }
    }

    class DepositAccount : BaseAccount
    {
        public DepositAccount(decimal balance, decimal interest, Customer customer, DateTime dateCreated)
            : base(balance, interest, customer, dateCreated)
        {

        }

        public override decimal InterestOverMonths(int numberMonths)
        {
            if (balance >= 1000)
            {
                //if its past half of the month, payments are done, 
                //so the interest for the current month is not added
                if (DateTime.Now.Day > 15) numberMonths -= 1;
                return numberMonths * interest;
            }
            else
            {
                return 0;
            }
        }
    }
}
