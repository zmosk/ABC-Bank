using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public class Customer
    {
        private String name;
        private List<IAccount> accounts;

        public Customer(String name)
        {
            this.name = name;
            this.accounts = new List<IAccount>();
        }

        public String GetName()
        {
            return name;
        }

        public Customer OpenAccount(IAccount account)
        {
            accounts.Add(account);
            return this;
        }

        public int GetNumberOfAccounts()
        {
            return accounts.Count;
        }

        public double TotalInterestEarned() 
        {
            double total = 0;
            foreach (IAccount a in accounts)
                total += a.InterestEarned();
            return total;
        }

        public String GetStatement() 
        {
            String statement = null;
            statement = "Statement for " + name + "\n";
            double total = 0.0;
            foreach (IAccount a in accounts) 
            {
                statement += "\n" + statementForAccount(a) + "\n";
                total += a.SumTransactions();
            }
            statement += "\nTotal In All Accounts " + ToDollars(total);
            return statement;
        }

        private String statementForAccount(IAccount a) 
        {
            String s = "";

           //Translate to pretty account type
            switch(a.GetAccountType()){
                case IAccount.CHECKING:
                    s += "Checking Account\n";
                    break;
                case IAccount.SAVINGS:
                    s += "Savings Account\n";
                    break;
                case IAccount.MAXI_SAVINGS:
                    s += "Maxi Savings Account\n";
                    break;
            }

            //Now total up all the transactions
            double total = 0.0;
            foreach (Transaction t in a.transactions) {
                s += "  " + (t.amount < 0 ? "withdrawal" : "deposit") + " " + ToDollars(t.amount) + "\n";
                total += t.amount;
            }
            s += "Total " + ToDollars(total);
            return s;
        }

        private String ToDollars(double d)
        {
            return String.Format("$%,.2f", Math.Abs(d));
        }
    }
}
