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


public partial class Inventory_SubdivisonSRW : System.Web.UI.Page
{
    static long i;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["StoreName"] == null || Session["UI"] == null)
        {
            Response.Redirect("~/Home/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            gridbind();
            ddstorebind();
            txtbox.Visible = false; 
            DDLine();
            DDEstimate();            
            DDTypebind();
            DDNameItembind();
            DDGoodsType();
            txtunitbind();
            employeename();
            Label2.Visible = false;
        }
        lblaeeremarks.Visible = false;
    }
    private void gridbind()
    {
        string qry = string.Format("SELECT rtxno,storechallanno,srwchallanDate,itemname,unit,qtyrecd,subdivstatus FROM stockreceipttable " +
                                    "where subdivstatusid=1 and smonth='GRSRW' and subdivid={0} and username = '{1}' " +
                                    " order by subdivstatus desc,rtxno desc "
                                    , Session["subdivisonid"], Session["UI"]);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    private void ddstorebind()
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
    private void employeename()
    {
        DataSet ds;
        string qry = string.Format("SELECT employeecode,employeename from tbllogin" +
                                   " where username='{0}'  "
                                    , Session["UI"]);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {

            txtpono.Text = ds.Tables[0].Rows[0]["employeename"].ToString();
            txtpodate.Text = ds.Tables[0].Rows[0]["employeecode"].ToString();
        }
        ds.Clear();
        ds.Dispose();
    }
    private void DDLine()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("SELECT Lineid,LineName from LineMaster" +
                                   " where subdivisionid={0} and Estatus='{1}' " +
                                   "order by LineName"
                                    , Session["subdivisonid"], "OK");
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
    private void DDEstimate()
    {
        if (ddline.SelectedItem.Text == "NIL")
        {

        }
        else
        {
            //System.Threading.Thread.Sleep(5000);
            DataSet ds;

            string qry = string.Format("SELECT estid,estimate from EstimateMaster" +
                                       " where subdivisionid={0} and LineCode={1} and Estatus='{2}' " +
                                       "order by estimate"
                                        , Session["subdivisonid"], ddline.SelectedValue, "OK");
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count == 0)
            {
                qry = "SELECT 'NIL' estid, 'NIL' estimate";
                ds = DBConnection.fillDataSet(qry);
            }
            ddestimate.DataTextField = ds.Tables[0].Columns["estimate"].ToString();
            ddestimate.DataValueField = ds.Tables[0].Columns["estid"].ToString();
            ddestimate.DataSource = ds.Tables[0];
            ddestimate.DataBind();
            ds.Clear();
            ds.Dispose();
        }
    }
    private void DDTypebind()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("Select distinct itemtype,typecode  from MCR " +
                                   " where subdivisionid={0} and Estatus='{1}' and estid={2} " +
                                   "order by itemtype"
                                    , Session["subdivisonid"], "OK", ddestimate.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' itemtype,'NIL' typecode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemtype.DataTextField = ds.Tables[0].Columns["itemtype"].ToString();
        dditemtype.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype.DataSource = ds.Tables[0];
        dditemtype.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDNameItembind()
    {
        if (dditemtype.SelectedItem.Text == "NIL")
        {
            dditemname.SelectedItem.Text = "NIL";
            //dditemname.SelectedValue = "NIL";
        }
        else
        {
            DataSet ds;

            string qry = string.Format("Select distinct itemcode,itemname from MCR" +
                                       " where typecode={0} and estid={1} and subdivisionid={2}" +
                                       " order by itemname"
                                        , dditemtype.SelectedValue, ddestimate.SelectedValue, Session["subdivisonid"]);
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count == 0)
            {
                qry = "SELECT 'NIL' itemname, 'NIL' itemcode";
                ds = DBConnection.fillDataSet(qry);
            }
            dditemname.DataTextField = ds.Tables[0].Columns["itemname"].ToString();
            dditemname.DataValueField = ds.Tables[0].Columns["itemcode"].ToString();
            dditemname.DataSource = ds.Tables[0];
            dditemname.DataBind();
            ds.Clear();
            ds.Dispose();
        }
    }
    private void DDGoodsType()
    {
        //  System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("SELECT distinct goodstype from MCR" +
                                   " where subdivisionid={0} and Estatus='{1}' and itemcode='{2}' and estid={3} " +
                                   "order by goodstype"
                                    , Session["subdivisonid"], "OK", dditemname.SelectedValue, ddestimate.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' goodstype";
            ds = DBConnection.fillDataSet(qry);
        }
        ddstatus.DataTextField = ds.Tables[0].Columns["goodstype"].ToString();
        ddstatus.DataValueField = ds.Tables[0].Columns["goodstype"].ToString();
        ddstatus.DataSource = ds.Tables[0];
        ddstatus.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void txtunitbind()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("SELECT distinct unit,qtysanctioned,qtydrawn,contractor,jename,sdoname from MCR" +
                                   " where subdivisionid={0} and Estatus='{1}' and itemcode='{2}' and estid={3} "
                                    , Session["subdivisonid"], "OK", dditemname.SelectedValue, ddestimate.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
           // txtqty.Text = ds.Tables[0].Rows[0]["qtysanctioned"].ToString();
           // txtqtydrwn.Text = ds.Tables[0].Rows[0]["qtydrawn"].ToString();
           // txtcontractor.Text = ds.Tables[0].Rows[0]["contractor"].ToString();
            //txtje.Text = ds.Tables[0].Rows[0]["jename"].ToString();
            //txtsdo.Text = ds.Tables[0].Rows[0]["sdoname"].ToString();
           // txtje.Text = Session["employeename"].ToString();
           // txtsdo.Text = Session["employeecode"].ToString();
        }

        ds.Clear();
        ds.Dispose();
    }
    //private void DDGoodsType()
    //{
    //    //  System.Threading.Thread.Sleep(5000);
    //    DataSet ds;

    //    string qry = string.Format("SELECT goodsid,goodsstatus from MasterGoodsStatus");
    //    ds = DBConnection.fillDataSet(qry);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        qry = "SELECT 'NIL' goodsid, 'NIL' goodsstatus";
    //        ds = DBConnection.fillDataSet(qry);
    //    }
    //    ddstatus.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
    //    ddstatus.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
    //    ddstatus.DataSource = ds.Tables[0];
    //    ddstatus.DataBind();
    //    ds.Clear();
    //    ds.Dispose();
    //}
    //private void DDTypebind()
    //{
    //    // System.Threading.Thread.Sleep(5000);
    //    DataSet ds;

    //    string qry = string.Format("Select distinct itype,typecode  from MASTINVENTORY order by itype");
    //    ds = DBConnection.fillDataSet(qry);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        qry = "SELECT 'NIL' itype,'NIL' typecode";
    //        ds = DBConnection.fillDataSet(qry);
    //    }
    //    dditemtype.DataTextField = ds.Tables[0].Columns["itype"].ToString();
    //    dditemtype.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
    //    dditemtype.DataSource = ds.Tables[0];
    //    dditemtype.DataBind();
    //    ds.Clear();
    //    ds.Dispose();
    //}
    //private void DDNameItembind()
    //{
    //    // System.Threading.Thread.Sleep(5000);
    //    DataSet ds;

    //    string qry = string.Format("Select  iname,icode  from mastinventory" +
    //                               " where typecode='{0}' " +
    //                               " order by iname"
    //                                , dditemtype.SelectedValue);
    //    ds = DBConnection.fillDataSet(qry);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        qry = "SELECT 'NIL' iname, 'NIL' icode";
    //        ds = DBConnection.fillDataSet(qry);
    //    }
    //    dditemname.DataTextField = ds.Tables[0].Columns["iname"].ToString();
    //    dditemname.DataValueField = ds.Tables[0].Columns["icode"].ToString();
    //    dditemname.DataSource = ds.Tables[0];
    //    dditemname.DataBind();
    //    ds.Clear();
    //    ds.Dispose();
    //}
    //private void txtunitbind()
    //{
    //    // System.Threading.Thread.Sleep(5000);
    //    DataSet ds;

    //    string qry = string.Format("Select  field1 from mastinventory" +
    //                               " where icode='{0}'"
    //                                , dditemname.SelectedValue);
    //    ds = DBConnection.fillDataSet(qry);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        qry = "SELECT 'NIL' field1";
    //        ds = DBConnection.fillDataSet(qry);
    //    }
    //    txtunit.Text = ds.Tables[0].Rows[0]["field1"].ToString();
    //    ds.Clear();
    //    ds.Dispose();
    //}
    private void calfunction()
    {
        gridbind();
        ddstorebind();
        DDLine();
        DDEstimate();
        DDTypebind();
        DDNameItembind();
        DDGoodsType();
        txtunitbind();
        employeename();
    }
    private void calculateValues()
    {
        if (txtrquantity.Text == "")
        {
            txtrquantity.Text = "0.000";
        }
    }
    private void clear()
    {
        txtrquantity.Text = "0.000";       
        DDGoodsType();
        DDTypebind();
        DDNameItembind();
        txtunitbind();
    }
    private void allclear()
    {       
        txtsrwdate.Text = "dd-mm-yyyy";       
        txtsrwno.Text = "";
        txtpono.Text = "";
        txtpodate.Text = "";
        txtrquantity.Text = "0.000";
        txtsrno.Text = "";
        txtremarks.Text = "";
        DDGoodsType();
        DDTypebind();
        DDNameItembind();
        txtunitbind();
    }
    private void readonlytext()
    {
        ddstore.Enabled = false;
        ddline.Enabled = false;
        ddestimate.Enabled = false;
        dditemtype.Enabled = false;
        dditemname.Enabled = false;
        txtunit.ReadOnly = true;
        ddstatus.Enabled = false;
        txtsrwno.ReadOnly = true;
        txtsrwdate.ReadOnly = true;
    }

    private void unreadonlytext()
    {
        ddstore.Enabled = true;
        ddline.Enabled = true;
        ddestimate.Enabled = true;
        dditemtype.Enabled = true;
        dditemname.Enabled = true;
        txtunit.ReadOnly = false;
        ddstatus.Enabled = true;
        txtsrwno.ReadOnly = false;
        txtsrwdate.ReadOnly = false;
    }
    private void showMsg(Label lbl, Color color, string msg)
    {
        lbl.ForeColor = color;
        lbl.Text = msg;
    }
    protected void GVInfo_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i <= GVInfo.Rows.Count - 1; i++)
        {
            Label lblstatus = (Label)GVInfo.Rows[i].FindControl("lblgridStatus");
            lblstatus.Font.Bold = true;

            if (lblstatus.Text == "Pending")
            {
                GVInfo.Rows[i].Cells[6].BackColor = System.Drawing.Color.Orange;
                lblstatus.ForeColor = System.Drawing.Color.White;
            }

        }
    }
    protected void GVInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVInfo.PageIndex = e.NewPageIndex;
        //gridbind();
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
                                              "empcode,empname,desg,stockrole,username,field7,field2,estimateno,estid,grtime,remarks FROM stockreceipttable " +
                                                " where rtxno={0} "
                                                , k);

            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {                            
                Tr20.Visible = true;
                ddstore.SelectedItem.Text = ds.Tables[0].Rows[0]["storename"].ToString();
                ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["linename"].ToString();
                ddestimate.SelectedItem.Text = ds.Tables[0].Rows[0]["estimateno"].ToString();
                ddstatus.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
                txtsrwno.Text = ds.Tables[0].Rows[0]["storechallanno"].ToString();
                txtsrwdate.Text = ds.Tables[0].Rows[0]["srwchallanDate"].ToString();
                txtpono.Text = ds.Tables[0].Rows[0]["pono"].ToString();
                txtpodate.Text = ds.Tables[0].Rows[0]["podate"].ToString();
                dditemtype.SelectedItem.Text = ds.Tables[0].Rows[0]["itype"].ToString();
                dditemname.SelectedItem.Text = ds.Tables[0].Rows[0]["itemname"].ToString();
                txtunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
                txtrquantity.Text = ds.Tables[0].Rows[0]["qtyrecd"].ToString();
                txtsrno.Text = ds.Tables[0].Rows[0]["syear"].ToString();
                txtremarks.Text = ds.Tables[0].Rows[0]["remarks"].ToString();
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
        calfunction();
    }
    protected void btCancel1_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePageSubDivison.aspx?F=0");
    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;

        if (Proceed.Text == "Save")
        {
            DataSet ds;
        string qry = string.Format("select storechallanno,goodstype,itemcode,itemname from stockreceipttable " +
                                   " where storechallanno='{0}' and itemcode='{1}' and goodstype='{2}' and subdivid={3} " +
                                       " and smonth = '{4}' "
                                    , txtsrwno.Text, dditemname.SelectedValue, ddstatus.SelectedItem.Text, Session["subdivisonid"], "GRSRW");
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
            if (txtsrwno.Text == ds.Tables[0].Rows[0]["storechallanno"].ToString() && dditemname.SelectedValue == ds.Tables[0].Rows[0]["itemcode"].ToString() && ddstatus.SelectedItem.Text == ds.Tables[0].Rows[0]["goodstype"].ToString())
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


                else
                {

                    string scmdText = " BEGIN ";
                    DateTime grdate = new DateTime();
                    DateTime sysdate = new DateTime();
                    string sysTime = (System.DateTime.Now).ToString("HH:mm:ss");
                  //  grdate = Convert.ToDateTime(txtgrdate.Text);
                    sysdate = Convert.ToDateTime((System.DateTime.Now).ToString("dd-MM-yyyy"));
                    String srchdate, systemdate;
                    srchdate = grdate.ToString("yyyy-MM-dd");
                    systemdate = sysdate.ToString("yyyy-MM-dd");
                    scmdText += string.Format("Insert into stockreceipttable (smonth,syear,scurdate,storename,grbookno,grpageno,grdate,stockstatus, " +
                                              "lineid,linename,subdivid,subdiv,divid,division,firmid,firmname,pstclstore,goodstype, " +
                                              "stockrecddate,stockinspectdate,storechallanno,srwchallanDate,pono,podate,grpid,grgrphead,subgrpid,grsubgrphead,itemno,itype,itemcode,itemname, " +
                                              "unit,qtyrecd,qtyaccepted,rate,subtotal,edpercentage,cesspercentage,highereducesspercentage,total,cstvatpercentage,freight,insurance,field4,grandtotal, " +
                                              "empcode,empname,desg,stockrole,username,subdivstatusid,subdivstatus,estimateno,estid,grtime,remarks,field2,field7)" +
                                              " VALUES ( '{0}' ,'{1}','{2}','{3}',{4},{5},'{6}','{7}', " +
                                              " {8},'{9}', {10},'{11}', {12},'{13}', {14},'{15}','{16}','{17}', " +
                                              " '{18}','{19}','{20}','{21}','{22}','{23}',{24},'{25}',{26},'{27}',{28},'{29}','{30}','{31}', " +
                                              " '{32}',{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45}, " +
                                              " '{46}','{47}','{48}','{49}','{50}',{51},'{52}','{53}',{54},'{55}','{56}','{57}',{58}) "
                                              , "GRSRW", txtsrno.Text, systemdate, ddstore.SelectedItem.Text, 1, 1, systemdate, "Work",
                                                ddline.SelectedValue, ddline.SelectedItem.Text, Session["subdivisonid"], Session["subdivison"], Session["divisonid"], Session["divison"], 100000, "NA", "NA", ddstatus.SelectedItem.Text,
                                              "", "", txtsrwno.Text, txtsrwdate.Text, txtpono.Text, txtpodate.Text, 10, "", 10, "", dditemtype.SelectedValue, dditemtype.SelectedItem.Text, dditemname.SelectedValue, dditemname.SelectedItem.Text,
                                             txtunit.Text, Convert.ToDecimal(txtrquantity.Text), 0.00, 0.00,0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00,
                                              "", "", "", Session["RoleN"].ToString(), Session["UI"].ToString(), 1, "Pending", ddestimate.SelectedItem.Text, ddestimate.SelectedValue, sysTime, txtremarks.Text,"Pending",1);


                    scmdText += " END ";
                    DBConnection.executeNonQuery(scmdText);
                    showMsg(lblmsg, Color.Red, "Saved Successfully!");
                    Label2.Visible = false;
                   // Label3.Visible = false;
                    gridbind();
                   // ddstorebind();
                   // DDLine();
                   // DDEstimate();
                    DDGoodsType();
                    DDTypebind();
                    DDNameItembind();
                    txtunitbind();
                }
            }
        }
        else if (Proceed.Text == "Update")
        {
            string scmdText = " BEGIN ";
            DateTime grdate = new DateTime();
            DateTime sysdate = new DateTime();
            string sysTime = (System.DateTime.Now).ToString("HH:mm:ss");
           // grdate = Convert.ToDateTime(txtgrdate.Text);
            sysdate = Convert.ToDateTime((System.DateTime.Now).ToString("dd-MM-yyyy"));
            String srchdate, systemdate;
            srchdate = grdate.ToString("yyyy-MM-dd");
            systemdate = sysdate.ToString("yyyy-MM-dd");
            scmdText += string.Format(" UPDATE stockreceipttable SET qtyrecd = {0}, syear = '{1}', remarks = '{2}' " +
                                      " WHERE rtxno = {3} "
                                          , Convert.ToDecimal(txtrquantity.Text), txtsrno.Text, txtremarks.Text,i);
            scmdText += " END ";
            DBConnection.executeNonQuery(scmdText);
            showMsg(lblmsg, Color.Red, "Updated Successfully!");
            txtbox.Visible = false;
            can.Visible = true;
            calfunction();
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
        calfunction();
    }
    protected void btnapproval_Click(object sender, EventArgs e)
    {        
        lblmsg.Visible = true;
        string scmdText = " BEGIN ";
        scmdText += string.Format(" UPDATE stockreceipttable SET subdivstatusid={0}, field2 = '{1}' " +
                                 " WHERE  rtxno={2} "
                                  , 2,"Pending", i);
        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        showMsg(lblmsg, Color.Red, "Successfully Sent for Approval!");
        txtbox.Visible = false;
        gridbind();
        clear();
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = false;
        unreadonlytext();
        DataSet ds;
        string qry = string.Format(" delete from stockreceipttable " +
                                   " where rtxno={0} and storechallanno = '{1}' "
                                    , i, txtsrwno.Text);
        ds = DBConnection.fillDataSet(qry);
        ds.Clear();
        ds.Dispose();
       // gridbind();
        lblMessage2.Text = "[Data Delete Successfully.]";
        lblMessage2.Visible = true;
        txtbox.Visible = false;
        can.Visible = true;
        calfunction();
    }
    protected void txtrquantity_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }

    protected void dditemtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind();
        DDGoodsType();
        txtunitbind();
       // txtquantitystore();
    }
    protected void dditemname_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDGoodsType();
        txtunitbind();
    }
   
    protected void ddline_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDEstimate();
        DDTypebind();
        DDNameItembind();
        DDGoodsType();
        txtunitbind();  
    }
    protected void ddestimate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDTypebind();
        DDNameItembind();
        DDGoodsType();
        txtunitbind();
    }
}