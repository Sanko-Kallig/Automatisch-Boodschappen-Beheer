using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Automatisch_Boodschappen_Beheer
{
    public class AccountManagement
    {
        double totalCost;
        public List<Account> Accounts { get; set; }
        public AccountManagement()
        {
            this.Accounts = RequestAccounts();
        }

        public List<Account> RequestAccounts()
        {
            return DatabaseManager.GetAccounts();
        }

        [Obsolete]
        public List<Account> SelectAccounts()
        {
            return null;
        }

        [Obsolete]
        public Account SelectAccount()
        {
            return null;
        }

        public Account AuthenticateAccount(string email, string password)
        {
            return DatabaseManager.AuthenticateAccount(email, password);
        }

        public bool CreateAccount(Account account, string password)
        {
            Account tempAccount = DatabaseManager.CreateAccount(account, password);
            if(tempAccount != null)
            {
                this.Accounts = RequestAccounts();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAccount(Account account)
        {
            if (DatabaseManager.ModifyAccount(account))
            {
                this.Accounts = RequestAccounts();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveAccount(Account account)
        {
            if (DatabaseManager.DeleteAccount(account))
            {
                this.Accounts = RequestAccounts();
                return true;
            }
            else
            {
                return false;
            }
        }

        public double CostsAccount(Account account)
        {
            totalCost = 0;
            List<double> accountCosts = DatabaseManager.GetCostsAccounts(account);
            foreach (double d in accountCosts)
            {
                totalCost += d;
            }

            return totalCost;
        }

    }
}