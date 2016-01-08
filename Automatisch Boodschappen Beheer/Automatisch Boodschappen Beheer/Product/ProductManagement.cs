using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automatisch_Boodschappen_Beheer
{
    public class ProductManagement
    {
        public List<Product> Products { get; set; }
        public ProductManagement()
        {
            this.Products = RequestProducts();
        }

        public List<Product> RequestProducts()
        {
            return DatabaseManager.GetProducts();
        }
        
        public List<Product> SelectProducts()
        {
            return null;
        }

        public Product SelectProduct()
        {
            return null;
        }

        public bool CreateProduct(Product product, Account account)
        {
            Product tempProduct = DatabaseManager.CreateProduct(product, account);
            if (tempProduct != null)
            {
                this.Products = RequestProducts();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product, Account account)
        {
            if(DatabaseManager.ModifyProduct(product, account))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveProduct(Product product)
        {
            if (DatabaseManager.DeleteProduct(product))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}