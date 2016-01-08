using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Automatisch_Boodschappen_Beheer
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public bool IsLoggedIn
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ACCOUNT"] != null)
            {
                Account account = (Account)Session["ACCOUNT"];
                lbWelkom.Text = "(Welkom " + account.Name + ")";
            }
            else
            {
                lbWelkom.Text = "";
                IsLoggedIn = false;
            }
        }
    }
}