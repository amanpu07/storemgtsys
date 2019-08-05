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
//using MySql.Data.MySqlClient;

public partial class Home_LoginPage : System.Web.UI.Page
{
    string test1;
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
        //else if (!checkempcred(txtempid.Text, txtemppwd.Text))
        //{
        //    lblerr.Text = "Invalid Empid/Password.";
        //}
		else //if (checkpwd(txtUser.Text, txtPwd.Text)) 
		{
			//test1 = EmployeeAuthenticate.EmpAuthenticate(txtempid.Text,txtemppwd.Text);
            test1 = "true";
			
		}
		if (test1 == "true")
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
			 Session.Add("package", "EMS");
                    Session.Add("userid", txtUser.Text);
                    Session.Add("lcode", Session["subdivisonid"]);//made function for DDO Code
                    Session.Add("loginroleid", "104");
                    Session.Add("empid", Session["employeecode"].ToString());
					Session.Add("fname", "");
                    Session.Add("desg", "");
                    Session.Add("logintime",DateTime.Now.ToString("hh:mm:ss"));
                    Session.Add("eid", Session["employeecode"].ToString());
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
                    //Response.Redirect("~/Inventory/SDInventory.aspx");
		      Response.Redirect("");
                    break;
                case 13:
                    Response.Redirect("~/Inventory/dailystockposition.aspx");
                    break;
            }
        }
    else
                {
                    lblerr1.Text = "Invalid Employee ID or Employee Password";
					//string message = "alert('Invalid Employee ID or Employee Password')";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
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

    //public static MySql.Data.MySqlClient.MySqlConnection connect()
    //{
    //     string sConnectionString = "Data Source=192.168.0.251;port=3306;Initial Catalog=empauth_db;Persist Security Info=True;UserID=userjv;Password=strong";
    //    MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(sConnectionString);
    //    try
    //    {
    //        con.Open();
    //        return con;
    //    }
    //    catch (Exception ex)
    //    {
    //        con.Close();
    //        return con;
    //    }
    //}

    //public bool checkempcred(String userid, string password)
    //{
    //    bool result = false;
    //    string sCommandText = string.Format("Select eid,pswd  from loginemp" +
    //                               " where eid='{0}' and pswd='{1}' "
    //                                , userid, password);
    //    MySql.Data.MySqlClient.MySqlConnection con = connect();
    //    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sCommandText, con);
    //    MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();       
    //     adp.Fill(ds);   
        
    //    if (ds.Tables[0].Rows.Count > 0)
    //        result = true;
    //    ds.Clear();
    //    ds.Dispose();
        
    //    return result;
    //}
}
