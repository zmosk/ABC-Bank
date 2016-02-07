using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abc_bank.Accounts;

namespace abc_bank
{
    public class CheckingAccount : AccountBase
    {
        private readonly int accountType;

        public CheckingAccount()
        {
            base.transactions = new List<Transaction>();
        }

        public override double InterestEarned() 
        {
            double amount = SumTransactions();
            return amount * 0.001;
        }

        public override string GetAccountType() 
        {
            return "Checking Account";
        }

    }
}
