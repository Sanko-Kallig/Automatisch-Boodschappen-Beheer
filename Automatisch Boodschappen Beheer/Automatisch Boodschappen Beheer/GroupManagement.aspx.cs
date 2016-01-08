using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Automatisch_Boodschappen_Beheer
{
    public partial class GroupManagementForm : System.Web.UI.Page
    {
        GroupManagement gm;
        Account account;
        List<Group> ownerGroups;
        protected void Page_Load(object sender, EventArgs e)
        {
            account = (Account)this.Session["Account"];
            if(account != null)
            {
                if(!this.IsPostBack)
                {
                    gm = new GroupManagement();
                    switch(account.Role)
                    {
                        case AccountType.Admin:
                            {
                                                       
                                lbxGroups.DataSource = gm.Groups;
                                lbxGroups.DataBind();
                                lbxAccounts.DataSource = gm.Groups[lbxGroups.SelectedIndex].Users;
                                lbxAccounts.DataBind();
                                break;
                            }
                        case AccountType.User:
                            {   
                                ownerGroups = gm.OwnerGroups(account);
                                lbxGroups.DataSource = ownerGroups;
                                lbxGroups.DataBind();
                                lbxAccounts.DataSource = ownerGroups[lbxAccounts.SelectedIndex];
                                lbxAccounts.DataBind();
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

        protected void lbxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        protected void lbxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(account.Role == AccountType.Admin)
            {
               this.tbxName.Text = gm.Groups[lbxGroups.SelectedIndex].Name;
            }
            if(account.Role == AccountType.User)
            {
                this.tbxName.Text = ownerGroups[lbxGroups.SelectedIndex].Name;
            }

        }

        protected void btnModifyGroup_Click(object sender, EventArgs e)
        {
        
        }
        }
    }