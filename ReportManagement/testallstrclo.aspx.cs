using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Configuration;

public partial class ReportManagement_testallstrclo : System.Web.UI.Page
{
    #region Variables
    SqlConnection con = new SqlConnection();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand("procClosingBalanceAllStore", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 0;
       // cmd.Parameters.AddWithValue("@istorename1", Session["Store1"].ToString());
        //cmd.Parameters.AddWithValue("@istorename2", Session["Store2"].ToString());
        cmd.Parameters.AddWithValue("@iclosingdate", Convert.ToDateTime(Request.QueryString["fromdate"]));
        cmd.Parameters.AddWithValue("@iitemtype",  Request.QueryString["itemtype"].ToString());
        cmd.Parameters.AddWithValue("@iitemname", Request.QueryString["itemname"].ToString());
        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;
        adp.Fill(ds);
        ReportDataSource rptds = new ReportDataSource();
        //ReportInfo report = new ReportInfo();

        rptds.Name = "AllStrCloBal_procClosingBalanceAllStore";
        ReportViewer1.LocalReport.EnableExternalImages = true;
        rptds.Value = ds.Tables[0];
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rptds);

        ReportViewer1.LocalReport.ReportEmbeddedResource = "RDLC2008/AllStrCloBal.rdlc";
        ReportViewer1.LocalReport.ReportPath = @"RDLC2008/AllStrCloBal.rdlc";
        // ReportParameter Param0 = new ReportParameter("@istorename1", Session["Store1"].ToString());
        // ReportParameter Param1 = new ReportParameter("@istorename2", Session["Store2"].ToString());
        //// ReportParameter Param2 = new ReportParameter("@iclosingdate", "2014-01-28");
        // ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { Param0, Param1, Param2 });
        ReportViewer1.LocalReport.Refresh();
        cmd.Dispose();
    }
}
