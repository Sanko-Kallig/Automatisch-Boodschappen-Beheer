using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Automatisch_Boodschappen_Beheer
{
    public class Account
    {
        #region Fields
        private int id = -1;
        #endregion Fields

        public int ID
        {
            get
            {
                if (id == -1)
                { return DatabaseManager.GetAccountID(Email); }
                else
                {
                    return id;
                }
            }
            set { id = value; }
        }

        public string Email { get; set; }

        public string Name { get; set; }

        public AccountType Role { get; set; }

        public Account(string email, string name, AccountType role)
        {
            id = -1;
            this.Email = email;
            this.Name = name;
            this.Role = role;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}