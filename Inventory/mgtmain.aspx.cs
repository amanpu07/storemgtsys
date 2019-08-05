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

public partial class Inventory_mgtmain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtfromdate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
    protected void btnproceed_Click(object sender, EventArgs e)
    {
        string store1 = "";
        string store2 = "";

        
        DateTime from = new DateTime();
        DateTime to = new DateTime();
        from = Convert.ToDateTime(txtfromdate.Text);
        String strfrom;
        strfrom = from.ToString("yyyy,MM,dd");
        //if (ddstore.SelectedValue == "1") 
        //{
        //    store1 = "S and T (T) Sub Divn. PSTCL, Ablowal, Patiala";
        //    store2 = "S and T (T) Sub Divn. PSTCL, Jamsher";
        //    Session["Store1"] = store1;
        //    Session["Store2"] = store2;
        //    Session["CloseDate"] = strfrom;
        //   // Response.Redirect("clobalcombine.aspx?date=" + strfrom + "&store1=" + store1 + "&store2=" + store2);
        //    Response.Redirect("testmgtcmb.aspx");
        //}
        //else if (ddstore.SelectedValue == "2")
        //{
        //    store1 = "S and T (Grid) Store, PSTCL, Moga";
        //    store2 = "S and T (Grid) Store, PSTCL, Jalandhar";
        //    Session["Store1"] = store1;
        //    Session["Store2"] = store2;
        //    Session["CloseDate"] = strfrom;
        ////    Response.Redirect("clobalcombine.aspx?date=" + strfrom + "&store1=" + store1 + "&store2=" + store2);
        //   Response.Redirect("testmgtcmb.aspx");
        //}

        if (ddstore.SelectedValue == "1")
        {
            store1 = "AEE STORE PSTCL ABLOWAL";
            Session["Store1"] = store1;
            Session["CloseDate"] = strfrom;
            Response.Redirect("testmgtsingle.aspx");
        }

        else if (ddstore.SelectedValue == "2")
        {
            store1 = "AEE STORE PSTCL JAMSHER";
            Session["Store1"] = store1;
            Session["CloseDate"] = strfrom;
            Response.Redirect("testmgtsingle.aspx");
            //  Response.Redirect("clobalsingle.aspx?date=" + strfrom + "&store1=" + store1);
        }
        else if (ddstore.SelectedValue == "3")
        {
            store1 = "AEE STORE PSTCL SAHNEWAL";
            Session["Store1"] = store1;
            Session["CloseDate"] = strfrom;
            Response.Redirect("testmgtsingle.aspx");
            //  Response.Redirect("clobalsingle.aspx?date=" + strfrom + "&store1=" + store1);
        }
        else if (ddstore.SelectedValue == "4")
        {
            store1 = "AEE STORE PSTCL MOGA";
            Session["Store1"] = store1;
            Session["CloseDate"] = strfrom;
            Response.Redirect("testmgtsingle.aspx");
            //  Response.Redirect("clobalsingle.aspx?date=" + strfrom + "&store1=" + store1);
        }
        else if(ddstore.SelectedValue == "5")
        {
            store1 = "AEE CO&C STORE PSTCL LUDHIANA";
              Session["Store1"] = store1;            
            Session["CloseDate"] = strfrom;
            Response.Redirect("testmgtsingle.aspx");
            //  Response.Redirect("clobalsingle.aspx?date=" + strfrom + "&store1=" + store1);
        }
        
        //if (ddstore.SelectedValue == "1")
        //{
        //    Response.Redirect("clobalsahnewal.aspx?date=" + strfrom);
        //}
        //if (ddstore.SelectedValue == "2")
        //{
        //    Response.Redirect("clobalablojamh.aspx?date=" + strfrom);
        //}
        //if (ddstore.SelectedValue == "3")
        //{
        //    Response.Redirect("clobalmogajal.aspx?date=" + strfrom);
        //}
    }
}
