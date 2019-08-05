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

public partial class Inventory_StoreJESRW : System.Web.UI.Page
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
            calculateValues();
            grouphead();
            subgrouphead();
            DDLine();
            DDSubDiv();
            DDDiv();
            DDGoodsType();
            DDTypebind();
            DDNameItembind();
            txtunitbind();
            Label2.Visible = false;
            Label3.Visible = false;
        }
        lblaeeremarks.Visible = false;
    }
    private void gridbind()
    {
        string qry = string.Format("SELECT rtxno,subdiv,storechallanno,srwchallandate,grpageno,grbookno,grdate,itemname,unit,grandtotal,field2,qtyrecd FROM stockreceipttable " +
                                    "where field7=1 and smonth='GRSRW' and storename='{0}'  and subdivstatus='{1}' " +
                                    " order by field2 desc,rtxno desc "
                                    , Session["StoreName"].ToString(),"OK");
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    private void grouphead()
    {
        DataSet ds;
        string qry = string.Format("SELECT groupid, (accategory + debitac) debit from MasterGroup where groupid = 0  union all  SELECT groupid,accategory + ' ('  + debitac + ')' as debit  FROM MasterGroup " +
                                   "where groupid <> 0 and status=3 order by groupid");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' groupid, 'NIL' debit";
            ds = DBConnection.fillDataSet(qry);
        }
        ddgrouphead.DataTextField = ds.Tables[0].Columns["debit"].ToString();
        ddgrouphead.DataValueField = ds.Tables[0].Columns["groupid"].ToString();
        ddgrouphead.DataSource = ds.Tables[0];
        ddgrouphead.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void subgrouphead()
    {
        DataSet ds;
        string qry = string.Format("SELECT subgroupid,case when subgrouphead = '' then credit  else subgrouphead + ' ('  + credit + ')' end as credit  FROM MasterSubGroupHead " +
                                    " where subgroupid <> 1 and status=103 and groupid={0} " +
                                    "order by subgroupid"
                                    , ddgrouphead.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' subgroupid, 'NIL' credit";
            ds = DBConnection.fillDataSet(qry);
        }
        ddsubgrp.DataTextField = ds.Tables[0].Columns["credit"].ToString();
        ddsubgrp.DataValueField = ds.Tables[0].Columns["subgroupid"].ToString();
        ddsubgrp.DataSource = ds.Tables[0];
        ddsubgrp.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDLine()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("SELECT distinct Lineid,LineName from stockissuetable" +
                                   " where ifield2='{0}' and istore='{1}' " +
                                   "order by LineName"
                                    , "OK", Session["StoreName"].ToString());
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' Lineid, 'NIL' LineName";
            ds = DBConnection.fillDataSet(qry);
        }
        ddline.DataTextField = ds.Tables[0].Columns["LineName"].ToString();
        ddline.DataValueField = ds.Tables[0].Columns["Lineid"].ToString();
        ddline.DataSource = ds.Tables[0];
        ddline.DataBind();
        ds.Clear();
        ds.Dispose();
    }
   
   
    private void DDSubDiv()
    {
        if (ddline.SelectedItem.Text == "NIL")
        {
            ddsubdiv.SelectedItem.Text = "NIL";
            //dditemname.SelectedValue = "NIL";
        }
        else
        {
            // System.Threading.Thread.Sleep(5000);
            DataSet ds;

            string qry = string.Format("SELECT subdivisionid,subdivisionname from LineMaster" +
                                       " where Estatus='{0}' and Lineid = {1} " +
                                       "order by LineName"
                                        , "OK", ddline.SelectedValue);
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count == 0)
            {
                // ds.Clear();
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
    }
    private void DDDiv()
    {
        if (ddline.SelectedItem.Text == "NIL")
        {
            ddsubdiv.SelectedItem.Text = "NIL";
            //dditemname.SelectedValue = "NIL";
        }
        else
        {
            // System.Threading.Thread.Sleep(5000);
            DataSet ds;

            string qry = string.Format("SELECT divid,divisonname from LineMaster" +
                                       " where Estatus='{0}' and Lineid = {1} " +
                                       "order by LineName"
                                        , "OK", ddline.SelectedValue);
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
    }

    private void DDGoodsType()
    {
        //  System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("SELECT goodsid,goodsstatus from MasterGoodsStatus");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' goodsid, 'NIL' goodsstatus";
            ds = DBConnection.fillDataSet(qry);
        }
        ddstatus.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
        ddstatus.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
        ddstatus.DataSource = ds.Tables[0];
        ddstatus.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDTypebind()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("Select distinct itype,typecode  from MASTINVENTORY order by itype");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' itype,'NIL' typecode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemtype.DataTextField = ds.Tables[0].Columns["itype"].ToString();
        dditemtype.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype.DataSource = ds.Tables[0];
        dditemtype.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDNameItembind()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("Select  iname,icode  from mastinventory" +
                                   " where typecode='{0}' " +
                                   " order by iname"
                                    , dditemtype.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' iname, 'NIL' icode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemname.DataTextField = ds.Tables[0].Columns["iname"].ToString();
        dditemname.DataValueField = ds.Tables[0].Columns["icode"].ToString();
        dditemname.DataSource = ds.Tables[0];
        dditemname.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void txtunitbind()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("Select  field1 from mastinventory" +
                                   " where icode='{0}'"
                                    , dditemname.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' field1";
            ds = DBConnection.fillDataSet(qry);
        }
        txtunit.Text = ds.Tables[0].Rows[0]["field1"].ToString();
        ds.Clear();
        ds.Dispose();
    }
  
    private void calculateValues()
    {
        if (txtrquantity.Text == "")
        {
            txtrquantity.Text = "0.000";
        }
        if (txtrvalue.Text == "")
        {
            txtrvalue.Text = "0.000";
        }
        if (txtrate.Text == "")
        {
            txtrate.Text = "0.00";
        }
        if (txtsubtotal.Text == "")
        {
            txtsubtotal.Text = "0.00";
        }
        if (txted.Text == "")
        {
            txted.Text = "0.00";
        }
        if (txtcess.Text == "")
        {
            txtcess.Text = "0.00";
        }
        if (txtheducess.Text == "")
        {
            txtheducess.Text = "0.00";
        }
        if (txttotal.Text == "")
        {
            txttotal.Text = "0.00";
        }
        if (txtvat.Text == "")
        {
            txtvat.Text = "0.00";
        }
        if (txtfreight.Text == "")
        {
            txtfreight.Text = "0.00";
        }

        if (txtprcvar.Text == "")
        {
            txtprcvar.Text = "0.00";
        }

        if (txtgrandtotal.Text == "")
        {
            txtgrandtotal.Text = "0.00";
        }

        Decimal d2, d3, d4, d5, d6;
        //Calculate Subtotal
        txtsubtotal.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Convert.ToDecimal(txtrvalue.Text) * Convert.ToDecimal(txtrate.Text))));
        //Calculate Total
        d2 = Math.Round((Convert.ToDecimal(txtsubtotal.Text) * Convert.ToDecimal(txted.Text)) / 100); // calculate excise duty
        d3 = Math.Round(((Convert.ToDecimal(txtsubtotal.Text) * Convert.ToDecimal(txted.Text)) / 100 * Convert.ToDecimal(txtcess.Text)) / 100); // calculate cess
        d4 = Math.Round(((Convert.ToDecimal(txtsubtotal.Text) * Convert.ToDecimal(txted.Text)) / 100 * Convert.ToDecimal(txtheducess.Text)) / 100); // calculate highed edu cess
        d5 = Convert.ToDecimal(txtsubtotal.Text) + d2 + d3 + d4;
        txttotal.Text = Convert.ToString(Math.Round(d5));
        //Calculate Grand Total
        d6 = Math.Round((Convert.ToDecimal(txttotal.Text) * Convert.ToDecimal(txtvat.Text)) / 100); // calculate vat
        txtgrandtotal.Text = Convert.ToString(Math.Round((Convert.ToDecimal(txttotal.Text) + (Convert.ToDecimal(txttotal.Text) * Convert.ToDecimal(txtvat.Text)) / 100 + Convert.ToDecimal(txtfreight.Text) + Convert.ToDecimal(txtprcvar.Text))));

    }
    private void clear()
    {
        txtrquantity.Text = "0.000";
        txtrvalue.Text = "0.000";
        txtrate.Text = "0.00";
        txtsubtotal.Text = "0.00";
        txted.Text = "0.00";
        txtcess.Text = "0.00";
        txtheducess.Text = "0.00";
        txttotal.Text = "0.00";
        txtvat.Text = "0.00";
        txtfreight.Text = "0.00";
        txtgrandtotal.Text = "0.00";
        txtprcvar.Text = "0.00";
        grouphead();
        subgrouphead();
        DDGoodsType();
        DDTypebind();
        DDNameItembind();
        txtunitbind();
    }
    private void allclear()
    {
        //txtgrno.Text = "";
        //txtgrpageno.Text = "";
        //txtgrdate.Text = "dd-mm-yyyy";
        txtsrwdate.Text = "dd-mm-yyyy";
        txtreceiptdate.Text = "dd-mm-yyyy";
        txtinspectdate.Text = "dd-mm-yyyy";
        txtsrwno.Text = "";
        txtpono.Text = "";
        txtpodate.Text = "";
        txtrquantity.Text = "0.000";
        txtrvalue.Text = "0.000";
        txtrate.Text = "0.00";
        txtsubtotal.Text = "0.00";
        txted.Text = "0.00";
        txtcess.Text = "0.00";
        txtheducess.Text = "0.00";
        txttotal.Text = "0.00";
        txtvat.Text = "0.00";
        txtfreight.Text = "0.00";
        txtgrandtotal.Text = "0.00";
        txtprcvar.Text = "0.00";
        grouphead();
        subgrouphead();
        DDGoodsType();
        DDTypebind();
        DDNameItembind();
        txtunitbind();
    }
    private void readonlytext()
    {
        ddline.Enabled = false;
       // ddsubgrp.Enabled = false;
       // ddgrouphead.Enabled = false;
        dditemtype.Enabled = false;
        dditemname.Enabled = false;
        txtunit.ReadOnly = true;
        ddstatus.Enabled = false;
    }

    private void unreadonlytext()
    {
        ddline.Enabled = true;
       // ddsubgrp.Enabled = true;
       // ddgrouphead.Enabled = true;
        dditemtype.Enabled = true;
        dditemname.Enabled = true;
        txtunit.ReadOnly = false;
        ddstatus.Enabled = true;
    }
    private void showMsg(Label lbl, Color color, string msg)
    {
        lbl.ForeColor = color;
        lbl.Text = msg;
    }
    protected void GVInfo_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void GVInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVInfo.PageIndex = e.NewPageIndex;
        gridbind();
        txtbox.Visible = false;
    }
    
    protected void GVInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GVInfo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GVInfo_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        lblMessage2.Visible = false;
        btndel.Visible = false;
        btnapproval.Visible = false;
        txtbox.Visible = true;
        Proceed.Text = "Save";
        allclear();
        calculateValues();
        unreadonlytext();
    }
    protected void btCancel1_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePageStoreJE.aspx?F=0");
    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;

        if (Proceed.Text == "Save")
        {
            DataSet ds;
            string qry = string.Format("select grbookno,grpageno,grdate,goodstype,itemcode,itemname from stockreceipttable " +
                                       " where grbookno={0} and grpageno={1} and itemcode='{2}' and goodstype='{3}' and storename='{4}' " +
                                       " and smonth = '{5}' "
                                        , Convert.ToInt32(txtgrno.Text), Convert.ToInt32(txtgrpageno.Text), dditemname.SelectedValue, ddstatus.SelectedItem.Text, Session["StoreName"].ToString(), "GRSRW");
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (txtgrno.Text == ds.Tables[0].Rows[0]["grbookno"].ToString() && txtgrpageno.Text == ds.Tables[0].Rows[0]["grpageno"].ToString() && dditemname.SelectedValue == ds.Tables[0].Rows[0]["itemcode"].ToString() && ddstatus.SelectedItem.Text == ds.Tables[0].Rows[0]["goodstype"].ToString())
                {
                    showMsg(lblmsg, Color.Red, "Record already Exits!");
                }

                ds.Clear();
                ds.Dispose();
            }
            else
            {
                if (dditemtype.SelectedItem.Text == "....")
                {
                    Label2.Visible = true;
                    // ClientScript.RegisterClientScriptBlock(this.GetType(), "ddd", "<script>alert('Select Item Type')</script>");
                    showMsg(Label2, Color.Red, "Select Item Type!");
                    return;
                }
                else if (ddgrouphead.SelectedItem.Text == "....")
                {
                    Label3.Visible = true;
                    // ClientScript.RegisterClientScriptBlock(this.GetType(), "ddd", "<script>alert('Select Item Type')</script>");
                    showMsg(Label3, Color.Red, "Select Debit!");
                    return;
                }
               
                else
                {

                    string scmdText = " BEGIN ";
                    DateTime grdate = new DateTime();
                    DateTime sysdate = new DateTime();
                    string sysTime = (System.DateTime.Now).ToString("HH:mm:ss");
                    grdate = Convert.ToDateTime(txtgrdate.Text);
                    sysdate = Convert.ToDateTime((System.DateTime.Now).ToString("dd-MM-yyyy"));
                    String srchdate, systemdate;
                    srchdate = grdate.ToString("yyyy-MM-dd");
                    systemdate = sysdate.ToString("yyyy-MM-dd");
                    scmdText += string.Format("Insert into stockreceipttable (smonth,syear,scurdate,storename,grbookno,grpageno,grdate,stockstatus, " +
                                              "lineid,linename,subdivid,subdiv,divid,division,firmid,firmname,pstclstore,goodstype, " +
                                              "stockrecddate,stockinspectdate,storechallanno,srwchallanDate,pono,podate,grpid,grgrphead,subgrpid,grsubgrphead,itemno,itype,itemcode,itemname, " +
                                              "unit,qtyrecd,qtyaccepted,rate,subtotal,edpercentage,cesspercentage,highereducesspercentage,total,cstvatpercentage,freight,insurance,field4,grandtotal, " +
                                              "empcode,empname,desg,stockrole,username,field7,field2,estimateno,estid,grtime)" +
                                              " VALUES ( '{0}' ,'{1}','{2}','{3}',{4},{5},'{6}','{7}', " +
                                              " {8},'{9}', {10},'{11}', {12},'{13}', {14},'{15}','{16}','{17}', " +
                                              " '{18}','{19}','{20}','{21}','{22}','{23}',{24},'{25}',{26},'{27}',{28},'{29}','{30}','{31}', " +
                                              " '{32}',{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45}, " +
                                              " '{46}','{47}','{48}','{49}','{50}',{51},'{52}','{53}',{54},'{55}' ) "
                                              , "GRSRW", "", systemdate, Session["StoreName"], Convert.ToInt32(txtgrno.Text), Convert.ToInt32(txtgrpageno.Text), srchdate, "Work",
                                                ddline.SelectedValue, ddline.SelectedItem.Text, ddsubdiv.SelectedValue, ddsubdiv.SelectedItem.Text, dddiv.SelectedValue, dddiv.SelectedItem.Text, 100000, "NA", "NA", ddstatus.SelectedItem.Text,
                                              txtreceiptdate.Text, txtinspectdate.Text, txtsrwno.Text, txtsrwdate.Text, txtpono.Text, txtpodate.Text, ddgrouphead.SelectedValue, ddgrouphead.SelectedItem.Text, ddsubgrp.SelectedValue, ddsubgrp.SelectedItem.Text, dditemtype.SelectedValue, dditemtype.SelectedItem.Text, dditemname.SelectedValue, dditemname.SelectedItem.Text,
                                             txtunit.Text, Convert.ToDecimal(txtrquantity.Text), Convert.ToDecimal(txtrvalue.Text), Convert.ToDecimal(txtrate.Text), Convert.ToDecimal(Convert.ToDecimal(txtrvalue.Text) * Convert.ToDecimal(txtrate.Text)), Convert.ToDecimal(txted.Text), Convert.ToDecimal(txtcess.Text), Convert.ToDecimal(txtheducess.Text), Convert.ToDecimal(txttotal.Text), Convert.ToDecimal(txtvat.Text), Convert.ToDecimal(txtfreight.Text), 0.00, Convert.ToDecimal(txtprcvar.Text), Convert.ToDecimal(txtgrandtotal.Text),
                                              txtempcode.Text, txtempname.Text, txtdesg.Text, Session["RoleN"].ToString(), Session["UI"].ToString(), 1, "Pending", "", 0, sysTime);


                    scmdText += " END ";
                    DBConnection.executeNonQuery(scmdText);
                    showMsg(lblmsg, Color.Red, "Saved Successfully!");
                    Label2.Visible = false;
                    Label3.Visible = false;
                   // Label4.Visible = false;
                }
            }
        }
        else if (Proceed.Text == "Update")
        {
            string scmdText = " BEGIN ";
            DateTime grdate = new DateTime();
            DateTime sysdate = new DateTime();
            string sysTime = (System.DateTime.Now).ToString("HH:mm:ss");
            grdate = Convert.ToDateTime(txtgrdate.Text);
            sysdate = Convert.ToDateTime((System.DateTime.Now).ToString("dd-MM-yyyy"));
            String srchdate, systemdate;
            srchdate = grdate.ToString("yyyy-MM-dd");
            systemdate = sysdate.ToString("yyyy-MM-dd");
            scmdText += string.Format(" UPDATE stockreceipttable SET grbookno = {0}, grpageno = {1}, grdate = '{2}',stockrecddate = '{3}',stockinspectdate = '{4}', " +
                                      " storechallanno = '{5}',srwchallanDate = '{6}',pono = '{7}',podate = '{8}', qtyrecd = {9} ,qtyaccepted = {10} ,rate = {11}, " +
                                      " edpercentage = {12} ,cesspercentage = {13} ,highereducesspercentage = {14} ,cstvatpercentage = {15} ,freight = {16}, " +
                                      " field4 = {17} ,empcode = '{18}',empname = '{19}',desg = '{20}', subtotal = {21}, total = {22}, grandtotal = {23} " +
                                      " WHERE rtxno = {24} "
                                          , Convert.ToInt32(txtgrno.Text), Convert.ToInt32(txtgrpageno.Text), srchdate, txtreceiptdate.Text, txtinspectdate.Text,
                                          txtsrwno.Text, txtsrwdate.Text, txtpono.Text, txtpodate.Text, Convert.ToDecimal(txtrquantity.Text),
                                          Convert.ToDecimal(txtrvalue.Text), Convert.ToDecimal(txtrate.Text), Convert.ToDecimal(txted.Text), Convert.ToDecimal(txtcess.Text),
                                          Convert.ToDecimal(txtheducess.Text), Convert.ToDecimal(txtvat.Text), Convert.ToDecimal(txtfreight.Text),
                                          Convert.ToDecimal(txtprcvar.Text), txtempcode.Text, txtempname.Text, txtdesg.Text, Convert.ToDecimal(Convert.ToDecimal(txtrvalue.Text) * Convert.ToDecimal(txtrate.Text)), Convert.ToDecimal(txttotal.Text), Convert.ToDecimal(txtgrandtotal.Text), i);
            scmdText += " END ";
            DBConnection.executeNonQuery(scmdText);
            showMsg(lblmsg, Color.Red, "Updated Successfully!");
            txtbox.Visible = false;
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
    protected void btnCancel2_Click(object sender, EventArgs e)
    {
        txtbox.Visible = false;
        can.Visible = false;
      //  unreadonlytext();
        lblMessage2.Visible = false;
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        lblMessage2.Visible = false;
        allclear();
        btndel.Visible = false;
        btnapproval.Visible = false;
        Proceed.Text = "Save";
        unreadonlytext();
        can.Visible = true;
    }
    protected void btnapproval_Click(object sender, EventArgs e)
    {
        if (ddgrouphead.SelectedItem.Text == "....")
        {
            Label3.Visible = true;
            // ClientScript.RegisterClientScriptBlock(this.GetType(), "ddd", "<script>alert('Select Item Type')</script>");
            showMsg(Label3, Color.Red, "Select Group Head!");
            return;
        }

        else
        {
            lblmsg.Visible = true;
            string scmdText = " BEGIN ";
            DateTime grdate = new DateTime();
            DateTime sysdate = new DateTime();
            string sysTime = (System.DateTime.Now).ToString("HH:mm:ss");
            grdate = Convert.ToDateTime(txtgrdate.Text);
            sysdate = Convert.ToDateTime((System.DateTime.Now).ToString("dd-MM-yyyy"));
            String srchdate, systemdate;
            srchdate = grdate.ToString("yyyy-MM-dd");
            systemdate = sysdate.ToString("yyyy-MM-dd");
            scmdText += string.Format(" UPDATE stockreceipttable SET field7={0},grbookno = {1}, grpageno = {2},grdate = '{3}',stockrecddate = '{4}',stockinspectdate = '{5}', " +
                                    "grpid = {6},grgrphead = '{7}',subgrpid = {8},grsubgrphead = '{9}',qtyaccepted = {10},rate = {11}, total = {12},freight = {13}, " +
                                    "field4 = {14},grandtotal = {15}, empcode = '{16}',empname = '{17}',desg = '{18}'" +
                                    "WHERE  rtxno={19} "
                                      , 2, Convert.ToInt32(txtgrno.Text), Convert.ToInt32(txtgrpageno.Text), srchdate, txtreceiptdate.Text, txtinspectdate.Text,
                                      ddgrouphead.SelectedValue, ddgrouphead.SelectedItem.Text, ddsubgrp.SelectedValue, ddsubgrp.SelectedItem.Text, Convert.ToDecimal(txtrvalue.Text), Convert.ToDecimal(txtrate.Text), Convert.ToDecimal(txttotal.Text), Convert.ToDecimal(txtfreight.Text),
                                       Convert.ToDecimal(txtprcvar.Text), Convert.ToDecimal(txtgrandtotal.Text), txtempcode.Text, txtempname.Text, txtdesg.Text,
                                      i);
            scmdText += " END ";
            DBConnection.executeNonQuery(scmdText);
            showMsg(lblmsg, Color.Red, "Successfully Sent for Approval!");
            txtbox.Visible = false;
            gridbind();
            clear();
        }
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;
        unreadonlytext();
        DataSet ds;
        string qry = string.Format(" delete from stockreceipttable " +
                                   " where rtxno={0} and grbookno = {1} and grpageno = {2} "
                                    , i, Convert.ToInt32(txtgrno.Text), Convert.ToInt32(txtgrpageno.Text));
        ds = DBConnection.fillDataSet(qry);
        ds.Clear();
        ds.Dispose();
        gridbind();
        lblMessage2.Text = "[Data Delete Successfully.]";
        lblMessage2.Visible = true;
        txtbox.Visible = false;
        can.Visible = true;
    }
    //protected void txtrquantity_TextChanged(object sender, EventArgs e)
    //{
    //    calculateValues();
    //}
    protected void txtrvalue_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
    protected void txtrate_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
    protected void txted_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
    protected void txtcess_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
    protected void txtheducess_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
    protected void txtvat_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
    protected void txtfreight_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
    protected void txtprcvar_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
    protected void ddgrouphead_SelectedIndexChanged(object sender, EventArgs e)
    {
        subgrouphead();
    }
    protected void dditemtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind();
        txtunitbind();
    }
    protected void dditemname_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtunitbind();
    }
    
    protected void ddline_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDDiv();
        DDSubDiv();
    }
    protected void GVInfo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
            lblmsg.Visible = false;
            btndel.Visible = false;
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
                                              "empcode,empname,desg,stockrole,username,field7,field2,estimateno,estid,grtime FROM stockreceipttable " +
                                                " where rtxno={0} "
                                                , k);

            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtgrno.Text = ds.Tables[0].Rows[0]["grbookno"].ToString();
                txtgrpageno.Text = ds.Tables[0].Rows[0]["grpageno"].ToString();
                txtgrdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["grdate"]).ToString("dd-MM-yyyy");
                Tr20.Visible = true;
                Tr21.Visible = true;
                Tr22.Visible = true;
                ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["linename"].ToString();
                ddsubdiv.SelectedItem.Text = ds.Tables[0].Rows[0]["subdiv"].ToString();
                dddiv.SelectedItem.Text = ds.Tables[0].Rows[0]["division"].ToString();

                ddstatus.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
                txtreceiptdate.Text = ds.Tables[0].Rows[0]["stockrecddate"].ToString();
                txtinspectdate.Text = ds.Tables[0].Rows[0]["stockinspectdate"].ToString();
                txtsrwno.Text = ds.Tables[0].Rows[0]["storechallanno"].ToString();
                txtsrwdate.Text = ds.Tables[0].Rows[0]["srwchallanDate"].ToString();
                txtpono.Text = ds.Tables[0].Rows[0]["pono"].ToString();
                txtpodate.Text = ds.Tables[0].Rows[0]["podate"].ToString();
                // ddgrouphead.SelectedItem.Text = ds.Tables[0].Rows[0]["grgrphead"].ToString();
                // ddsubgrp.SelectedItem.Text = ds.Tables[0].Rows[0]["grsubgrphead"].ToString();
                dditemtype.SelectedItem.Text = ds.Tables[0].Rows[0]["itype"].ToString();
                dditemname.SelectedItem.Text = ds.Tables[0].Rows[0]["itemname"].ToString();
                txtunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
                txtrquantity.Text = ds.Tables[0].Rows[0]["qtyrecd"].ToString();
                txtrvalue.Text = ds.Tables[0].Rows[0]["qtyaccepted"].ToString();
                txtrate.Text = ds.Tables[0].Rows[0]["rate"].ToString();
                txtsubtotal.Text = ds.Tables[0].Rows[0]["subtotal"].ToString();
                txted.Text = ds.Tables[0].Rows[0]["edpercentage"].ToString();
                txtcess.Text = ds.Tables[0].Rows[0]["cesspercentage"].ToString();
                txtheducess.Text = ds.Tables[0].Rows[0]["highereducesspercentage"].ToString();
                txttotal.Text = ds.Tables[0].Rows[0]["total"].ToString();
                txtvat.Text = ds.Tables[0].Rows[0]["cstvatpercentage"].ToString();
                txtfreight.Text = ds.Tables[0].Rows[0]["freight"].ToString();
                txtprcvar.Text = ds.Tables[0].Rows[0]["field4"].ToString();
                txtgrandtotal.Text = ds.Tables[0].Rows[0]["grandtotal"].ToString();
                txtempcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
                txtempname.Text = ds.Tables[0].Rows[0]["empname"].ToString();
                txtdesg.Text = ds.Tables[0].Rows[0]["desg"].ToString();
                ddestimate.SelectedItem.Text = ds.Tables[0].Rows[0]["estimateno"].ToString();
                txtgrno.Text = "";
                txtgrpageno.Text = "";
                txtgrdate.Text = "dd-mm-yyyy";
                txtreceiptdate.Text = "dd-mm-yyyy";
                txtinspectdate.Text = "dd-mm-yyyy";
            }
            ds.Clear();
            ds.Dispose();
            Proceed.Text = "Update";
            can.Visible = false;
            readonlytext();
            grouphead();
            subgrouphead();
        
    }
}