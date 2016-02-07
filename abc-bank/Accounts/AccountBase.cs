using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank.Accounts
{
    public abstract class AccountBase : IAccount
    {
        public List<Transaction> transactions;

        public abstract double InterestEarned();

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                transactions.Add(new Transaction(amount));
            }
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");
            }
            else
            {
                transactions.Add(new Transaction(-amount));
            }
        }

        public double sumTransactions()
        {
            return CheckIfTransactionsExist(true);
        }

        private double CheckIfTransactionsExist(bool checkAll)
        {
            double amount = 0.0;
            foreach (Transaction t in transactions)
                amount += t.amount;
            return amount;
        }
    }
}
