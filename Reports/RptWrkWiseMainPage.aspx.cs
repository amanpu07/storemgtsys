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

public partial class Reports_RptWrkWiseMainPage : System.Web.UI.Page
{
    #region Variables
    SqlConnection con = new SqlConnection();
    #endregion

    private void bindname()
    {
        string stv2 = "Select  iname,icode  from MASTINVENTORY where itype = @ItemType order by iname";
        SqlCommand cmd2 = new SqlCommand(stv2, con);
        cmd2.CommandType = CommandType.Text;
        cmd2.Connection = con;
        cmd2.Parameters.Add(new SqlParameter("@ItemType", dditemtype.SelectedValue));
        SqlDataReader dr2;
        dr2 = cmd2.ExecuteReader();
        if (dr2.HasRows)
        {
            // ITEM NAME 1
            dditemname.DataTextField = "iname";
            dditemname.DataValueField = "icode";
            dditemname.DataSource = dr2;
            dditemname.DataBind();
            dr2.Close();
            cmd2.Dispose();
        }
    }

    private void bindtype()
    {

        //To show Item Type
        string stv1 = "Select distinct itype  from MASTINVENTORY order by itype";
        SqlCommand cmd1 = new SqlCommand(stv1, con);
        cmd1.CommandType = CommandType.Text;
        cmd1.Connection = con;
        SqlDataReader dr1;
        dr1 = cmd1.ExecuteReader();
        if (dr1.HasRows)
        {
            // ITEM TYPE 1
            dditemtype.DataTextField = "itype";
            dditemtype.DataValueField = "itype";
            dditemtype.DataSource = dr1;
            dditemtype.DataBind();
            dr1.Close();
            cmd1.Dispose();
        }
    }

    private void bindwork()
    {

        //To show Item Type
        string stv3 = "select distinct nameofwork from stockissuetable where istore=@istore and nameofwork is not null order by nameofwork";
        SqlCommand cmd3 = new SqlCommand(stv3, con);
        cmd3.CommandType = CommandType.Text;
        cmd3.Connection = con;
        cmd3.Parameters.Add(new SqlParameter("@istore", Session["StoreName"].ToString()));
        SqlDataReader dr3;
        dr3 = cmd3.ExecuteReader();
        if (dr3.HasRows)
        {
            // ITEM TYPE 1
            ddwork.DataTextField = "nameofwork";
            ddwork.DataValueField = "nameofwork";
            ddwork.DataSource = dr3;
            ddwork.DataBind();
            dr3.Close();
            cmd3.Dispose();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
         con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (!Page.IsPostBack)
        {
            bindtype();
            bindname();
            bindwork();
            dditemtype.SelectedItem.Text = "....";
            dditemname.SelectedItem.Text = "....";
        }
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
        if (dditemtype.SelectedIndex == 0)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "ddd", "<script>alert('Select Item Type')</script>");
            return;
        }
        else
        {
            txtstore.Text = Session["StoreName"].ToString();
            //Response.Redirect("ValueCardRpt.aspx?itemcode=" + dditemname.SelectedValue + "&store=" + txtstore.Text + "&status=" + ddstatus.SelectedValue);
            Response.Redirect("WorkwisRpt.aspx?itemcode=" + dditemname.SelectedValue + "&store=" + txtstore.Text + "&work=" + ddwork.SelectedValue + "&from=" + strfrom + "&to=" + strto);
        }
    }
    protected void dditemtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindname();
    }
    protected void dditemname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
