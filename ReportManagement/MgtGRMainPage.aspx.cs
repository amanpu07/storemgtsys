using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportManagement_MgtGRMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtstore.Text = "S and T (T) Store, TLSC, Ablowal, Patiala";
    }
    protected void btnproceed_Click(object sender, EventArgs e)
    {
        Response.Redirect("MgtGRReportPage.aspx?bookno=" + txtbookno.Text + "&pageno=" + txtpageno.Text + "&store=" + txtstore.Text);
    }
}