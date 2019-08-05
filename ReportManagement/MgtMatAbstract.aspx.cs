using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MgtMatAbstract : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtstore.Text = "S and T (T) Store, TLSC, Ablowal, Patiala";
    }
    protected void btnproceed_Click(object sender, EventArgs e)
    {
        txtstore.Text = "S and T (T) Store, TLSC, Ablowal, Patiala";
        DateTime from = new DateTime();
        DateTime to = new DateTime();
        from = Convert.ToDateTime(txtfromdate.Text);
        to = Convert.ToDateTime(txttodate.Text);
        String strfrom, strto;
        strfrom = from.ToString("yyyy,MM,dd");
        strto = to.ToString("yyyy,MM,dd");
        Response.Redirect("MgtMatAbstarctPage.aspx?from=" + strfrom + "&to=" + strto );
    }
}