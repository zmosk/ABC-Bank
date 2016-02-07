using abc_bank.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public class MaxiSavingsAccount : AccountBase
    {
        private readonly int accountType;

        public MaxiSavingsAccount() 
        {
            this.transactions = new List<Transaction>();
        }

        public override double InterestEarned() 
        {
            double amount = SumTransactions();

            if (amount <= 1000)
                return amount * 0.02;

            if (amount <= 2000)
                return 20 + (amount - 1000) * 0.05;

            return 70 + (amount - 2000) * 0.1;
        }

        public override string GetAccountType() 
        {
            return "Maxi Savings Account";
        }

    }
}
