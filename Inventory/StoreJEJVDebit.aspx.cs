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

public partial class Inventory_StoreJEJVDebit : System.Web.UI.Page
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
            grouphead();
            subgrouphead();
            DDStatusType();
            DDLine();
            DDSubDiv();
            DDDiv();
            DDGoodsType();
            DDTypebind();
            DDNameItembind();
            txtunitbind();
            DDFirm();
            DDAllStore();
           
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
        string qry = string.Format("SELECT CASE WHEN projectcode = '2' THEN grandtotal ELSE grandtotal*(-1) END as grandtotal,itxno,voucherno,datevoucher,stockitemname,unit,ifield2 FROM stockissuetable " +
                                    "where ifield7=1 and issuetype='Voucher' and istore='{0}' " +
                                    " order by ifield2 desc,itxno desc "
                                    , Session["StoreName"].ToString());
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    private void grouphead()
    {
        DataSet ds;
        string qry = string.Format("SELECT groupid, (accategory + debitac) debit from MasterGroup where groupid = 0  union all  SELECT groupid,case when debitac = '' then accategory else accategory + ' ('  + debitac + ')' end as debit  FROM MasterGroup " +
                                   "where groupid <> 0 and status in (4,5) order by groupid");
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
                                    " where subgroupid <> 1 and status in (104,105) and groupid={0} " +
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
            string qry = string.Format("select voucherno,srchallanbookno,srchallanpageno,srchallandate,goodstype,stockitemcode,stockitemname from stockissuetable " +
                                       " where srchallanbookno='{0}' and srchallanpageno='{1}' and stockitemcode='{2}' and goodstype='{3}' and istore='{4}' " +
                                       " and issuetype = '{5}' and voucherno='{6}' "
                                        , txtgrno.Text, txtgrpageno.Text, dditemname.SelectedValue, ddstatus.SelectedItem.Text, Session["StoreName"].ToString(), "Voucher", txtjvn.Text);
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (txtjvn.Text == ds.Tables[0].Rows[0]["voucherno"].ToString() && txtgrno.Text == ds.Tables[0].Rows[0]["srchallanbookno"].ToString() && txtgrpageno.Text == ds.Tables[0].Rows[0]["srchallanpageno"].ToString() && dditemname.SelectedValue == ds.Tables[0].Rows[0]["stockitemcode"].ToString() && ddstatus.SelectedItem.Text == ds.Tables[0].Rows[0]["goodstype"].ToString())
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
                    showMsg(Label3, Color.Red, "Select Group Head!");
                    return;
                }
                else if (ddstatustype.SelectedItem.Text == "....")
                {
                    Label4.Visible = true;
                    showMsg(Label4, Color.Red, "Select Source!");
                    return;
                }
                else if (ddstatustype.SelectedItem.Text == "Other Store" && ddstore.SelectedItem.Text == "....")
                {
                    Label4.Visible = true;
                    showMsg(Label6, Color.Red, "Select Store!");
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
                    scmdText += string.Format("Insert into stockissuetable (issuetype,iyear,icurdate,istore,srchallanbookno,srchallanpageno,srchallandate,stockstatus, " +
                                              "lineid,linename,subdivid,nameofsubdivision,divid,nameofdivision,ifield9,transtorename,storename,goodstype, " +
                                              "storeindentno,storeindentdate,grpid,srgrphead,subgrpid,srsubgrphead,itemtypecode,stockitemyype,stockitemcode,stockitemname, " +
                                              "unit,qtyindented,issuedqty,qtyvalue,storagecharges,totalvalue,grandtotal, " +
                                              "userrole,username,ifield2,ifield7,srchtime,voucherno,datevoucher,projectcode,remarks)" + //projectcode use for JV Status
                                              " VALUES ( '{0}' ,'{1}','{2}','{3}','{4}','{5}','{6}','{7}', " +
                                              " {8},'{9}', {10},'{11}', {12},'{13}', {14},'{15}','{16}','{17}', " +
                                              " '{18}','{19}',{20},'{21}',{22},'{23}',{24},'{25}','{26}','{27}', " +
                                              "  '{28}',{29},{30},{31}, {32},{33},{34}, " +
                                              "   '{35}','{36}','{37}',{38},'{39}','{40}','{41}','{42}','{43}' ) "
                                              , "Voucher", "", sysdate, Session["StoreName"], txtgrno.Text, txtgrpageno.Text, grdate1, ddstatustype.SelectedItem.Text,
                                                ddline.SelectedValue, ddline.SelectedItem.Text, ddsubdiv.SelectedValue, ddsubdiv.SelectedItem.Text, dddiv.SelectedValue, dddiv.SelectedItem.Text, ddfirm.SelectedValue, ddfirm.SelectedItem.Text, ddstore.SelectedItem.Text, ddstatus.SelectedItem.Text,
                                                txtpono.Text, txtpodate.Text, ddgrouphead.SelectedValue, ddgrouphead.SelectedItem.Text, ddsubgrp.SelectedValue, ddsubgrp.SelectedItem.Text, dditemtype.SelectedValue, dditemtype.SelectedItem.Text, dditemname.SelectedValue, dditemname.SelectedItem.Text,
                                                txtunit.Text, 0.000, 0.000, 0.00, 0.00, crdamt, crdamt,
                                              Session["RoleN"].ToString(), Session["UI"].ToString(), "Pending", 1, sysTime, txtjvn.Text, datevoucher1, ddjvstatus.SelectedValue, txtremarks.Text);
                    scmdText += " END ";
                    DBConnection.executeNonQuery(scmdText);
                    showMsg(lblmsg, Color.Red, "Saved Successfully!");
                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                    Label6.Visible = false;
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
            scmdText += string.Format(" UPDATE stockissuetable SET srchallanbookno = '{0}', srchallanpageno = '{1}', srchallandate = '{2}',storeindentno = '{3}',storeindentdate = '{4}', " +
                                      " totalvalue = {5} , grandtotal = {6}, voucherno = '{7}' ,datevoucher = '{8}' , remarks = '{9}' " +
                                      " WHERE itxno = {10} "
                                          , txtgrno.Text, txtgrpageno.Text, grdate1, txtpono.Text, txtpodate.Text,crdamt, crdamt, txtjvn.Text, datevoucher1, txtremarks.Text, i);
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
        scmdText += string.Format(" UPDATE stockissuetable SET ifield7={0} " +
                                 " WHERE  itxno={1} and srchallanbookno = '{2}' and srchallanpageno = '{3}' and voucherno = '{4}' "
                                  , 2, i, txtgrno.Text, txtgrpageno.Text, txtjvn.Text);
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
        string qry = string.Format(" delete from stockissuetable " +
                                   " where itxno={0} and srchallanbookno = '{1}' and srchallanpageno = '{2}' and voucherno = '{3}' "
                                    , i, txtgrno.Text, txtgrpageno.Text, txtjvn.Text);
        ds = DBConnection.fillDataSet(qry);
        ds.Clear();
        ds.Dispose();
        gridbind();
        lblMessage2.Text = "[Data Delete Successfully.]";
        lblMessage2.Visible = true;
        txtbox.Visible = false;
        can.Visible = true;
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
    protected void ddgrouphead_SelectedIndexChanged(object sender, EventArgs e)
    {
        subgrouphead();
    }
}