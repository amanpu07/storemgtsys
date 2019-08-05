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
public partial class Inventory_ItemMaster : System.Web.UI.Page
{
    #region Variables
    SqlConnection con = new SqlConnection();
    #endregion

    private void bindtype()
    {

        DataSet ds;
        string qry = string.Format("select distinct typecode,itype from mastinventory order by typecode");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' typecode, 'NIL' itype";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemtype.DataTextField = ds.Tables[0].Columns["itype"].ToString();
        dditemtype.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype.DataSource = ds.Tables[0];
        dditemtype.DataBind();
        ds.Clear();
        ds.Dispose();
    }

    public Int32 maxtypeid()
    {
        string scmdText = string.Format("Select max(typecode)+1 as typecode from mastinventory");
        DataSet ds = DBConnection.fillDataSet(scmdText);
        int k = Convert.ToInt32(ds.Tables[0].Rows[0]["typecode"]);
        ds.Clear();
        ds.Dispose();
        return k;

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["StoreName"] == null || Session["UI"] == null)
        {
            Response.Redirect("../Home/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            bindtype();
            Label1.Visible = false;
            Label2.Visible = false;
        }
       
    }  
   
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        
                    string scmdText = " BEGIN ";
                    scmdText += string.Format("insert into mastinventory (typecode,itype,iname,icode,field1,scrapstatus)" +
                                              " VALUES ({0},'{1}','{2}','{3}','{4}',{5}) "
                                              , dditemtype.SelectedValue, dditemtype.SelectedItem.Text, txtname.Text, txtcode.Text, txtunit.Text, txtstatus.Text);


                    scmdText += " END ";
                    DBConnection.executeNonQuery(scmdText);
                    Label1.Visible = true;
                    Label1.Text = "Successfully Saved!";
                    txtcode.Text = "";
                    txtname.Text = "";
                    txtunit.Text = "";
                    txtstatus.Text = "";
                    bindtype();
    }
    
    protected void btndel_Click(object sender, EventArgs e)
    {
                //SqlCommand cmd = new SqlCommand("deleteitemname", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = con;   
                //cmd.Parameters.AddWithValue("@itype", dditemtype.SelectedItem.Text);
                //cmd.Parameters.AddWithValue("@icode", txtcode.Text);
                //cmd.Parameters.AddWithValue("@iname",txtname.Text);
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();
                //txtcode.Text="";
                //txtname.Text="";
    }
    protected void btnProceed1_Click(object sender, EventArgs e)
    {
        Int32 maxsubdivid = maxtypeid();
        string scmdText = " BEGIN ";
        scmdText += string.Format("insert into mastinventory (typecode,itype,iname,icode,field1,scrapstatus)" +
                                  " VALUES ({0},'{1}','{2}','{3}','{4}',{5}) "
                                  , maxsubdivid, txtitemtype.Text, txtitemname.Text, txtitemcode.Text, txtunit1.Text, txtstatus1.Text);


        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        Label2.Visible = true;
        Label2.Text = "Successfully Saved!";
        txtitemtype.Text = "";
        txtitemname.Text = "";
        txtitemcode.Text = "";
        txtunit1.Text = "";
        txtstatus1.Text = "";
    }
    protected void btndel1_Click(object sender, EventArgs e)
    {
        //SqlCommand cmd = new SqlCommand("deleteitemtype", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Connection = con;
        //cmd.Parameters.AddWithValue("@iitype", txtitemtype.Text);
        //cmd.Parameters.AddWithValue("@iicode", txtitemcode.Text);
        //cmd.Parameters.AddWithValue("@iiname", txtitemname.Text);
        //cmd.ExecuteNonQuery();
        //cmd.Dispose();
        //txtitemcode.Text = "";
        //txtitemname.Text = "";
        //txtitemtype.Text = "";
    }
}