using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Inventory_MPIndex11 : System.Web.UI.MasterPage
{
    //ClassLogin.classDisplay obj = new ClassLogin.classDisplay();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Role"] != null)
            {
               // lblStore.Text = "Store : <br>" + Convert.ToString(Session["StoreName"]);
                lblRole.Text = "Role : " + Convert.ToString(Session["RoleN"]);
                // lblDist.Text = "Location : " + obj.CTypeDis(Convert.ToInt32(Session["DisCode"]));
                lblUser.Text = "User : " + Convert.ToString(Session["UI"]);
            }
            else
            {
                Response.Redirect("../Inventory/RegErr.aspx?Err=1002");
            }
            String varR1 = Convert.ToString(Session["Role"]);
            if ((varR1 == "2") || (varR1 == "1"))
            {
                Response.Redirect("../Inventory/RegErr.aspx?Err=1001");
            }
        }
    }
}
