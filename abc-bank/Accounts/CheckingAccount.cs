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
        //public const int CHECKING = 0;
        //public const int SAVINGS = 1;
        //public const int MAXI_SAVINGS = 2;

        private readonly int accountType;

        public CheckingAccount(int accountType) 
        {
            this.accountType = accountType;
            base.transactions = new List<Transaction>();
        }

        public override double InterestEarned() 
        {
            double amount = sumTransactions();
            switch(accountType){
                case SAVINGS:
                    if (amount <= 1000)
                        return amount * 0.001;
                    else
                        return 1 + (amount-1000) * 0.002;
    //            case SUPER_SAVINGS:
    //                if (amount <= 4000)
    //                    return 20;
                case MAXI_SAVINGS:
                    if (amount <= 1000)
                        return amount * 0.02;
                    if (amount <= 2000)
                        return 20 + (amount-1000) * 0.05;
                    return 70 + (amount-2000) * 0.1;
                default:
                    return amount * 0.001;
            }
        }


        public int GetAccountType() 
        {
            return accountType;
        }

    }
}
