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
public partial class ReportManagement_AllStrCloMainPage : System.Web.UI.Page
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
            dditemtype.SelectedItem.Text = "....";
            dditemname.SelectedItem.Text = "....";
            txtfromdate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
        }
       
    }
    protected void btnproceed_Click(object sender, EventArgs e)
    {
        //string store1 = "";
        //string store2 = "";


        DateTime from = new DateTime();
        DateTime to = new DateTime();
        from = Convert.ToDateTime(txtfromdate.Text);
        String strfrom;
        strfrom = from.ToString("yyyy,MM,dd");



        if (dditemtype.SelectedIndex == 0)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "ddd", "<script>alert('Select Item Type')</script>");
            return;
        }
        else
        {
            // Session["CloseDate"] = strfrom;testallstrclo.aspx
            //Response.Redirect("AllStrCloPage.aspx?itemname=" + dditemname.SelectedItem.Text + "&itemtype=" + dditemtype.SelectedValue + "&fromdate=" + strfrom);
           // Response.Redirect("testallstrclo.aspx?itemname=" + dditemname.SelectedItem.Text + "&itemtype=" + dditemtype.SelectedValue + "&fromdate=" + strfrom);
            Response.Redirect("AllStrClosBalNew.aspx?itemcode=" + dditemname.SelectedValue + "&from=" + strfrom);
        }


        //if (ddstore.SelectedValue == "1")
        //{
        //    store1 = "S and T (T) Sub Divn. PSTCL, Ablowal, Patiala";
        //    store2 = "S and T (T) Sub Divn. PSTCL, Jamsher";
        //    Session["Store1"] = store1;
        //    Session["Store2"] = store2;
        //    Session["CloseDate"] = strfrom;
        //    // Response.Redirect("clobalcombine.aspx?date=" + strfrom + "&store1=" + store1 + "&store2=" + store2);
        //    Response.Redirect("testmgtcmb.aspx");
        //}
        //else if (ddstore.SelectedValue == "2")
        //{
        //    store1 = "S and T (Grid) Store, PSTCL, Moga";
        //    store2 = "S and T (Grid) Store, PSTCL, Jalandhar";
        //    Session["Store1"] = store1;
        //    Session["Store2"] = store2;
        //    Session["CloseDate"] = strfrom;
        //    //    Response.Redirect("clobalcombine.aspx?date=" + strfrom + "&store1=" + store1 + "&store2=" + store2);
        //    Response.Redirect("testmgtcmb.aspx");
        //}
        //else if (ddstore.SelectedValue == "3")
        //{
        //    store1 = "AEE/PM Store, Sahnewal, PSTCL";
        //    Session["Store1"] = store1;
        //    Session["CloseDate"] = strfrom;
        //    Response.Redirect("testmgtsingle.aspx");
        //    //  Response.Redirect("clobalsingle.aspx?date=" + strfrom + "&store1=" + store1);
        //}
        //else if (ddstore.SelectedValue == "4")
        //{
        //    store1 = "Communication Store, Ludhiana";
        //    Session["Store1"] = store1;
        //    Session["CloseDate"] = strfrom;
        //    Response.Redirect("testmgtsingle.aspx");
        //    //  Response.Redirect("clobalsingle.aspx?date=" + strfrom + "&store1=" + store1);
        //}
        //else if (ddstore.SelectedValue == "5")
        //{
        //    store1 = "Civil Works Circle Jalandhar";
        //    Session["Store1"] = store1;
        //    Session["CloseDate"] = strfrom;
        //    Response.Redirect("testmgtsingle.aspx");
        //    //  Response.Redirect("clobalsingle.aspx?date=" + strfrom + "&store1=" + store1);
        //}
        ////if (ddstore.SelectedValue == "1")
        ////{
        ////    Response.Redirect("clobalsahnewal.aspx?date=" + strfrom);
        ////}
        ////if (ddstore.SelectedValue == "2")
        ////{
        ////    Response.Redirect("clobalablojamh.aspx?date=" + strfrom);
        ////}
        ////if (ddstore.SelectedValue == "3")
        ////{
        ////    Response.Redirect("clobalmogajal.aspx?date=" + strfrom);
        ////}
    }
    protected void dditemtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindname();
    }
    protected void dditemname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
