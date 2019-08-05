using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Security;

public partial class Inventory_StoreJE : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["StoreName"] == null || Session["UI"] == null || Session["RoleN"] == null)
        {
            Response.Redirect("../Home/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {

            if (Session["Role"] != null)
            {
                lblStore.Text = Convert.ToString(Session["StoreName"]);
                lblRole.Text = Convert.ToString(Session["RoleN"]);
                lblUser.Text = Convert.ToString(Session["UI"]);
            }
            else
            {
                Response.Redirect("../Home/LoginPage.aspx");
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        //FormsAuthentication.RedirectToLoginPage();
Response.Redirect("~/Home/LoginPage.aspx");
    }
}
