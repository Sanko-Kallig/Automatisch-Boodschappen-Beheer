using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automatisch_Boodschappen_Beheer.Product
{
    public class Product
    {
        private int ID { get; set; }
        private string Name { get; set; }
        private double Price { get; set; }
        private DateTime LastModified { get; set; }
        private Account.Account ModifiedBy { get; set; }

        public Product(int id, string name, double price, DateTime lastModified, Account.Account modifiedBy)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.LastModified = lastModified;
            this.ModifiedBy = modifiedBy;
        }
    }
}