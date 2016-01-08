using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Automatisch_Boodschappen_Beheer
{
    public partial class ProductManagementForm : System.Web.UI.Page
    {
        public Account account;
        public ProductManagement pm;
        protected void Page_Load(object sender, EventArgs e)
        {
            account = (Account)this.Session["Account"];
            if (account != null)
            {
                if (!this.IsPostBack)
                {
                    pm = new ProductManagement();
                    lbxProducts.DataSource = pm.Products;
                    lbxProducts.DataBind();

                    switch (account.Role)
                    {
                        case AccountType.Admin:
                            {
                                btnDeleteProduct.Enabled = true;
                                break;
                            }
                        case AccountType.User:
                            {
                                btnDeleteProduct.Enabled = false;
                                break;
                            }
                    }
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");

            }
        }
    }
}