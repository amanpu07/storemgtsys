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

public partial class Inventory_StoreAEJVCredit : System.Web.UI.Page
{
    static long i;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["StoreName"] == null || Session["UI"] == null)
        {
            Response.Redirect("../Home/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            gridbind();
            txtbox.Visible = false;
        }
        lblaeeremarks.Visible = false;
    }
    private void gridbind()
    {
        string qry = string.Format("SELECT CASE WHEN make = '2' THEN grandtotal ELSE grandtotal*(-1) END as grandtotal,rtxno,voucherno,voucherdate,itemname,unit,field2 FROM stockreceipttable " +
                                    "where field7=2 and smonth='Voucher' and storename='{0}' " +
                                    " order by field2 desc,rtxno desc "
                                    , Session["StoreName"].ToString());
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    protected void GVInfo_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i <= GVInfo.Rows.Count - 1; i++)
        {
            Label lblstatus = (Label)GVInfo.Rows[i].FindControl("lblgridStatus");
            lblstatus.Font.Bold = true;

            if (lblstatus.Text == "Pending")
            {
                GVInfo.Rows[i].Cells[5].BackColor = System.Drawing.Color.Orange;
                lblstatus.ForeColor = System.Drawing.Color.White;
            }
            else if (lblstatus.Text == "OK")
            {
                GVInfo.Rows[i].Cells[5].BackColor = System.Drawing.Color.Green;
                lblstatus.ForeColor = System.Drawing.Color.White;
            }

        }
    }
    protected void GVInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVInfo.PageIndex = e.NewPageIndex;
        gridbind();
        txtbox.Visible = false;
    }
    protected void GVInfo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        lblmsg.Visible = false; ;
        btnapproval.Visible = true;
        lblMessage2.Visible = false;
        txtbox.Visible = true;
        long k;
        k = Convert.ToInt32(GVInfo.DataKeys[e.NewSelectedIndex].Value);
        i = Convert.ToInt32(GVInfo.DataKeys[e.NewSelectedIndex].Value);
        DataSet ds;
        string qry = string.Format("SELECT rtxno,smonth,syear,scurdate,storename,grbookno,grpageno,grdate,stockstatus, " +
                                          "lineid,linename,subdivid,subdiv,divid,division,firmid,firmname,pstclstore,goodstype, " +
                                          "stockrecddate,stockinspectdate,storechallanno,srwchallanDate,pono,podate,grpid,grgrphead,subgrpid,grsubgrphead,itemno,itype,itemcode,itemname, " +
                                          "unit,qtyrecd,qtyaccepted,rate,subtotal,edpercentage,cesspercentage,highereducesspercentage,total,cstvatpercentage,freight,insurance,field4,grandtotal, " +
                                          "empcode,empname,desg,stockrole,username,field7,field2,estimateno,estid,grtime,voucherno,voucherdate,make,remarks FROM stockreceipttable " +
                                            " where rtxno={0} "
                                            , k);

        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtgrno.Text = ds.Tables[0].Rows[0]["grbookno"].ToString();
            txtgrpageno.Text = ds.Tables[0].Rows[0]["grpageno"].ToString();
            txtgrdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["grdate"]).ToString("dd-MM-yyyy");
            ddstatustype.SelectedItem.Text = ds.Tables[0].Rows[0]["stockstatus"].ToString();
            if (ds.Tables[0].Rows[0]["stockstatus"].ToString() == "Work")
            {
                Tr15.Visible = false;
                Tr18.Visible = false;
                Tr20.Visible = true;
                Tr21.Visible = true;
                Tr22.Visible = true;
                ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["linename"].ToString();
                ddsubdiv.SelectedItem.Text = ds.Tables[0].Rows[0]["subdiv"].ToString();
                dddiv.SelectedItem.Text = ds.Tables[0].Rows[0]["division"].ToString();
            }
            else if (ds.Tables[0].Rows[0]["stockstatus"].ToString() == "Firm")
            {
                Tr20.Visible = false;
                Tr21.Visible = false;
                Tr22.Visible = false;
                Tr18.Visible = false;
                Tr15.Visible = true;
                ddfirm.SelectedItem.Text = ds.Tables[0].Rows[0]["firmname"].ToString();
            }
            else
            {
                Tr20.Visible = false;
                Tr21.Visible = false;
                Tr22.Visible = false;
                Tr15.Visible = false;
                Tr18.Visible = true;
                ddstore.SelectedItem.Text = ds.Tables[0].Rows[0]["pstclstore"].ToString();
            }
            ddstatus.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
            txtsrwno.Text = ds.Tables[0].Rows[0]["storechallanno"].ToString();
            txtsrwdate.Text = ds.Tables[0].Rows[0]["srwchallanDate"].ToString();
            txtpono.Text = ds.Tables[0].Rows[0]["pono"].ToString();
            txtpodate.Text = ds.Tables[0].Rows[0]["podate"].ToString();
            ddgrouphead.SelectedItem.Text = ds.Tables[0].Rows[0]["grgrphead"].ToString();
            ddsubgrp.SelectedItem.Text = ds.Tables[0].Rows[0]["grsubgrphead"].ToString();
            dditemtype.SelectedItem.Text = ds.Tables[0].Rows[0]["itype"].ToString();
            dditemname.SelectedItem.Text = ds.Tables[0].Rows[0]["itemname"].ToString();
            txtunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
            txtremarks.Text = ds.Tables[0].Rows[0]["remarks"].ToString();
            txtjvn.Text = ds.Tables[0].Rows[0]["voucherno"].ToString();
            txtjvdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["grdate"]).ToString("dd-MM-yyyy");
            if (ds.Tables[0].Rows[0]["make"].ToString() == "2")
            {
                ddjvstatus.SelectedItem.Text = "Amount Increase";
                txtcreditamt.Text = ds.Tables[0].Rows[0]["grandtotal"].ToString();
            }
            else if (ds.Tables[0].Rows[0]["make"].ToString() == "3")
            {
                ddjvstatus.SelectedItem.Text = "Amount Decrease";
                txtcreditamt.Text = Convert.ToString(Convert.ToDecimal(ds.Tables[0].Rows[0]["grandtotal"].ToString()) * (-1));
            }
        }
        ds.Clear();
        ds.Dispose();        
    }
    protected void GVInfo_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    private void showMsg(Label lbl, Color color, string msg)
    {
        lbl.ForeColor = color;
        lbl.Text = msg;
    }
    protected void btnapproval_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;
        string scmdText = " BEGIN ";
        scmdText += string.Format(" UPDATE stockreceipttable SET field2='{0}' " +
                                 " WHERE  rtxno={1} and grbookno = {2} and grpageno = {3} and voucherno = '{4}' "
                                  , "OK", i, Convert.ToInt32(txtgrno.Text), Convert.ToInt32(txtgrpageno.Text), txtjvn.Text);
        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        showMsg(lblmsg, Color.Red, "Successfully Approved!");
        txtbox.Visible = false;
        gridbind();
    }
    protected void btnCancel2_Click(object sender, EventArgs e)
    {
        txtbox.Visible = false;
    }
    protected void btsearch_Click(object sender, EventArgs e)
    {
        string qry;
        if (txtserjrno.Text == "" )
        {

            qry = string.Format("SELECT CASE WHEN make = '2' THEN grandtotal ELSE grandtotal*(-1) END as grandtotal,rtxno,voucherno,voucherdate,itemname,unit,field2 FROM stockreceipttable " +
                                      "where storename='{0}' and field7={1} and voucherno = '{2}' " +
                                      "order by field2 ,rtxno desc"
                                      , Session["StoreName"].ToString(), 2, "0");
        }
        else
        {
            qry = string.Format("SELECT CASE WHEN make = '2' THEN grandtotal ELSE grandtotal*(-1) END as grandtotal,rtxno,voucherno,voucherdate,itemname,unit,field2 FROM stockreceipttable " +
                                      "where storename='{0}' and field7={1} and voucherno = '{2}' " +
                                      "order by field2 ,rtxno desc"
                                      , Session["StoreName"].ToString(), 2, txtserjrno.Text);
        }
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    protected void btsearchcancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("StoreAEJVCredit.aspx");
    }
}