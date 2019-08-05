using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MonthlyGRReportMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtstore.Text = Session["StoreName"].ToString();
    }
    protected void btnproceed_Click(object sender, EventArgs e)
    {
        txtstore.Text = Session["StoreName"].ToString();
        DateTime from = new DateTime();
        DateTime to = new DateTime();
        from = Convert.ToDateTime(txtfromdate.Text);
        to = Convert.ToDateTime(txttodate.Text);
        String strfrom, strto;
        strfrom = from.ToString("yyyy,MM,dd");
        strto = to.ToString("yyyy,MM,dd");
    //  string role = Session["Role"].ToString();
   
        //Response.Redirect("GRMonthlyReportPage.aspx?from=" + txtfromdate.Text + "&to=" + txttodate.Text);
        Response.Redirect("GRMonthlyReport.aspx?from=" + strfrom + "&to=" + strto + "&store=" + txtstore.Text);
    }
} 