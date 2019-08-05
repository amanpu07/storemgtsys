﻿using System;
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
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

public partial class Inventory_loginmastercreationje : System.Web.UI.Page
{
    private void divmaster()
    {
        DataSet ds;
        string qry = string.Format("select divid,divisonname from tblmasterdivison where divid = 0  union all  select divid,divisonname from tblmasterdivison " +
                                   "where divid <> 0 order by divisonname");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' divid, 'NIL' divisonname";
            ds = DBConnection.fillDataSet(qry);
        }
        dddiv.DataTextField = ds.Tables[0].Columns["divisonname"].ToString();
        dddiv.DataValueField = ds.Tables[0].Columns["divid"].ToString();
        dddiv.DataSource = ds.Tables[0];
        dddiv.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void subdivmaster()
    {
        DataSet ds;
        string qry = string.Format("select subdivisionid,subdivisionname,divid from tbllogin where subdivisionid=0  union all select distinct subdivisionid,subdivisionname,divid from tbllogin" +
                                   " where divid={0} " +
                                   " order by subdivisionname"
                                    , dddiv.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' subdivisionid, 'NIL' subdivisionname";
            ds = DBConnection.fillDataSet(qry);
        }
        ddsubdiv.DataTextField = ds.Tables[0].Columns["subdivisionname"].ToString();
        ddsubdiv.DataValueField = ds.Tables[0].Columns["subdivisionid"].ToString();
        ddsubdiv.DataSource = ds.Tables[0];
        ddsubdiv.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void divmastersearch()
    {
        DataSet ds;
        string qry = string.Format("select divid,divisonname from tblmasterdivison where divid = 0  union all  select divid,divisonname from tblmasterdivison " +
                                   "where divid <> 0 order by divisonname");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' divid, 'NIL' divisonname";
            ds = DBConnection.fillDataSet(qry);
        }
        dddivsearch.DataTextField = ds.Tables[0].Columns["divisonname"].ToString();
        dddivsearch.DataValueField = ds.Tables[0].Columns["divid"].ToString();
        dddivsearch.DataSource = ds.Tables[0];
        dddivsearch.DataBind();
        ds.Clear();
        ds.Dispose();
    }

    public Int32 maxdivid()
    {
        string scmdText = string.Format("Select max(subdivisionid)+1 as subdivisionid from tbllogin");
        DataSet ds = DBConnection.fillDataSet(scmdText);
        int k = Convert.ToInt32(ds.Tables[0].Rows[0]["subdivisionid"]);
        ds.Clear();
        ds.Dispose();
        return k;

    }
    private void gridbind()
    {
        string qry = string.Format("select username,userpassword,storelocationcode,rolename,subdivisionid,subdivisionname,divid,divisonname from tbllogin where divisonname is not null  " +
                                    " order by divisonname, subdivisionname ");
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    private void clear()
    {       
        txtloc.Text = "";
        txtuser.Text = "";
        txtpwd.Text = "";
        divmastersearch();
        divmaster();
        subdivmaster();
        gridbind();
    }
    private void allclear()
    {        
        txtloc.Text = "";
        txtuser.Text = "";
        txtpwd.Text = "";
        divmastersearch();
        divmaster();
        subdivmaster();
        gridbind();
    }
    private void readonlytext()
    {

    }

    private void unreadonlytext()
    {

    }
    private void showMsg(Label lbl, Color color, string msg)
    {
        lbl.ForeColor = color;
        lbl.Text = msg;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["StoreName"] == null || Session["UI"] == null)
        {
            Response.Redirect("../Home/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            divmastersearch();
            divmaster();
            subdivmaster();
            gridbind();

        }
        lblaeeremarks.Visible = false;
    }
    protected void dddiv_SelectedIndexChanged(object sender, EventArgs e)
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;
        string qry = string.Format("Select loc from tblmasterdivison" +
                                   " where divid={0} "
                                    , dddiv.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' loc";
            ds = DBConnection.fillDataSet(qry);
        }
        txtloc.Text = ds.Tables[0].Rows[0]["loc"].ToString();
        ds.Clear();
        ds.Dispose();
        subdivmaster();
    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        if (Proceed.Text == "Save")
        {

            lblmsg.Visible = true;
            DataSet ds;
            string qry = string.Format("select username,userpassword,storelocationcode,subdivisionid,subdivisionname,divid,divisonname from tbllogin " +
                                       " where username='{0}' "
                                        , txtuser.Text);
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (txtuser.Text == ds.Tables[0].Rows[0]["username"].ToString())
                {
                    showMsg(lblmsg, Color.Red, "Record already Exits!");
                }

                ds.Clear();
                ds.Dispose();
            }
            else
            {
                if (dddiv.SelectedItem.Text == "....")
                {
                    Label2.Visible = true;

                    showMsg(Label2, Color.Red, "Select Divison!");
                    return;
                }
                else if (ddsubdiv.SelectedItem.Text == "....")
                {
                    Label3.Visible = true;

                    showMsg(Label3, Color.Red, "Select Sub Divison!");
                    return;
                }
                else
                {
                    Int32 maxsubdivid = maxdivid();
                    string scmdText = " BEGIN ";
                    scmdText += string.Format("Insert into tbllogin (username,userpassword,storelocationcode,storename,rolecode,rolename,storelocationname,employeename,stype,subdivisionid,subdivisionname,divid,divisonname,employeecode)" +
                                              " VALUES ( '{0}' ,'{1}','{2}','{3}',{4},'{5}','{6}','{7}', '{8}',{9}, '{10}',{11}, '{12}','{13}') "
                                              , txtuser.Text, txtpwd.Text, txtloc.Text, ddsubdiv.SelectedItem.Text, 3, "JE", "", txtempname.Text, "Sub Divison", ddsubdiv.SelectedValue, ddsubdiv.SelectedItem.Text, dddiv.SelectedValue, dddiv.SelectedItem.Text, txtempcode.Text);


                    scmdText += " END ";
                    DBConnection.executeNonQuery(scmdText);
                    showMsg(lblmsg, Color.Red, "Saved Successfully!");
                    Label2.Visible = false;

                }
            }

        }
        else if (Proceed.Text == "Update")
        {

        }
        try
        {
            clear();
            gridbind();
        }
        catch (Exception ex)
        {
            showMsg(lblmsg, Color.Red, "Uploaded Error : " + ex.Message);
        }            
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        lblMessage2.Visible = false;
        allclear();
        Proceed.Text = "Save";
        unreadonlytext();
    }
    protected void btsearch_Click(object sender, EventArgs e)
    {
        string qry = string.Format("select username,userpassword,storelocationcode,rolename,subdivisionid,subdivisionname,divid,divisonname from tbllogin " +
                                   "where divid={0}" +
                                    "order by divisonname,subdivisionname"
                                   , dddivsearch.SelectedValue);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    protected void btsearchcancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("loginmastercreationje.aspx");
    }

    protected void GVInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVInfo.PageIndex = e.NewPageIndex;
        gridbind();
        txtbox.Visible = false;
    }
}