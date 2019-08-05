using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_SRReportMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtstore.Text = Session["StoreName"].ToString();
    }
    protected void btnproceed_Click(object sender, EventArgs e)
    {
        Response.Redirect("SRReportPage.aspx?bookno=" + txtbookno.Text + "&pageno=" + txtpageno.Text + "&store=" + txtstore.Text);
    }
}
