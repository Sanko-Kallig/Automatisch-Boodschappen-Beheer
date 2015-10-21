using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Automatisch_Boodschappen_Beheer.SpecialClass;

namespace Automatisch_Boodschappen_Beheer.Account
{
    public class Account
    {
        private int ID { get; set; }

        private string Email { get; set; }

        private string FirstName { get; set; }

        private string Prefix { get; set; }

        private string LastName { get; set; }

        private AccountType Role { get; set; }

        public Account(int id, string email, string firstName, string prefix, string lastName, AccountType role)
        {
            this.ID = id;
            this.Email = email;
            this.FirstName = firstName;
            this.Prefix = prefix;
            this.LastName = lastName;
            this.Role = role;
        }
    }
}