using abc_bank.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public class SavingsAccount : AccountBase
    {
        private readonly int accountType;

        public SavingsAccount() 
        {
            this.transactions = new List<Transaction>();
        }

        public override double InterestEarned() 
        {
            double amount = SumTransactions();

            if (amount <= 1000)
                return amount * 0.001;
            else
                return 1 + (amount - 1000) * 0.002;
        }

        public override string GetAccountType() 
        {
            return "Savings Account";
        }

    }
}
