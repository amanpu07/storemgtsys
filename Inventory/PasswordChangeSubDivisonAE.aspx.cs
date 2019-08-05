using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;

public partial class Inventory_PasswordChangeSubDivisonAE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clearWithMsg(Color.Transparent, "");
            txtbxOldPasswd.Focus();
        }
    }
    private void clearWithMsg(System.Drawing.Color color, string str)
    {
        txtbxOldPasswd.Text = "";
        txtbxNewPasswd.Text = "";
        txtbxConPasswd.Text = "";
        lblerr.ForeColor = color;
        lblerr.Text = str;
        txtbxOldPasswd.Focus();
    }
    private bool validatePassword()
    {
        string oldP = "", newP = "", conP = "", pass = "";
        oldP = txtbxOldPasswd.Text;
        newP = txtbxNewPasswd.Text;
        conP = txtbxConPasswd.Text;
        Regex chkPass = new Regex("^[a-zA-Z]{1}[a-zA-Z0-9_]{5,14}$");
        if (!(chkPass.IsMatch(newP) && chkPass.IsMatch(conP)))
        {
            clearWithMsg(Color.Red, "Password must starts with Alphabet, Length between 6 to 15 character. Contains only Letters, Digits or Underscore.");
            return false;
        }
        string scmdText = string.Format("SELECT userpassword from tbllogin WHERE UPPER(username) = UPPER('{0}')", Session["UI"].ToString());
        DataSet ds = DBConnection.fillDataSet(scmdText);
        if (ds.Tables[0].Rows.Count > 0)
            pass = ds.Tables[0].Rows[0]["userpassword"].ToString();
        if (!pass.Equals(oldP))
        {
            clearWithMsg(Color.Red, "Old password is not correct !");
            txtbxOldPasswd.Focus();
            return false;
        }
        if (!newP.Equals(conP))
        {
            clearWithMsg(Color.Red, "New and Confirm Passwords are not matched !");
            txtbxNewPasswd.Focus();
            return false;
        }
        if (oldP.Equals(newP))
        {
            clearWithMsg(Color.Red, "Old and New Passwords are same !");
            txtbxNewPasswd.Focus();
            return false;
        }
        scmdText = string.Format("UPDATE tbllogin SET userpassword = '{0}',employeename = '{1}',employeecode = '{2}' WHERE UPPER(username) = UPPER('{1}')", newP, txtempname.Text, txtempcode.Text, Session["UI"].ToString());
        DBConnection.executeNonQuery(scmdText);
        return true;
    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        if (validatePassword())
        {
            clearWithMsg(Color.Green, "Password successfully changed.");
        }
        return;
    }
    protected void btnCancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/inventory/HomePageSubDivisonAE.aspx");
    }
}