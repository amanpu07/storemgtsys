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
public partial class Inventory_StoreJEChallan : System.Web.UI.Page
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
            //Tr20.Visible = false;
            //Tr21.Visible = false;
            //Tr22.Visible = false;
            //Tr15.Visible = false;
            Tr18.Visible = true;
            gridbind();
            txtbox.Visible = false;
            calculateValues();
            grouphead();
            subgrouphead();
            //DDLine();
            //DDSubDiv();
            //DDDiv();
            DDGoodsType();
            DDTypebind();
            DDNameItembind();
            txtunitbind();
           // DDFirm();
            DDAllStore();
            //DDStatusType();
            Label2.Visible = false;
            Label3.Visible = false;
           // Label4.Visible = false;
        }
        lblaeeremarks.Visible = false;
    }
    private void gridbind()
    {
        string qry = string.Format("SELECT itxno,srchallanbookno,srchallanpageno,srchallandate,stockitemname,firm,grandtotal,ifield2 from dbo.stockissuetable " +
                                    "where issuetype='CHALLAN' and ifield7=1 and istore ='{0}' " +
                                    " order by ifield2 desc,itxno desc "
                                    , Session["StoreName"].ToString());
        DBConnection.fillGridView(ref GVChallanInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    private void grouphead()
    {
        DataSet ds;
        string qry = string.Format("SELECT groupid, (accategory + debitac) debit from MasterGroup where groupid = 0  union all  SELECT groupid,case when accategory = '' then debitac else accategory + ' ('  + debitac + ')' end as debit  FROM MasterGroup " +
                                   "where groupid <> 0 and status=5 order by groupid");
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
                                    " where subgroupid <> 1 and status=105 and groupid={0} " +
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
    //private void DDLine()
    //{
    //    // System.Threading.Thread.Sleep(5000);
    //    DataSet ds;

    //    string qry = string.Format("SELECT Lineid,LineName from LineMaster" +
    //                               " where Estatus='{0}' " +
    //                               "order by LineName"
    //                                , "OK");
    //    ds = DBConnection.fillDataSet(qry);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        qry = "SELECT 'NIL' Lineid, 'NIL' LineName";
    //        ds = DBConnection.fillDataSet(qry);
    //    }
    //    ddline.DataTextField = ds.Tables[0].Columns["LineName"].ToString();
    //    ddline.DataValueField = ds.Tables[0].Columns["Lineid"].ToString();
    //    ddline.DataSource = ds.Tables[0];
    //    ddline.DataBind();
    //    ds.Clear();
    //    ds.Dispose();
    //}
    //private void DDFirm()
    //{
    //    // System.Threading.Thread.Sleep(5000);
    //    DataSet ds;

    //    string qry = string.Format("SELECT firmid,firmname from MasterFirm" +
    //                               " where storename='{0}' and Status='{1}' " +
    //                               "order by firmname"
    //                                , Session["StoreName"].ToString(), "OK");
    //    ds = DBConnection.fillDataSet(qry);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        qry = "SELECT 'NIL' firmid, 'NIL' firmname";
    //        ds = DBConnection.fillDataSet(qry);
    //    }
    //    ddfirm.DataTextField = ds.Tables[0].Columns["firmname"].ToString();
    //    ddfirm.DataValueField = ds.Tables[0].Columns["firmid"].ToString();
    //    ddfirm.DataSource = ds.Tables[0];
    //    ddfirm.DataBind();
    //    ds.Clear();
    //    ds.Dispose();
    //}
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
    //private void DDSubDiv()
    //{
    //    // System.Threading.Thread.Sleep(5000);
    //    DataSet ds;

    //    string qry = string.Format("SELECT subdivisionid,subdivisionname from LineMaster" +
    //                               " where Estatus='{0}' and Lineid = {1} " +
    //                               "order by LineName"
    //                                , "OK", ddline.SelectedValue);
    //    ds = DBConnection.fillDataSet(qry);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        qry = "SELECT 'NIL' subdivisionid, 'NIL' subdivisionname";
    //        ds = DBConnection.fillDataSet(qry);
    //    }
    //    ddsubdiv.DataTextField = ds.Tables[0].Columns["subdivisionname"].ToString();
    //    ddsubdiv.DataValueField = ds.Tables[0].Columns["subdivisionid"].ToString();
    //    ddsubdiv.DataSource = ds.Tables[0];
    //    ddsubdiv.DataBind();
    //    ds.Clear();
    //    ds.Dispose();
    //}
    //private void DDDiv()
    //{
    //    // System.Threading.Thread.Sleep(5000);
    //    DataSet ds;

    //    string qry = string.Format("SELECT divid,divisonname from LineMaster" +
    //                               " where Estatus='{0}' and Lineid = {1} " +
    //                               "order by LineName"
    //                                , "OK", ddline.SelectedValue);
    //    ds = DBConnection.fillDataSet(qry);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        qry = "SELECT 'NIL' divid, 'NIL' divisonname";
    //        ds = DBConnection.fillDataSet(qry);
    //    }
    //    dddiv.DataTextField = ds.Tables[0].Columns["divisonname"].ToString();
    //    dddiv.DataValueField = ds.Tables[0].Columns["divid"].ToString();
    //    dddiv.DataSource = ds.Tables[0];
    //    dddiv.DataBind();
    //    ds.Clear();
    //    ds.Dispose();
    //}

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
    //private void DDStatusType()
    //{
    //    // System.Threading.Thread.Sleep(5000);
    //    DataSet ds;

    //    string qry = string.Format("SELECT statustypeid,statustype from MasterStatusType");
    //    ds = DBConnection.fillDataSet(qry);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        qry = "SELECT 'NIL' statustypeid, 'NIL' statustype";
    //        ds = DBConnection.fillDataSet(qry);
    //    }
    //    ddstatustype.DataTextField = ds.Tables[0].Columns["statustype"].ToString();
    //    ddstatustype.DataValueField = ds.Tables[0].Columns["statustypeid"].ToString();
    //    ddstatustype.DataSource = ds.Tables[0];
    //    ddstatustype.DataBind();
    //    ds.Clear();
    //    ds.Dispose();
    //}
    private void calculateValues()
    {
        if (txtqtyreq.Text == "")
        {
            txtqtyreq.Text = "0.000";
        }
        if (txtqtyissued.Text == "")
        {
            txtqtyissued.Text = "0.000";
        }
        if (txtrate.Text == "")
        {
            txtrate.Text = "0.00";
        }
        if (txttotal.Text == "")
        {
            txttotal.Text = "0.00";
        }
        if (txtstorage.Text == "")
        {
            txtstorage.Text = "0.00";
        }
        if (txtgrandtotal.Text == "")
        {
            txtgrandtotal.Text = "0.00";
        }
        txttotal.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtqtyissued.Text) * Convert.ToDecimal(txtrate.Text))) + ".00";

        txtgrandtotal.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txttotal.Text) + ((Convert.ToDecimal(txttotal.Text) * Convert.ToDecimal(txtstorage.Text)) / 100))) + ".00";
    }
    private void clear()
    {
        txtqtyreq.Text = "0.000";
        txtqtyissued.Text = "0.000";
        txtrate.Text = "0.00";
        txttotal.Text = "0.00";
        txtstorage.Text = "0.00";
        txtgrandtotal.Text = "0.00";
       // Tr15.Visible = false;
        Tr18.Visible = true;
        //Tr20.Visible = false;
        //Tr21.Visible = false;
        //Tr22.Visible = false;
        grouphead();
        subgrouphead();
        DDGoodsType();
        DDTypebind();
        DDNameItembind();
        txtunitbind();
       // DDStatusType();
    }
    private void allclear()
    {
        txtchalbookno.Text = "";
        txtchalpageno.Text = "";
        txtchaldate.Text = "dd-mm-yyyy";
        txtstoindentdate.Text = "dd-mm-yyyy";
        txtstoindentno.Text = "";
        txtqtyreq.Text = "0.000";
        txtqtyissued.Text = "0.000";
        txtrate.Text = "0.00";
        txttotal.Text = "0.00";
        txtstorage.Text = "0.00";
        txtgrandtotal.Text = "0.00";
       // Tr15.Visible = false;
        Tr18.Visible = true;
        //Tr20.Visible = false;
        //Tr21.Visible = false;
        //Tr22.Visible = false;
        grouphead();
        subgrouphead();
        DDGoodsType();
        DDTypebind();
        DDNameItembind();
        txtunitbind();
       // DDStatusType();
    }
    private void readonlytext()
    {
        //ddstatustype.Enabled = false;
        //ddline.Enabled = false;
        //ddfirm.Enabled = false;
        ddstore.Enabled = false;
        ddsubgrp.Enabled = false;
        ddgrouphead.Enabled = false;
        dditemtype.Enabled = false;
        dditemname.Enabled = false;
        txtunit.ReadOnly = true;
        ddstatus.Enabled = false;
    }

    private void unreadonlytext()
    {
        //ddstatustype.Enabled = true;
        //ddline.Enabled = true;
        //ddfirm.Enabled = true;
        ddstore.Enabled = true;
        ddsubgrp.Enabled = true;
        ddgrouphead.Enabled = true;
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
            string qry = string.Format("select srchallanbookno,	srchallanpageno,srchallandate,goodstype,stockitemcode,stockitemname from stockissuetable " +
                                       " where srchallanbookno='{0}' and srchallanpageno='{1}' and stockitemcode='{2}' and goodstype='{3}' and istore='{4}' " +
                                       " and issuetype = '{5}' "
                                        , txtchalbookno.Text, txtchalpageno.Text, dditemname.SelectedValue, ddstatus.SelectedItem.Text, Session["StoreName"].ToString(), "CHALLAN");
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (txtchalbookno.Text == ds.Tables[0].Rows[0]["srchallanbookno"].ToString() && txtchalpageno.Text == ds.Tables[0].Rows[0]["srchallanpageno"].ToString() && dditemname.SelectedValue == ds.Tables[0].Rows[0]["stockitemcode"].ToString() && ddstatus.SelectedItem.Text == ds.Tables[0].Rows[0]["goodstype"].ToString())
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
                //else if (ddstatustype.SelectedItem.Text == "....")
                //{
                //    Label4.Visible = true;
                //    // ClientScript.RegisterClientScriptBlock(this.GetType(), "ddd", "<script>alert('Select Item Type')</script>");
                //    showMsg(Label4, Color.Red, "Select Source!");
                //    return;
                //}
                  else
                {
                    if (ddstore.SelectedItem.Text == "....")
                    {
                        Label2.Visible = true;
                        // ClientScript.RegisterClientScriptBlock(this.GetType(), "ddd", "<script>alert('Select Item Type')</script>");
                        showMsg(Label4, Color.Red, "Select Store Name!");
                        return;
                    }

                    else
                    {

                    string scmdText = " BEGIN ";
                    DateTime grdate = new DateTime();
                    DateTime sysdate = new DateTime();
                    string sysTime = (System.DateTime.Now).ToString("HH:mm:ss");
                    grdate = Convert.ToDateTime(txtchaldate.Text);
                    sysdate = Convert.ToDateTime((System.DateTime.Now).ToString("dd-MM-yyyy"));
                    String srchdate, systemdate;
                    srchdate = grdate.ToString("yyyy-MM-dd");
                    systemdate = sysdate.ToString("yyyy-MM-dd");
                    scmdText += string.Format("Insert into stockissuetable (issuetype,istore,icurdate,srchallanbookno,srchallanpageno,srchallandate,srchtime,subdivid,nameofsubdivision,divid,nameofdivision, " +
                                              "lineid,linename,grpid,srgrphead,subgrpid,srsubgrphead,itemtypecode,stockitemyype,stockitemcode,stockitemname,goodstype,unit,qtyindented, " +
                                              " issuedqty,qtyvalue,storagecharges,totalvalue,grandtotal,storeindentno,storeindentdate,storename,itemrecdempcode,recdempname,designation,stockstatus, " +
                                              "ifield9,transtorename,userrole,username,ifield2,ifield7)" +
                                              " VALUES ( '{0}' ,'{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}',{9}, '{10}', " +
                                              " {11}, '{12}',{13}, '{14}',{15},'{16}',{17},'{18}','{19}','{20}','{21}','{22}',{23}, " +
                                              " {24},{25},{26},{27},{28},'{29}','{30}','{31}','{32}','{33}','{34}','{35}', " +
                                              " {36},'{37}','{38}','{39}','{40}',{41} ) "
                                              , "CHALLAN", Session["StoreName"], systemdate, txtchalbookno.Text, txtchalpageno.Text, srchdate, sysTime, 100000, "NA", 100000, "NA",
                                              100000, "NA", ddgrouphead.SelectedValue, ddgrouphead.SelectedItem.Text, ddsubgrp.SelectedValue, ddsubgrp.SelectedItem.Text, dditemtype.SelectedValue, dditemtype.SelectedItem.Text, dditemname.SelectedValue, dditemname.SelectedItem.Text, ddstatus.SelectedItem.Text, txtunit.Text, Convert.ToDecimal(txtqtyreq.Text),
                                             Convert.ToDecimal(txtqtyissued.Text), Convert.ToDecimal(txtrate.Text), Convert.ToDecimal(txtstorage.Text), Convert.ToDecimal(txttotal.Text), Convert.ToDecimal(txtgrandtotal.Text), txtstoindentno.Text, txtstoindentdate.Text, ddstore.SelectedItem.Text, txtempcode.Text, txtempname.Text, txtdesg.Text, "Other Store",
                                             100000, "NA",Session["RoleN"].ToString(), Session["UI"].ToString(), "Pending" ,1);

                    //ifield9,transtorename use for firmid and firmname
                    
                    scmdText += " END ";
                    DBConnection.executeNonQuery(scmdText);
                    showMsg(lblmsg, Color.Red, "Saved Successfully!");
                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                }
            }
}
        }
        else if (Proceed.Text == "Update")
        {
            
                string scmdText = " BEGIN ";
                DateTime grdate = new DateTime();
                DateTime sysdate = new DateTime();
                string sysTime = (System.DateTime.Now).ToString("HH:mm:ss");
                grdate = Convert.ToDateTime(txtchaldate.Text);
                sysdate = Convert.ToDateTime((System.DateTime.Now).ToString("dd-MM-yyyy"));
                String srchdate, systemdate;
                srchdate = grdate.ToString("yyyy-MM-dd");
                systemdate = sysdate.ToString("yyyy-MM-dd");
                scmdText += string.Format(" UPDATE stockissuetable SET srchallanbookno = '{0}', srchallanpageno = '{1}', srchallandate = '{2}',storeindentno = '{3}',storeindentdate = '{4}', " +
                                          "  qtyindented = {5} ,issuedqty = {6} ,qtyvalue = {7}, storagecharges = {8} ,totalvalue = {9} ,grandtotal = {10} ," +
                                          " itemrecdempcode = '{11}',recdempname = '{12}',designation = '{13}' " +
                                          " WHERE itxno = {14} "
                                              , txtchalbookno.Text, txtchalpageno.Text, srchdate, txtstoindentno.Text, txtstoindentdate.Text,
                                              Convert.ToDecimal(txtqtyreq.Text), Convert.ToDecimal(txtqtyissued.Text), Convert.ToDecimal(txtrate.Text),
                                              Convert.ToDecimal(txtstorage.Text), Convert.ToDecimal(txttotal.Text),Convert.ToDecimal(txtgrandtotal.Text),
                                              txtempcode.Text, txtempname.Text, txtdesg.Text, i);
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
                                 " WHERE  itxno={1} and srchallanbookno = '{2}' and srchallanpageno = '{3}' "
                                  , 2, i, txtchalbookno.Text, txtchalpageno.Text);
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
                                   " where itxno={0} and srchallanbookno = '{1}' and srchallanpageno = '{2}' "
                                    , i, txtchalbookno.Text, txtchalpageno.Text);
        ds = DBConnection.fillDataSet(qry);
        ds.Clear();
        ds.Dispose();
        gridbind();
        lblMessage2.Text = "[Data Delete Successfully.]";
        lblMessage2.Visible = true;
        txtbox.Visible = false;
        can.Visible = true;
    }
   // protected void ddstatustype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddstatustype.SelectedItem.Text == "Work")
    //    {
    //        Tr15.Visible = false;
    //        Tr18.Visible = false;
    //        Tr20.Visible = true;
    //        Tr21.Visible = true;
    //        Tr22.Visible = true;
    //    }
    //    else if (ddstatustype.SelectedItem.Text == "Firm")
    //    {
    //        Tr20.Visible = false;
    //        Tr21.Visible = false;
    //        Tr22.Visible = false;
    //        Tr18.Visible = false;
    //        Tr15.Visible = true;
    //    }
    //    else
    //    {
    //        Tr20.Visible = false;
    //        Tr21.Visible = false;
    //        Tr22.Visible = false;
    //        Tr15.Visible = false;
    //        Tr18.Visible = true;
    //    }
    //}
    //protected void ddline_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DDDiv();
    //    DDSubDiv();
    //}
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
    protected void txtqtyreq_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
    protected void txtqtyissued_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
    protected void txtrate_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
    protected void txtstorage_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
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
            else if (lblstatus.Text == "Reject")
            {
                GVChallanInfo.Rows[i].Cells[5].BackColor = System.Drawing.Color.Red;
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
    protected void GVChallanInfo_EditClick(object sender, GridViewCommandEventArgs e)
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
            k = Convert.ToInt32(GVChallanInfo.DataKeys[currentRowIndex].Value);
            i = Convert.ToInt32(GVChallanInfo.DataKeys[currentRowIndex].Value);
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
               // }
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
            Proceed.Text = "Update";
            can.Visible = false;
            readonlytext();
        }
    }
    protected void GVChallanInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GVChallanInfo_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}