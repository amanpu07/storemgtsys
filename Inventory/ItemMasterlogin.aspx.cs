using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_ItemMasterlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        if(txtuser.Text == "aman" && txtpwd.Text == "aman")
        {
            Response.Redirect("ItemMaster.aspx");
        }
    }
}