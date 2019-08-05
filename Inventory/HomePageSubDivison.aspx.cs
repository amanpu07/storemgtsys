using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_HomePageSubDivison : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	
	protected void lbEstimate_Click(object sender, EventArgs e)
	{
		string url = string.Format("http://master.pstcl.org/CreateEstimate.aspx?pack=store&" 
									+ "lcode={0}&eid={1}&userid={2}"
									, Session["lcode"].ToString(), Session["eid"].ToString()
									, Session["userid"].ToString());
		Response.Redirect(url);
	}
}