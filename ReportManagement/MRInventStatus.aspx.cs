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

public partial class ReportManagement_MRInventStatus : System.Web.UI.Page
{
    //#region Variables
    //SqlConnection con = new SqlConnection();
    //#endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (con.State == ConnectionState.Closed)
        //{
        //    con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        //}
        //DataSet ds = new DataSet();
        //SqlCommand cmd = new SqlCommand("MRInventStatus", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandTimeout = 0;
        //cmd.Parameters.AddWithValue("@datestore", Convert.ToDateTime(Session["from"]));
        //cmd.Parameters.AddWithValue("@datestoreto", Convert.ToDateTime(Session["to"]));
        //SqlDataAdapter adp = new SqlDataAdapter();
        //adp.SelectCommand = cmd;
        //adp.Fill(ds);
        //ReportDataSource rptds = new ReportDataSource();
        //rptds.Name = "MRReports_MRInventStatus";
        //ReportViewer11.LocalReport.EnableExternalImages = true;
        //rptds.Value = ds.Tables[0];
        //ReportViewer11.LocalReport.DataSources.Clear();
        //ReportViewer11.LocalReport.DataSources.Add(rptds);

        //ReportViewer11.LocalReport.ReportEmbeddedResource = "RDLC2008/MRInventStatus.rdlc";
        //ReportViewer11.LocalReport.ReportPath = @"RDLC2008/MRInventStatus.rdlc";
        //ReportViewer11.LocalReport.Refresh();
        //cmd.Dispose();

    }
}
