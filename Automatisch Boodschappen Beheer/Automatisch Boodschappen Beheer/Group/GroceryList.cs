using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automatisch_Boodschappen_Beheer
{
    public class GroceryList
    {
        public int ID { get; set; }
        public List<Product> Products { get; set; }
        public GroceryList(int id)
        {
            this.ID = id;
        }
    }
}