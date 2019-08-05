using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_GatePassMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtstore.Text = Session["StoreName"].ToString();
    }
    protected void btnproceed_Click(object sender, EventArgs e)
    {
        txtstore.Text = Session["StoreName"].ToString();
        DateTime from = new DateTime();
        from = Convert.ToDateTime(txtdate.Text);
        String strfrom;
        strfrom = from.ToString("yyyy,MM,dd");
        Response.Redirect("GatePass.aspx?bookno=" + txtbookno.Text + "&pageno=" + txtpageno.Text + "&store=" + txtstore.Text + "&date=" + strfrom);
    }
}