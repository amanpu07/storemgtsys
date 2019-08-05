using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportManagement_MRInventObsoleteMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnproceed_Click(object sender, EventArgs e)
    {
        DateTime from = new DateTime();
        DateTime to = new DateTime();
        from = Convert.ToDateTime(txtfromdate.Text);
        to = Convert.ToDateTime(txttodate.Text);
        String strfrom, strto;
        strfrom = from.ToString("yyyy,MM,dd");
        strto = to.ToString("yyyy,MM,dd");
        Session["from"] = strfrom;
        Session["to"] = strto;
        //Response.Redirect("MRObsoleteInvent.aspx");
        Response.Redirect("MRObsoleteInvent.aspx?from=" + strfrom + "&to=" + strto);
    }
}
