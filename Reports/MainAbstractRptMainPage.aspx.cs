using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MainAbstractRptMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtstore.Text = Session["StoreName"].ToString();
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
        if (ddtype.SelectedIndex == 0)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "ddd", "<script>alert('Select Type')</script>");
            return;
        }
        else if (ddtype.SelectedIndex == 1)
        {
            txtstore.Text = Session["StoreName"].ToString();
            Response.Redirect("AbstractReceipt.aspx?from=" + strfrom + "&to=" + strto + "&type=" + ddtype.SelectedValue + "&store=" + txtstore.Text);
            //Response.Redirect("aman.aspx?from=" + strfrom + "&to=" + strto + "&type=" + ddtype.SelectedValue + "&store=" + txtstore.Text);
        }
        else
        {
            txtstore.Text = Session["StoreName"].ToString();
            Response.Redirect("AbstractIssue.aspx?from=" + strfrom + "&to=" + strto + "&type=" + ddtype.SelectedValue + "&store=" + txtstore.Text);
        }
    }
}