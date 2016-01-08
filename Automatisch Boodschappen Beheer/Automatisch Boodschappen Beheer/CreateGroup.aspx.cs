using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Automatisch_Boodschappen_Beheer
{
    public partial class CreateGroup : System.Web.UI.Page
    {
        static GroupManagement gm;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                if(Session["ACCOUNT"] == null)
                {
                    Response.Redirect("/index.aspx");
                }
                else
                {
                    gm = new GroupManagement();
                }
            }
        }

        protected void btnCreateGroup_Click(object sender, EventArgs e)
        {
            Account account = (Account)Session["ACCOUNT"];
            if(gm.CreateGroup(new Group("a",tbxName.Text, account)))
            {
                Response.Redirect("/index.aspx");
            }
        }
    }
}