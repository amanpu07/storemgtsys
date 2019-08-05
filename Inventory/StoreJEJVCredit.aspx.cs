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
public partial class Inventory_StoreJEJVCredit : System.Web.UI.Page
{
    static long i;
    decimal crdamt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["StoreName"] == null || Session["UI"] == null)
        {
            Response.Redirect("../Home/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            Tr20.Visible = false;
            Tr21.Visible = false;
            Tr22.Visible = false;
            Tr15.Visible = false;
            Tr18.Visible = false;
            gridbind();
            txtbox.Visible = false;
            DDStatusType();           
            DDLine();
            DDSubDiv();
            DDDiv();
            DDFirm();
            DDAllStore();
            DDGoodsType();
            DDTypebind();
            DDNameItembind();
            txtunitbind();            
            grouphead();
            subgrouphead();
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            DDJVStatus();
        }
        lblaeeremarks.Visible = false;
    }
    private void gridbind()
    {
        string qry = string.Format("SELECT CASE WHEN make = '2' THEN grandtotal ELSE grandtotal*(-1) END as grandtotal,rtxno,voucherno,voucherdate,itemname,unit,field2 FROM stockreceipttable " +
                                    "where field7=1 and smonth='Voucher' and storename='{0}' " +
                                    " order by field2 desc,rtxno desc "
                                    , Session["StoreName"].ToString());
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
      private void grouphead()
    {
        DataSet ds;
        string qry = string.Format("SELECT groupid, (accategory + debitac) debit from MasterGroup where groupid = 0  union all  SELECT groupid,case when accategory = '' then debitac else accategory + ' ('  + debitac + ')' end as debit  FROM MasterGroup " +
                                   "where groupid <> 0 and status in (1,2,3) order by groupid");
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
                                    " where subgroupid <> 1 and status in (101,102,103) and groupid={0} " +
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
    private void DDFirm()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("SELECT firmid,firmname from MasterFirm" +
                                   " where storename='{0}' and Status='{1}' " +
                                   "order by firmname"
                                    , Session["StoreName"].ToString(), "OK");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' firmid, 'NIL' firmname";
            ds = DBConnection.fillDataSet(qry);
        }
        ddfirm.DataTextField = ds.Tables[0].Columns["firmname"].ToString();
        ddfirm.DataValueField = ds.Tables[0].Columns["firmid"].ToString();
        ddfirm.DataSource = ds.Tables[0];
        ddfirm.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDAllStore()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;
        string qry = string.Format("SELECT distinct storeid,storename from tblmasterstore order by storeid");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' storeid, 'NIL' storename";
            ds = DBConnection.fillDataSet(qry);
        }
        ddstore.DataTextField = ds.Tables[0].Columns["storename"].ToString();
        ddstore.DataValueField = ds.Tables[0].Columns["storeid"].ToString();
        ddstore.DataSource = ds.Tables[0];
        ddstore.DataBind();
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
            DataSet ds;
            string qry = string.Format("SELECT subdivisionid,subdivisionname from LineMaster" +
                                       " where Estatus='{0}' and Lineid = {1} " +
                                       "order by LineName"
                                        , "OK", ddline.SelectedValue);
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
    }
    private void DDDiv()
    {
        if (ddline.SelectedItem.Text == "NIL")
        {
            dddiv.SelectedItem.Text = "NIL";
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
    private void DDStatusType()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("SELECT statustypeid,statustype from MasterStatusType");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' statustypeid, 'NIL' statustype";
            ds = DBConnection.fillDataSet(qry);
        }
        ddstatustype.DataTextField = ds.Tables[0].Columns["statustype"].ToString();
        ddstatustype.DataValueField = ds.Tables[0].Columns["statustypeid"].ToString();
        ddstatustype.DataSource = ds.Tables[0];
        ddstatustype.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDJVStatus()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("SELECT jvstatusid,jvstatus from MasterJVStatus");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' jvstatusid, 'NIL' jvstatus";
            ds = DBConnection.fillDataSet(qry);
        }
        ddjvstatus.DataTextField = ds.Tables[0].Columns["jvstatus"].ToString();
        ddjvstatus.DataValueField = ds.Tables[0].Columns["jvstatusid"].ToString();
        ddjvstatus.DataSource = ds.Tables[0];
        ddjvstatus.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        lblMessage2.Visible = false;
        btndel.Visible = false;
        btnapproval.Visible = false;
        txtbox.Visible = true;
        Proceed.Text = "Save";
        allclear();
        unreadonlytext();
    }
    private void clear()
    {
        txtcreditamt.Text = "0.00";
        txtremarks.Text = " ";
        Tr15.Visible = false;
        Tr18.Visible = false;
        Tr20.Visible = false;
        Tr21.Visible = false;
        Tr22.Visible = false;
        grouphead();
        subgrouphead();
        DDGoodsType();
        DDTypebind();
        DDNameItembind();
        txtunitbind();
        DDStatusType();
        DDJVStatus();
    }
    private void allclear()
    {
        txtjvn.Text = "";
        txtjvdate.Text = "dd-mm-yyyy";
        txtgrno.Text = "";
        txtgrpageno.Text = "";
        txtgrdate.Text = "dd-mm-yyyy";
        txtsrwdate.Text = "dd-mm-yyyy";
        txtsrwno.Text = "";
        txtpono.Text = "";
        txtpodate.Text = "dd-mm-yyyy"; 
        txtcreditamt.Text = "0.00";
        txtremarks.Text = " ";
        Tr15.Visible = false;
        Tr18.Visible = false;
        Tr20.Visible = false;
        Tr21.Visible = false;
        Tr22.Visible = false;
        grouphead();
        subgrouphead();
        DDGoodsType();
        DDTypebind();
        DDNameItembind();
        txtunitbind();
        DDStatusType();
        DDJVStatus();
    }
    private void readonlytext()
    {
        ddstatustype.Enabled = false;
        ddline.Enabled = false;
        ddfirm.Enabled = false;
        ddstore.Enabled = false;
        ddsubgrp.Enabled = false;
        ddgrouphead.Enabled = false;
        dditemtype.Enabled = false;
        dditemname.Enabled = false;
        txtunit.ReadOnly = true;
        ddstatus.Enabled = false;
        ddjvstatus.Enabled = false;
    }

    private void unreadonlytext()
    {
        ddstatustype.Enabled = true;
        ddline.Enabled = true;
        ddfirm.Enabled = true;
        ddstore.Enabled = true;
        ddsubgrp.Enabled = true;
        ddgrouphead.Enabled = true;
        dditemtype.Enabled = true;
        dditemname.Enabled = true;
        txtunit.ReadOnly = false;
        ddstatus.Enabled = true;
        ddjvstatus.Enabled = true;
    }
    private void showMsg(Label lbl, Color color, string msg)
    {
        lbl.ForeColor = color;
        lbl.Text = msg;
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
            string qry = string.Format("select voucherno,grbookno,grpageno,grdate,goodstype,itemcode,itemname from stockreceipttable " +
                                       " where grbookno={0} and grpageno={1} and itemcode='{2}' and goodstype='{3}' and storename='{4}' " +
                                       " and smonth = '{5}' and voucherno='{6}' "
                                        , Convert.ToInt32(txtgrno.Text), Convert.ToInt32(txtgrpageno.Text), dditemname.SelectedValue, ddstatus.SelectedItem.Text, Session["StoreName"].ToString(), "Voucher", txtjvn.Text);
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (txtjvn.Text == ds.Tables[0].Rows[0]["voucherno"].ToString() && txtgrno.Text == ds.Tables[0].Rows[0]["grbookno"].ToString() && txtgrpageno.Text == ds.Tables[0].Rows[0]["grpageno"].ToString() && dditemname.SelectedValue == ds.Tables[0].Rows[0]["itemcode"].ToString() && ddstatus.SelectedItem.Text == ds.Tables[0].Rows[0]["goodstype"].ToString())
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
                    showMsg(Label2, Color.Red, "Select Item Type!");
                    return;
                }
                else if (ddgrouphead.SelectedItem.Text == "....")
                {
                    Label3.Visible = true;
                    showMsg(Label3, Color.Red, "Select Debit!");
                    return;
                }
                else if (ddstatustype.SelectedItem.Text == "....")
                {
                    Label4.Visible = true;
                    showMsg(Label4, Color.Red, "Select Source!");
                    return;
                }
                else if (ddjvstatus.SelectedItem.Text == "....")
                {
                    Label5.Visible = true;
                    showMsg(Label5, Color.Red, "Select JV-Status!");
                    return;
                }
                else
                {  
                    string scmdText = " BEGIN ";
                    if (ddjvstatus.SelectedValue == "2")
                    {
                         crdamt = Convert.ToDecimal(txtcreditamt.Text);
                    }
                    else if (ddjvstatus.SelectedValue == "3")
                    {
                         crdamt = Convert.ToDecimal("-" + txtcreditamt.Text);
                    }
                    DateTime grdate = new DateTime();
                    DateTime sysdate = new DateTime();
                    DateTime datevoucher = new DateTime();
                    string sysTime = (System.DateTime.Now).ToString("HH:mm:ss");
                    grdate = Convert.ToDateTime(txtgrdate.Text);
                    datevoucher = Convert.ToDateTime(txtjvdate.Text);
                    sysdate = Convert.ToDateTime((System.DateTime.Now).ToString("dd-MM-yyyy"));
                    String srchdate, systemdate;
                    srchdate = grdate.ToString("yyyy-MM-dd");
                    systemdate = sysdate.ToString("yyyy-MM-dd");
            String grdate1 = grdate.ToString("yyyy-MM-dd");
            String datevoucher1 = datevoucher.ToString("yyyy-MM-dd");

                    scmdText += string.Format("Insert into stockreceipttable (smonth,syear,scurdate,storename,grbookno,grpageno,grdate,stockstatus, " +
                                              "lineid,linename,subdivid,subdiv,divid,division,firmid,firmname,pstclstore,goodstype, " +
                                              "stockrecddate,stockinspectdate,storechallanno,srwchallanDate,pono,podate,grpid,grgrphead,subgrpid,grsubgrphead,itemno,itype,itemcode,itemname, " +
                                              "unit,qtyrecd,qtyaccepted,rate,subtotal,edpercentage,cesspercentage,highereducesspercentage,total,cstvatpercentage,freight,insurance,field4,grandtotal, " +
                                              "empcode,empname,desg,stockrole,username,field7,field2,estimateno,estid,grtime,voucherno,voucherdate,make,remarks)" + //make use for JV Status
                                              " VALUES ( '{0}' ,'{1}','{2}','{3}',{4},{5},'{6}','{7}', " +
                                              " {8},'{9}', {10},'{11}', {12},'{13}', {14},'{15}','{16}','{17}', " +
                                              " '{18}','{19}','{20}','{21}','{22}','{23}',{24},'{25}',{26},'{27}',{28},'{29}','{30}','{31}', " +
                                              " '{32}',{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45}, " +
                                              " '{46}','{47}','{48}','{49}','{50}',{51},'{52}','{53}',{54},'{55}','{56}','{57}','{58}','{59}' ) "
                                              , "Voucher", "", sysdate, Session["StoreName"], Convert.ToInt32(txtgrno.Text), Convert.ToInt32(txtgrpageno.Text), grdate1, ddstatustype.SelectedItem.Text,
                                                ddline.SelectedValue, ddline.SelectedItem.Text, ddsubdiv.SelectedValue, ddsubdiv.SelectedItem.Text, dddiv.SelectedValue, dddiv.SelectedItem.Text, ddfirm.SelectedValue, ddfirm.SelectedItem.Text, ddstore.SelectedItem.Text, ddstatus.SelectedItem.Text,
                                              "", "", txtsrwno.Text, txtsrwdate.Text, txtpono.Text, txtpodate.Text, ddgrouphead.SelectedValue, ddgrouphead.SelectedItem.Text, ddsubgrp.SelectedValue, ddsubgrp.SelectedItem.Text, dditemtype.SelectedValue, dditemtype.SelectedItem.Text, dditemname.SelectedValue, dditemname.SelectedItem.Text,
                                             txtunit.Text, 0.000, 0.000, 0.00, 0.00, 0.00, 0.00, 0.00, crdamt, 0.00, 0.00, 0.00, 0.00, crdamt,
                                              "", "", "", Session["RoleN"].ToString(), Session["UI"].ToString(), 1, "Pending", "", 0, sysTime, txtjvn.Text, datevoucher1, ddjvstatus.SelectedValue,txtremarks.Text);
                    scmdText += " END ";
                    DBConnection.executeNonQuery(scmdText);
                    showMsg(lblmsg, Color.Red, "Saved Successfully!");
                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                }
            }
        }
        else if (Proceed.Text == "Update")
        {
            if (ddjvstatus.SelectedItem.Text == "Amount Increase")
            {
                crdamt = Convert.ToDecimal(txtcreditamt.Text);
            }
            else if (ddjvstatus.SelectedItem.Text == "Amount Decrease")
            {
                crdamt = Convert.ToDecimal("-" + txtcreditamt.Text);
            }
            string scmdText = " BEGIN ";
            DateTime grdate = new DateTime();
            DateTime sysdate = new DateTime();
            DateTime datevoucher = new DateTime();
            string sysTime = (System.DateTime.Now).ToString("HH:mm:ss");
            grdate = Convert.ToDateTime(txtgrdate.Text);
            sysdate = Convert.ToDateTime((System.DateTime.Now).ToString("dd-MM-yyyy"));
            datevoucher = Convert.ToDateTime(txtjvdate.Text);
            String srchdate, systemdate;
            srchdate = grdate.ToString("yyyy-MM-dd");
            systemdate = sysdate.ToString("yyyy-MM-dd");

            String grdate1 = grdate.ToString("yyyy-MM-dd");
            String datevoucher1 = datevoucher.ToString("yyyy-MM-dd");
            scmdText += string.Format(" UPDATE stockreceipttable SET grbookno = {0}, grpageno = {1}, grdate = '{2}',stockrecddate = '{3}',stockinspectdate = '{4}', " +
                                      " storechallanno = '{5}',srwchallanDate = '{6}',pono = '{7}',podate = '{8}', qtyrecd = {9} ,qtyaccepted = {10} ,rate = {11}, " +
                                      " edpercentage = {12} ,cesspercentage = {13} ,highereducesspercentage = {14} ,cstvatpercentage = {15} ,freight = {16}, " +
                                      " field4 = {17} ,empcode = '{18}',empname = '{19}',desg = '{20}', subtotal = {21}, total = {22}, grandtotal = {23}, voucherno = '{24}' ,voucherdate = '{25}' , remarks = '{26}' " +
                                      " WHERE rtxno = {27} "
                                          , Convert.ToInt32(txtgrno.Text), Convert.ToInt32(txtgrpageno.Text), grdate1, "", "",
                                          txtsrwno.Text, txtsrwdate.Text, txtpono.Text, txtpodate.Text, 0.000,
                                          0.000, 0.00, 0.00, 0.00,
                                          0.00, 0.00, 0.00,
                                          0.00, 0.00, 0.00, 0.00, 0.00, crdamt, crdamt, txtjvn.Text, datevoucher1, txtremarks.Text, i);
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
        can.Visible = true;
        unreadonlytext();
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
        lblmsg.Visible = true;
        string scmdText = " BEGIN ";
        scmdText += string.Format(" UPDATE stockreceipttable SET field7={0} " +
                                 " WHERE  rtxno={1} and grbookno = {2} and grpageno = {3} and voucherno = '{4}' "
                                  , 2, i, Convert.ToInt32(txtgrno.Text), Convert.ToInt32(txtgrpageno.Text), txtjvn.Text);
        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        showMsg(lblmsg, Color.Red, "Successfully Sent for Approval!");
        txtbox.Visible = false;
        gridbind();
        clear();
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;
        unreadonlytext();
        DataSet ds;
        string qry = string.Format(" delete from stockreceipttable " +
                                   " where rtxno={0} and grbookno = {1} and grpageno = {2} and voucherno = '{3}' "
                                    , i, Convert.ToInt32(txtgrno.Text), Convert.ToInt32(txtgrpageno.Text), txtjvn.Text);
        ds = DBConnection.fillDataSet(qry);
        ds.Clear();
        ds.Dispose();
        gridbind();
        lblMessage2.Text = "[Data Delete Successfully.]";
        lblMessage2.Visible = true;
        txtbox.Visible = false;
        can.Visible = true;
    }
    protected void ddstatustype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddstatustype.SelectedItem.Text == "Work")
        {
            Tr15.Visible = false;
            Tr18.Visible = false;
            Tr20.Visible = true;
            Tr21.Visible = true;
            Tr22.Visible = true;
        }
        else if (ddstatustype.SelectedItem.Text == "Firm")
        {
            Tr20.Visible = false;
            Tr21.Visible = false;
            Tr22.Visible = false;
            Tr18.Visible = false;
            Tr15.Visible = true;
        }
        else
        {
            Tr20.Visible = false;
            Tr21.Visible = false;
            Tr22.Visible = false;
            Tr15.Visible = false;
            Tr18.Visible = true;
        }
    }
    protected void ddline_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDDiv();
        DDSubDiv();
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

        }
    }
    protected void GVInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVInfo.PageIndex = e.NewPageIndex;
        gridbind();
        txtbox.Visible = false;
    }
    protected void GVInfo_EditClick(object sender, GridViewCommandEventArgs e)
    {
        lblmsg.Visible = false;
        btndel.Visible = true;
        btnapproval.Visible = true;
        lblMessage2.Visible = false;
        txtbox.Visible = true;
        string currentCommand = e.CommandName;
        if (currentCommand == "Edit")
        {
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            long k;
            k = Convert.ToInt32(GVInfo.DataKeys[currentRowIndex].Value);
            i = Convert.ToInt32(GVInfo.DataKeys[currentRowIndex].Value);
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
                txtjvdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["voucherdate"]).ToString("dd-MM-yyyy");
                if (ds.Tables[0].Rows[0]["make"].ToString() == "2")
                {
                    ddjvstatus.SelectedItem.Text = "Amount Increase";
                    txtcreditamt.Text = ds.Tables[0].Rows[0]["grandtotal"].ToString();
                }
                else if (ds.Tables[0].Rows[0]["make"].ToString() == "3")
                {
                    ddjvstatus.SelectedItem.Text = "Amount Decrease";
                    txtcreditamt.Text =  Convert.ToString(Convert.ToDecimal(ds.Tables[0].Rows[0]["grandtotal"].ToString()) * (-1));
                }   
            }
            ds.Clear();
            ds.Dispose();
            Proceed.Text = "Update";
            can.Visible = false;
            readonlytext();
        }
    }
    protected void GVInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GVInfo_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void ddgrouphead_SelectedIndexChanged(object sender, EventArgs e)
    {
        subgrouphead();
    }
   
}