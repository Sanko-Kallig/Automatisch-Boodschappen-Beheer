using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Automatisch_Boodschappen_Beheer
{
    public partial class Login : System.Web.UI.Page
    {
        public AccountManagement accountManagement;
        private TextBox tbxUserName;
        private TextBox tbxPassword;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Account"] == null)
            {
                Response.Redirect("/register.aspx");
            }
            tbxUserName = ((TextBox)this.LoginControl.FindControl("UserName"));
            tbxPassword = ((TextBox)this.LoginControl.FindControl("Password"));
            accountManagement = new AccountManagement();
            if(!this.IsPostBack)
            {
            }


        }

        protected void OnLoggingIn(object sender, LoginCancelEventArgs e)
        {
            if (this.IsValid)
            {
                try
                {
                    this.Session["Account"] = accountManagement.AuthenticateAccount(tbxUserName.Text, tbxPassword.Text);
                    Account account = (Account)this.Session["Account"];
                }
                catch
                {
                    ((Literal)this.LoginControl.FindControl("FailureText")).Text = "Gebruikersnaam en/of wachtwoord is fout";
                    e.Cancel = true;
                }
            }
        }
    }
}