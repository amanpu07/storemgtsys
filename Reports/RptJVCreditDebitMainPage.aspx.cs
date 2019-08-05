using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_RptJVCreditDebitMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtstore.Text = Session["StoreName"].ToString();
    }
    protected void btnproceed_Click(object sender, EventArgs e)
    {
        txtstore.Text = Session["StoreName"].ToString();
      
        if (ddjv.SelectedValue == "1")
        {
            Response.Redirect("RptCredit.aspx?jvno=" + txtjvno.Text + "&store=" + txtstore.Text);
        }
        else if (ddjv.SelectedValue == "2")
        {
            Response.Redirect("RptDebit.aspx?jvno=" + txtjvno.Text + "&store=" + txtstore.Text);
        }
    }
}