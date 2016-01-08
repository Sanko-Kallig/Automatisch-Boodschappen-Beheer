using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Automatisch_Boodschappen_Beheer
{
    public class Group
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Account Owner { get; set; }

        public List<Account> Users { get; set; }

        public List<GroceryList> Grocerylists { get; set; }

        public Group(string id, string name, Account owner)
        {
            this.ID = id;
            this.Name = name;
            this.Owner = owner;
        }
    }
}