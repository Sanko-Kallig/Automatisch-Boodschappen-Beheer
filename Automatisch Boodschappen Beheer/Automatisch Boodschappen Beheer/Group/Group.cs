using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Automatisch_Boodschappen_Beheer.Group
{
    public class Group
    {
        private int ID { get; set; }
        private string Name { get; set; }
        private Account.Account Owner { get; set; }

        public Group(int id, string name, Account.Account owner)
        {
            this.ID = id;
            this.Name = name;
            this.Owner = owner;
        }
    }
}