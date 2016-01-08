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
 
        protected void Page_Load(object sender, EventArgs e)
        {
            accountManagement = new AccountManagement();

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
                        FailureText.Text = "Email is al bezet.";
                        e.Cancel = true;
                    }
                }
                catch
                {
                    FailureText.Text = "Account kon niet worden aan gemaakt.";
                    e.Cancel = true;
                }

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
                try
                {
                    Account account = new Account(tbxEmail.Text, tbxName.Text, AccountType.User);
                    if (accountManagement.CreateAccount(account, tbxPassword.Text))
                    {
                        Response.Redirect("/Login.aspx");
                    }
                    else
                    {
                        FailureText.Text = "Email is al bezet.";
                    }
                }
                catch
                {
                    FailureText.Text = "Account kon niet worden aan gemaakt.";
                }

            }
        }
    }