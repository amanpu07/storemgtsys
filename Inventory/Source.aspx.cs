using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class Inventory_Source : System.Web.UI.Page
{
    #region Variables
    SqlConnection con = new SqlConnection();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
       
    }
    protected void btnProceed1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("sourcename", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@source", txtsource.Text);
        cmd.Parameters.AddWithValue("@store",txtstore.Text);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        txtsource.Text = "";
        txtstore.Text = "";
            
    }
    protected void btndel1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("delsourcename", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@source", txtsource.Text);
        cmd.Parameters.AddWithValue("@store", txtstore.Text);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        txtsource.Text = "";
        txtstore.Text = "";
    }
}