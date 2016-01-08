using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automatisch_Boodschappen_Beheer
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string ImageURL { get; set; }
        public double Price { get; set; }
        public DateTime LastModified { get; set; }
        public Account ModifiedBy { get; set; }

        public Product(int id, string name, double price, string imageURL, DateTime lastModified, Account modifiedBy)
        {
            this.ID = id;
            this.Name = name;
            this.ImageURL = imageURL;
            this.Price = price;
            this.LastModified = lastModified;
            this.ModifiedBy = modifiedBy;
        }
    }
}