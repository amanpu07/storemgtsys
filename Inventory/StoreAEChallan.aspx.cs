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

public partial class Inventory_StoreAEChallan : System.Web.UI.Page
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
        string qry = string.Format("SELECT itxno,srchallanbookno,srchallanpageno,srchallandate,stockitemname,firm,grandtotal,ifield2 from dbo.stockissuetable " +
                                    "where issuetype='CHALLAN' and ifield7=2 and istore ='{0}' " +
                                    " order by ifield2 desc,itxno desc "
                                    , Session["StoreName"].ToString());
        DBConnection.fillGridView(ref GVChallanInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    private void showMsg(Label lbl, Color color, string msg)
    {
        lbl.ForeColor = color;
        lbl.Text = msg;
    }
    protected void btsearch_Click(object sender, EventArgs e)
    {
        string qry;
        if (txtserbook.Text == "" || txtserpage.Text == "")
        {

            qry = string.Format("SELECT itxno,srchallanbookno,srchallanpageno,srchallandate,stockitemname,unit,grandtotal,ifield2 FROM stockissuetable " +
                                      "where istore='{0}' and ifield7={1} and srchallanbookno = '{2}' and srchallanpageno = '{3}' " +
                                      "order by ifield2 ,itxno desc"
                                      , Session["StoreName"].ToString(), 2, "0", "0");
        }
        else
        {
            qry = string.Format("SELECT itxno,srchallanbookno,srchallanpageno,srchallandate,stockitemname,unit,grandtotal,ifield2 FROM stockissuetable " +
                                      "where istore='{0}' and ifield7={1} and srchallanbookno = '{2}' and srchallanpageno = '{3}' " +
                                      "order by ifield2 ,itxno desc"
                                      , Session["StoreName"].ToString(), 2, txtserbook.Text, txtserpage.Text);
        }
        DBConnection.fillGridView(ref GVChallanInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    protected void btsearchcancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("StoreAEChallan.aspx");
    }
    protected void btnapproval_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;
        string scmdText = " BEGIN ";
        scmdText += string.Format(" UPDATE stockissuetable SET ifield2='{0}' " +
                                 " WHERE  itxno={1} and srchallanbookno = '{2}' and srchallanpageno = '{3}' "
                                  , "OK", i, txtchalbookno.Text, txtchalpageno.Text);
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
    protected void GVChallanInfo_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i <= GVChallanInfo.Rows.Count - 1; i++)
        {
            Label lblstatus = (Label)GVChallanInfo.Rows[i].FindControl("lblgridStatus");
            lblstatus.Font.Bold = true;

            if (lblstatus.Text == "Pending")
            {
                GVChallanInfo.Rows[i].Cells[5].BackColor = System.Drawing.Color.Orange;
                lblstatus.ForeColor = System.Drawing.Color.White;
            }
            else if (lblstatus.Text == "OK")
            {
                GVChallanInfo.Rows[i].Cells[5].BackColor = System.Drawing.Color.Green;
                lblstatus.ForeColor = System.Drawing.Color.White;
            }
        }
    }
    protected void GVChallanInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVChallanInfo.PageIndex = e.NewPageIndex;
        gridbind();
        txtbox.Visible = false;
    }
    protected void GVChallanInfo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        lblmsg.Visible = false; ;
        btnapproval.Visible = true;
        lblMessage2.Visible = false;
        txtbox.Visible = true;
        long k;
        k = Convert.ToInt32(GVChallanInfo.DataKeys[e.NewSelectedIndex].Value);
        i = Convert.ToInt32(GVChallanInfo.DataKeys[e.NewSelectedIndex].Value);
        DataSet ds;
        string qry = string.Format("SELECT itxno,issuetype,istore,icurdate,srchallanbookno,srchallanpageno,srchallandate,srchtime,subdivid,nameofsubdivision,divid,nameofdivision, " +
                                              "lineid,linename,grpid,srgrphead,subgrpid,srsubgrphead,itemtypecode,stockitemyype,stockitemcode,stockitemname,goodstype,unit,qtyindented, " +
                                              " issuedqty,qtyvalue,storagecharges,totalvalue,grandtotal,storeindentno,storeindentdate,storename,itemrecdempcode,recdempname,designation,stockstatus, " +
                                              "ifield9,transtorename,userrole,username,ifield2,ifield7 FROM stockissuetable " +
                                              " where itxno={0} "
                                              , k);

        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtchalbookno.Text = ds.Tables[0].Rows[0]["srchallanbookno"].ToString();
            txtchalpageno.Text = ds.Tables[0].Rows[0]["srchallanpageno"].ToString();
            txtchaldate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["srchallandate"]).ToString("dd-MM-yyyy");
            //ddstatustype.SelectedItem.Text = ds.Tables[0].Rows[0]["stockstatus"].ToString();
            //if (ds.Tables[0].Rows[0]["stockstatus"].ToString() == "Work")
            //{
            //    Tr15.Visible = false;
            //    Tr18.Visible = false;
            //    Tr20.Visible = true;
            //    Tr21.Visible = true;
            //    Tr22.Visible = true;
            //    ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["linename"].ToString();
            //    ddsubdiv.SelectedItem.Text = ds.Tables[0].Rows[0]["nameofsubdivision"].ToString();
            //    dddiv.SelectedItem.Text = ds.Tables[0].Rows[0]["nameofdivision"].ToString();
            //}
            //else if (ds.Tables[0].Rows[0]["stockstatus"].ToString() == "Firm")
            //{
            //    Tr20.Visible = false;
            //    Tr21.Visible = false;
            //    Tr22.Visible = false;
            //    Tr18.Visible = false;
            //    Tr15.Visible = true;
            //    ddfirm.SelectedItem.Text = ds.Tables[0].Rows[0]["transtorename"].ToString();
            //}
            //else
            //{
            //    Tr20.Visible = false;
            //    Tr21.Visible = false;
            //    Tr22.Visible = false;
            //    Tr15.Visible = false;
                Tr18.Visible = true;
                ddstore.SelectedItem.Text = ds.Tables[0].Rows[0]["storename"].ToString();
            //}
            ddstatus.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
            txtstoindentno.Text = ds.Tables[0].Rows[0]["storeindentno"].ToString();
            txtstoindentdate.Text = ds.Tables[0].Rows[0]["storeindentdate"].ToString();
            ddgrouphead.SelectedItem.Text = ds.Tables[0].Rows[0]["srgrphead"].ToString();
            ddsubgrp.SelectedItem.Text = ds.Tables[0].Rows[0]["srsubgrphead"].ToString();
            dditemtype.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemyype"].ToString();
            dditemname.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemname"].ToString();
            txtunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
            txtqtyreq.Text = ds.Tables[0].Rows[0]["qtyindented"].ToString();
            txtqtyissued.Text = ds.Tables[0].Rows[0]["issuedqty"].ToString();
            txtrate.Text = ds.Tables[0].Rows[0]["qtyvalue"].ToString();
            txttotal.Text = ds.Tables[0].Rows[0]["totalvalue"].ToString();
            txtstorage.Text = ds.Tables[0].Rows[0]["storagecharges"].ToString();
            txtgrandtotal.Text = ds.Tables[0].Rows[0]["grandtotal"].ToString();
            txtempcode.Text = ds.Tables[0].Rows[0]["itemrecdempcode"].ToString();
            txtempname.Text = ds.Tables[0].Rows[0]["recdempname"].ToString();
            txtdesg.Text = ds.Tables[0].Rows[0]["designation"].ToString();
        }
        ds.Clear();
        ds.Dispose();        
    }
    protected void GVChallanInfo_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}