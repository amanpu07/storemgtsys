using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportManagement_MRInventAgeingMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnproceed_Click(object sender, EventArgs e)
    {
        DateTime from = new DateTime();
        from = Convert.ToDateTime(txtfromdate.Text);
        String strfrom;
        strfrom = from.ToString("yyyy,MM,dd");
        Response.Redirect("MRInventAgeing.aspx?from=" + strfrom);
    }
}
