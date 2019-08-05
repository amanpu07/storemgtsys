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
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

public partial class Inventory_StoreAEJVDebit : System.Web.UI.Page
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
        string qry = string.Format("SELECT CASE WHEN projectcode = '2' THEN grandtotal ELSE grandtotal*(-1) END as grandtotal,itxno,voucherno,datevoucher,stockitemname,unit,ifield2 FROM stockissuetable " +
                                    "where ifield7=2 and issuetype='Voucher' and istore='{0}' " +
                                    " order by ifield2 desc,itxno desc "
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
        string qry = string.Format("SELECT itxno,issuetype,iyear,icurdate,istore,srchallanbookno,srchallanpageno,srchallandate,stockstatus, " +
                                              "lineid,linename,subdivid,nameofsubdivision,divid,nameofdivision,ifield9,transtorename,storename,goodstype, " +
                                              "storeindentno,storeindentdate,grpid,srgrphead,subgrpid,srsubgrphead,itemtypecode,stockitemyype,stockitemcode,stockitemname, " +
                                              "unit,qtyindented,issuedqty,qtyvalue,storagecharges,totalvalue,grandtotal, " +
                                              "userrole,username,ifield2,ifield7,srchtime,voucherno,datevoucher,projectcode,remarks FROM stockissuetable " +
                                                " where itxno={0} "
                                                , k);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
            {
                txtgrno.Text = ds.Tables[0].Rows[0]["srchallanbookno"].ToString();
                txtgrpageno.Text = ds.Tables[0].Rows[0]["srchallanpageno"].ToString();
                txtgrdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["srchallandate"]).ToString("dd-MM-yyyy");
                ddstatustype.SelectedItem.Text = ds.Tables[0].Rows[0]["stockstatus"].ToString();
                if (ds.Tables[0].Rows[0]["stockstatus"].ToString() == "Work")
                {
                    Tr15.Visible = false;
                    Tr18.Visible = false;
                    Tr20.Visible = true;
                    Tr21.Visible = true;
                    Tr22.Visible = true;
                    ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["linename"].ToString();
                    ddsubdiv.SelectedItem.Text = ds.Tables[0].Rows[0]["nameofsubdivision"].ToString();
                    dddiv.SelectedItem.Text = ds.Tables[0].Rows[0]["nameofdivision"].ToString();
                }
                else if (ds.Tables[0].Rows[0]["stockstatus"].ToString() == "Firm")
                {
                    Tr20.Visible = false;
                    Tr21.Visible = false;
                    Tr22.Visible = false;
                    Tr18.Visible = false;
                    Tr15.Visible = true;
                    ddfirm.SelectedItem.Text = ds.Tables[0].Rows[0]["transtorename"].ToString();
                }
                else
                {
                    Tr20.Visible = false;
                    Tr21.Visible = false;
                    Tr22.Visible = false;
                    Tr15.Visible = false;
                    Tr18.Visible = true;
                    ddstore.SelectedItem.Text = ds.Tables[0].Rows[0]["storename"].ToString();
                }
                ddstatus.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
                txtpono.Text = ds.Tables[0].Rows[0]["storeindentno"].ToString();
                txtpodate.Text = ds.Tables[0].Rows[0]["storeindentdate"].ToString();
                ddgrouphead.SelectedItem.Text = ds.Tables[0].Rows[0]["srgrphead"].ToString();
                ddsubgrp.SelectedItem.Text = ds.Tables[0].Rows[0]["srsubgrphead"].ToString();
                dditemtype.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemyype"].ToString();
                dditemname.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemname"].ToString();
                txtunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
                txtremarks.Text = ds.Tables[0].Rows[0]["remarks"].ToString();
                txtjvn.Text = ds.Tables[0].Rows[0]["voucherno"].ToString();
                txtjvdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["datevoucher"]).ToString("dd-MM-yyyy");
                if (ds.Tables[0].Rows[0]["projectcode"].ToString() == "2")
                {
                    ddjvstatus.SelectedItem.Text = "Amount Increase";
                    txtcreditamt.Text = ds.Tables[0].Rows[0]["grandtotal"].ToString();
                }
                else if (ds.Tables[0].Rows[0]["projectcode"].ToString() == "3")
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
        scmdText += string.Format(" UPDATE stockissuetable SET ifield2='{0}' " +
                                 " WHERE  itxno={1} and srchallanbookno = '{2}' and srchallanpageno = '{3}' and voucherno = '{4}' "
                                  , "OK", i, txtgrno.Text, txtgrpageno.Text, txtjvn.Text);
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
        if (txtserjrno.Text == "")
        {

            qry = string.Format("SELECT CASE WHEN projectcode = '2' THEN grandtotal ELSE grandtotal*(-1) END as grandtotal,itxno,voucherno,datevoucher,stockitemname,unit,ifield2 FROM stockissuetable " +
                                      "where istore='{0}' and ifield7={1} and voucherno = '{2}' " +
                                      "order by ifield2 ,itxno desc"
                                      , Session["StoreName"].ToString(), 2, "0");
        }
        else
        {
            qry = string.Format("SELECT CASE WHEN projectcode = '2' THEN grandtotal ELSE grandtotal*(-1) END as grandtotal,itxno,voucherno,datevoucher,stockitemname,unit,ifield2 FROM stockissuetable " +
                                      "where istore='{0}' and ifield7={1} and voucherno = '{2}' " +
                                      "order by ifield2 ,itxno desc"
                                      , Session["StoreName"].ToString(), 2, txtserjrno.Text);
        }
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    protected void btsearchcancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("StoreAEJVDebit.aspx");
    }
}