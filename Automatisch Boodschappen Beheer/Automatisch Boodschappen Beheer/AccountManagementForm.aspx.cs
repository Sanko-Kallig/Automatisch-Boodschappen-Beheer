using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Automatisch_Boodschappen_Beheer
{
    public partial class AccountManagementForm : System.Web.UI.Page
    {
        static AccountManagement am;
        Account account;
        protected void Page_Load(object sender, EventArgs e)
        {
            account = (Account)this.Session["Account"];
            if (account != null)
            {
                if (!IsPostBack)
                {
                    switch (account.Role)
                    {
                        case AccountType.Admin:
                            {
                                lbxAccounts.DataSource = am.Accounts;
                                lbxAccounts.DataBind();
                                ddlRole.Enabled = true;
                                ddlRole.DataSource = Enum.GetNames(typeof(AccountType));
                                ddlRole.DataBind();
                                break;
                            }
                        case AccountType.User:
                            {
                                List<Account> accounts = new List<Account>();
                                accounts.Add(account);
                                lbxAccounts.DataSource = accounts;
                                lbxAccounts.DataBind();
                                ddlRole.Enabled = false;
                                break;
                            }
                    }
                }
            }
            else
            {
                Response.Redirect("/Index.aspx");
            }
        }

        protected void btnModifyAccount_Click(object sender, EventArgs e)
        {
            AccountType accountTypeValue = (AccountType)Enum.Parse(typeof(AccountType), ddlRole.SelectedValue.ToString());
            am.Accounts[lbxAccounts.SelectedIndex].Email = tbxEmail.Text;
            am.Accounts[lbxAccounts.SelectedIndex].Name = tbxName.Text;
            am.Accounts[lbxAccounts.SelectedIndex].Role = accountTypeValue;
            if (!am.UpdateAccount(am.Accounts[lbxAccounts.SelectedIndex]))
            {

            }
            else
            {

            }

        }

        protected void lbxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(account.Role != AccountType.Admin)
            {
                this.tbxName.Text = account.Name;
                this.tbxEmail.Text = account.Email;
                this.ddlRole.SelectedValue = account.Role.ToString();
            }
            else
            {
             this.tbxName.Text = am.Accounts[lbxAccounts.SelectedIndex].Name;
            this.tbxEmail.Text = am.Accounts[lbxAccounts.SelectedIndex].Email;
            this.ddlRole.SelectedValue = am.Accounts[lbxAccounts.SelectedIndex].Role.ToString();
            }

        }

        protected void btnDisableAccount_Click(object sender, EventArgs e)
        {
            am.RemoveAccount(am.Accounts[lbxAccounts.SelectedIndex]);
        }
    }
}
