using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class Reports_RptExpenditureMainPage : System.Web.UI.Page
{
    #region Variables
    SqlConnection con = new SqlConnection();
    #endregion
    private void sourcename()
    {

        SqlCommand cmd = new SqlCommand("sourcemast", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@store", Session["StoreName"].ToString());
        SqlDataReader dr2;
        dr2 = cmd.ExecuteReader();
        if (dr2.HasRows)
        {
            // ITEM NAME 1
            ddstatustype.DataTextField = "source";
            ddstatustype.DataValueField = "source";
            ddstatustype.DataSource = dr2;
            ddstatustype.DataBind();
            dr2.Close();
            cmd.Dispose();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        txtstore.Text = Session["StoreName"].ToString();
        if (!Page.IsPostBack)
        {
            sourcename();
            //ddstatustype.SelectedIndex = 0;
        }
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
        //if (ddstatustype.SelectedIndex == 0)
        //{
        //    ClientScript.RegisterClientScriptBlock(this.GetType(), "ddd", "<script>alert('Select Type')</script>");
        //    return;
        //}
        //else// if (ddstatustype.SelectedIndex == 1)
        {
            txtstore.Text = Session["StoreName"].ToString();
            Response.Redirect("RptExpenditurea.aspx?from=" + strfrom + "&to=" + strto + "&type=" + ddstatustype.SelectedValue + "&store=" + txtstore.Text);
        }
        //else
        //{
        //    txtstore.Text = Session["StoreName"].ToString();
        //    Response.Redirect("MainAbstractIssue.aspx?from=" + strfrom + "&to=" + strto + "&type=" + ddstatustype.SelectedValue + "&store=" + txtstore.Text);
        //}
    }
}