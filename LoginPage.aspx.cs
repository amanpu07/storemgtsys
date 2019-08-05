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

public partial class Home_LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            lblerr.Text = "";
            Session.Abandon();
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {        
       
        if (!checkpwd(txtUser.Text, txtPwd.Text))
        {
            lblerr.Text = "Invalid Username/Password.";
        }
        else
        {
            lblerr.Text = "";
            Int32 a1 = checkrole(txtUser.Text, txtPwd.Text);
            Session["RoleN"] = CRole(a1,txtUser.Text);
            Session["UI"] = txtUser.Text;
            Session["Role"] = a1;
            Session["StoreName"] = CStore(txtUser.Text, txtPwd.Text);
            Session["StoreLoc"] = CStoreLoc(txtUser.Text, txtPwd.Text);
            Session["subdivison"] = CSubdivison(txtUser.Text, txtPwd.Text);
            Session["divison"] = Cdivison(txtUser.Text, txtPwd.Text);
            Session["subdivisonid"] = CSubdivisonid(txtUser.Text, txtPwd.Text);
            Session["divisonid"] = Cdivisonid(txtUser.Text, txtPwd.Text);
            Session["employeename"] = Cempname(txtUser.Text, txtPwd.Text);
            Session["employeecode"] = Cempcode(txtUser.Text, txtPwd.Text);
            switch (a1)
            {
                case 1:
                    //Response.Redirect("~/Inventory/storewelcome.aspx");
                    Response.Redirect("~/Inventory/HomePageStoreJE.aspx");
                    break;
                case 2:
                    Response.Redirect("~/Inventory/HomePageStoreAE.aspx");
                    break;
                case 10:
                    Response.Redirect("~/Inventory/HomePageMaster.aspx");

                    break;
                case 11:
                    Response.Redirect("~/ReportManagement/HomePageMgt.aspx");
                    break;
                case 3:
                    Response.Redirect("~/Inventory/HomePageSubDivison.aspx");
                    break;
                case 4:
                   // Response.Redirect("~/Inventory/SubdivisonSRAE.aspx");
                    Response.Redirect("~/Inventory/HomePageSubDivisonAE.aspx");
                    break;
                case 12:
                    Response.Redirect("~/Inventory/SDInventory.aspx");
                    break;
                case 13:
                    Response.Redirect("~/Inventory/dailystockposition.aspx");
                    break;
            }
        }
    }
     private String CRole(Int32 varRole,String userid)
    {
        String varRoleN = "";
        DataSet ds;
        string qry = string.Format("Select ROLENAME from tbllogin" +
                                   " where username='{0}' and rolecode={1}"
                                    , userid, varRole);
        ds = DBConnection.fillDataSet(qry);
        varRoleN = ds.Tables[0].Rows[0]["ROLENAME"].ToString();
        ds.Clear();
        ds.Dispose();
        return varRoleN;
    }

    private String CStoreLoc(String userid, string password)
    {
        String varStoreloc = "";
        DataSet ds;
        string qry = string.Format("Select storelocationcode  from tbllogin" +
                                   " where username='{0}' and userpassword='{1}' "
                                    , userid, password);
        ds = DBConnection.fillDataSet(qry);
        varStoreloc = ds.Tables[0].Rows[0]["storelocationcode"].ToString();
        ds.Clear();
        ds.Dispose();
        return varStoreloc;
    }

    private String CStore(String userid, string password)
    {
        String varStore = "";
        DataSet ds;
        string qry = string.Format("Select storename  from tbllogin" +
                                   " where username='{0}' and userpassword='{1}' "
                                    , userid, password);
        ds = DBConnection.fillDataSet(qry);
        varStore = ds.Tables[0].Rows[0]["storename"].ToString();
        ds.Clear();
        ds.Dispose();
        return varStore;
    }
    private String Cempname(String userid, string password)
    {
        String varStore = "";
        DataSet ds;
        string qry = string.Format("Select employeename  from tbllogin" +
                                   " where username='{0}' and userpassword='{1}' "
                                    , userid, password);
        ds = DBConnection.fillDataSet(qry);
        varStore = ds.Tables[0].Rows[0]["employeename"].ToString();
        ds.Clear();
        ds.Dispose();
        return varStore;
    }
    private String Cempcode(String userid, string password)
    {
        String varStore = "";
        DataSet ds;
        string qry = string.Format("Select employeecode from tbllogin" +
                                   " where username='{0}' and userpassword='{1}' "
                                    , userid, password);
        ds = DBConnection.fillDataSet(qry);
        varStore = ds.Tables[0].Rows[0]["employeecode"].ToString();
        ds.Clear();
        ds.Dispose();
        return varStore;
    }
    private String CSubdivison(String userid, string password)
    {
        String varSubdiv = "";
        DataSet ds;
        string qry = string.Format("Select subdivisionname  from tbllogin" +
                                   " where username='{0}' and userpassword='{1}' "
                                    , userid, password);
        ds = DBConnection.fillDataSet(qry);
        varSubdiv = ds.Tables[0].Rows[0]["subdivisionname"].ToString();
        ds.Clear();
        ds.Dispose();
        return varSubdiv;
    }
    private String CSubdivisonid(String userid, string password)
    {
        String varSubdivid = "";
        DataSet ds;
        string qry = string.Format("Select subdivisionid  from tbllogin" +
                                   " where username='{0}' and userpassword='{1}' "
                                    , userid, password);
        ds = DBConnection.fillDataSet(qry);
        varSubdivid = ds.Tables[0].Rows[0]["subdivisionid"].ToString();
        ds.Clear();
        ds.Dispose();
        return varSubdivid;
    }
    private String Cdivison(String userid, string password)
    {
        String varDiv = "";
        DataSet ds;
        string qry = string.Format("Select divisonname  from tbllogin" +
                                   " where username='{0}' and userpassword='{1}' "
                                    , userid, password);
        ds = DBConnection.fillDataSet(qry);
        varDiv = ds.Tables[0].Rows[0]["divisonname"].ToString();
        ds.Clear();
        ds.Dispose();
        return varDiv;
    }
    private String Cdivisonid(String userid, string password)
    {
        String vardivid = "";
        DataSet ds;
        string qry = string.Format("Select divid  from tbllogin" +
                                   " where username='{0}' and userpassword='{1}' "
                                    , userid, password);
        ds = DBConnection.fillDataSet(qry);
        vardivid = ds.Tables[0].Rows[0]["divid"].ToString();
        ds.Clear();
        ds.Dispose();
        return vardivid;
    }
    //private String Cemployee(String userid, string password)
    //{
    //    String vardivid = "";
    //    DataSet ds;
    //    string qry = string.Format("Select divid  from tbllogin" +
    //                               " where username='{0}' and userpassword='{1}' "
    //                                , userid, password);
    //    ds = DBConnection.fillDataSet(qry);
    //    vardivid = ds.Tables[0].Rows[0]["divid"].ToString();
    //    ds.Clear();
    //    ds.Dispose();
    //    return vardivid;
    //}
    public Int32 checkrole(String userid, string password)
    {
         string scmdText =  string.Format("Select rolecode  from tbllogin" +
                                   " where username='{0}' and userpassword='{1}' "
                                    , userid, password);
        DataSet ds = DBConnection.fillDataSet(scmdText);
        int k =Convert.ToInt32( ds.Tables[0].Rows[0]["rolecode"]);
        ds.Clear();
        ds.Dispose();
        return k;

    }
    public bool checkpwd(String userid, string password)
    {
        bool result =  false;
        string scmdText =  string.Format("Select *  from tbllogin" +
                                   " where username='{0}' and userpassword='{1}' "
                                    , userid, password);
        DataSet ds = DBConnection.fillDataSet(scmdText);
        if(ds.Tables[0].Rows.Count > 0)
            result = true;
        ds.Clear();
        ds.Dispose();
        return result;
    }
}
