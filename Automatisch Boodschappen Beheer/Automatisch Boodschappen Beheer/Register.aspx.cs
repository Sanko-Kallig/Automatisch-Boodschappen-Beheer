using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Automatisch_Boodschappen_Beheer
{
    public partial class Register : System.Web.UI.Page
    {
        public AccountManagement accountManagement;
        TextBox tbxEmail;
        TextBox tbxName;
        TextBox tbxPassword;
        protected void Page_Load(object sender, EventArgs e)
        {
            accountManagement = new AccountManagement();
            tbxEmail = ((TextBox)this.lncRegister.FindControl("tbxEmail"));
            tbxName = ((TextBox)this.lncRegister.FindControl("tbxName"));
            tbxPassword = ((TextBox)this.lncRegister.FindControl("tbxPassword"));
        }

        protected void OnRegister(object sender, LoginCancelEventArgs e)
        {
            if (this.IsValid)
            {
                try
                {
                   Account account = new Account(tbxEmail.Text, tbxName.Text, AccountType.User);
                    if(accountManagement.CreateAccount(account, tbxPassword.Text))
                    {
                        Response.Redirect("/Login.aspx");
                    }
                    else
                    {
                        ((Literal)this.lncRegister.FindControl("FailureText")).Text = "Email is al bezet.";
                        e.Cancel = true;
                    }
                }
                catch
                {
                    ((Literal)this.lncRegister.FindControl("FailureText")).Text = "Account kon niet worden aan gemaakt.";
                    e.Cancel = true;
                }

            }
        }
    }
}