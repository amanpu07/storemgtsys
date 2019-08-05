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
public partial class Inventory_SubdivisonMCR : System.Web.UI.Page
{
    static int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["StoreName"] == null || Session["UI"] == null)
        {
            Response.Redirect("../Home/LoginPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            gridbind();
            DDEstimate();
            DDLine();
            DDGoodsType();
            DDTypebind();
            DDNameItembind();
            txtunitbind();
            DDLineSearch();
            DDEstimateSearch();
            txtbox.Visible = false;
            employeename();
            txtje.ReadOnly = true;
            txtsdo.ReadOnly = true;
            // panelVisibilityHidden(); 
        }
        lblaeeremarks.Visible = false;
    }
    private void CallFunction()
    {
        gridbind();
      //  DDLine();
      //  DDEstimate();
        
        DDGoodsType();
        DDTypebind();
        DDNameItembind();
        txtunitbind();
    }
    private void readonlytext()
    {
        ddestimate.Enabled = false;
        ddline.Enabled = false;
        ddgoodstype.Enabled = false;
        dditemtype.Enabled = false;
        dditemname.Enabled = false;
        txtunit.ReadOnly = true;
        txtje.ReadOnly = true;
        txtsdo.ReadOnly = true;
    }

    private void unreadonlytext()
    {
        ddestimate.Enabled = true;
        ddline.Enabled = true;
        ddgoodstype.Enabled = true;
        dditemtype.Enabled = true;
        dditemname.Enabled = true;
        txtunit.ReadOnly = false;
    }
    private void allclear()
    {
        txtqty.Text = "0.000";
        txtcontractor.Text = "";
        //txtje.Text = "";
        //txtsdo.Text = "";

    }
    private void clear()
    {
        txtqty.Text = "0.000";
        //txtcontractor.Text = "";
        //txtje.Text = "";
        //txtsdo.Text = "";
        //bindunit(); //flag
        //txtunit.SelectedItem.Text = "....";//flag
        //bindtype();
        //bindname();
        //dditemtype.SelectedItem.Text = "....";
        //dditemname.SelectedItem.Text = "....";
    }
    private void gridbind()
    {
        string qry = string.Format("SELECT etxno,estid,estimate,subdivisionid,subdivisionname,divid,divisonname,Lineid,LineName,itemtype,itemcode,itemname,unit,goodstype,qtysanctioned,qtydrawn,contractor,jename,sdoname,Estatus,typecode FROM MCR " +
                                    "where subdivisionid={0} " +
                                    "order by Estatus desc,LineName,estid,etxno desc"
                                    , Session["subdivisonid"]);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    private void DDEstimate()
    {
        if (ddlinesearch.SelectedItem.Text == "NIL")
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
    private void DDEstimateSearch()
    {
        if (ddlinesearch.SelectedItem.Text == "NIL")
        {

        }
        else
        {
            //System.Threading.Thread.Sleep(5000);
            DataSet ds;

            string qry = string.Format("SELECT estid,estimate from EstimateMaster" +
                                       " where subdivisionid={0} and LineCode={1} and Estatus='{2}' " +
                                       "order by estimate"
                                        , Session["subdivisonid"], ddlinesearch.SelectedValue, "OK");
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count == 0)
            {
                qry = "SELECT 'NIL' estid, 'NIL' estimate";
                ds = DBConnection.fillDataSet(qry);
            }
            ddestimatesearch.DataTextField = ds.Tables[0].Columns["estimate"].ToString();
            ddestimatesearch.DataValueField = ds.Tables[0].Columns["estid"].ToString();
            ddestimatesearch.DataSource = ds.Tables[0];
            ddestimatesearch.DataBind();
            ds.Clear();
            ds.Dispose();
        }
    }
    private void employeename()
    {
        DataSet ds;
        string qry = string.Format("SELECT employeecode,employeename from tbllogin" +
                                   " where username='{0}'  "                                   
                                    ,Session["UI"]);
         ds = DBConnection.fillDataSet(qry);
         if (ds.Tables[0].Rows.Count != 0)
         {

             txtje.Text = ds.Tables[0].Rows[0]["employeename"].ToString();
             txtsdo.Text = ds.Tables[0].Rows[0]["employeecode"].ToString();
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
    private void DDLineSearch()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("SELECT Lineid,LineName from LineMaster" +
                                   " where subdivisionid={0} and Estatus='{1}' " +
                                   "order by LineName"
                                    , Session["subdivisonid"], "OK" );
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' Lineid, 'NIL' LineName";
            ds = DBConnection.fillDataSet(qry);
        }
        ddlinesearch.DataTextField = ds.Tables[0].Columns["LineName"].ToString();
        ddlinesearch.DataValueField = ds.Tables[0].Columns["Lineid"].ToString();
        ddlinesearch.DataSource = ds.Tables[0];
        ddlinesearch.DataBind();
        ds.Clear();
        ds.Dispose();
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
        ddgoodstype.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
        ddgoodstype.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
        ddgoodstype.DataSource = ds.Tables[0];
        ddgoodstype.DataBind();
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
    protected void dditemtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind();
        txtunitbind();
    }
    protected void dditemname_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtunitbind();
    }
    private void calculateValues()
    {
        if (txtqty.Text == "")
        {
            txtqty.Text = "00.000";
        }
       
    }
    private void ButtonInVisible()
    {
        btnapproval.Visible = false;
        btndel.Visible = false;
        Proceed.Visible = false;
    }
    private void ButtonVisible()
    {
        btnapproval.Visible = true;
        btndel.Visible = true;
        Proceed.Visible = true;
    }
    private void showMsg(Label lbl, Color color, string msg)
    {
        lbl.ForeColor = color;
        lbl.Text = msg;
    }
    protected void txtqty_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
        txtcontractor.Focus();
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        CallFunction();
        lblMessage2.Visible = false;
        lblmsg.Visible = false;
        btndel.Visible = false;
        btnapproval.Visible = false;
        txtbox.Visible = true;
        Proceed.Text = "Save";
        Proceed.Visible = true;
        allclear();
        unreadonlytext();
        DDLine();
        DDEstimate();
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
             string qry = string.Format("select estid,estimate,subdivisionid,subdivisionname,divid,divisonname,Lineid,LineName,itemtype," +
                                                  " itemcode,itemname,unit,goodstype,qtysanctioned,qtydrawn,contractor,jename,sdoname,Estatus,typecode from MCR " +
                                               " where estid={0} and Lineid={1} and itemcode='{2}' and goodstype='{3}' "
                                                , Convert.ToInt32(ddestimate.SelectedValue), Convert.ToInt32(ddline.SelectedValue), dditemname.SelectedValue, ddgoodstype.SelectedItem.Text);
                    ds = DBConnection.fillDataSet(qry);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        if (Convert.ToInt32(ddestimate.SelectedValue) == Convert.ToInt32(ds.Tables[0].Rows[0]["estid"].ToString()) && Convert.ToInt32(ddline.SelectedValue) == Convert.ToInt32(ds.Tables[0].Rows[0]["Lineid"].ToString()) && dditemname.SelectedValue == ds.Tables[0].Rows[0]["itemcode"].ToString() && ddgoodstype.SelectedItem.Text == ds.Tables[0].Rows[0]["goodstype"].ToString())
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

                        else
                        {
                            string scmdText = " BEGIN ";
                            scmdText += string.Format("Insert into MCR (estid,estimate,storename,subdivisionid,subdivisionname,divid,divisonname,Lineid,LineName,itemtype," +
                                                      " itemcode,itemname,unit,goodstype,qtysanctioned,qtydrawn,contractor,jename,sdoname,Estatus,typecode)" +
                                                      " VALUES ( {0} ,'{1}','{2}',{3},'{4}',{5},'{6}',{7},'{8}','{9}','{10}','{11}','{12}','{13}',{14},{15},'{16}','{17}'," +
                                                      " '{18}','{19}',{20}) "
                                , ddestimate.SelectedValue, ddestimate.SelectedItem.Text, "", Session["subdivisonid"], Session["subdivison"],
                                  Session["divisonid"], Session["divison"], ddline.SelectedValue, ddline.SelectedItem.Text, dditemtype.SelectedItem.Text
                                  , dditemname.SelectedValue, dditemname.SelectedItem.Text, txtunit.Text, ddgoodstype.SelectedItem.Text, Convert.ToDecimal(txtqty.Text)
                                  , 0.000, txtcontractor.Text, Session["employeename"], Session["employeecode"], "Pending", dditemtype.SelectedValue);
                            scmdText += " END ";
                            DBConnection.executeNonQuery(scmdText);
                            showMsg(lblmsg, Color.Red, "Saved Successfully!");
                            clear();
                        }
                    }
        }
        else if (Proceed.Text == "Update")
        {
           
                        string scmdText = " BEGIN ";
                        scmdText += string.Format(" UPDATE MCR SET  qtysanctioned = {0}, contractor = '{1}' " +
                                                     " WHERE etxno = {2} "
                                                  , Convert.ToDecimal(txtqty.Text), txtcontractor.Text, i);
                        scmdText += " END ";
                        DBConnection.executeNonQuery(scmdText);
                        showMsg(lblmsg, Color.Red, "Updated Successfully!");
                        allclear();
                        txtbox.Visible = false; 
                    can.Visible = true; 
        }
        try
        {
            CallFunction();
            gridbind();
        }
        catch (Exception ex)
        {
            showMsg(lblmsg, Color.Red, "Uploaded Error : " + ex.Message);
        }
    
}
    protected void btnCancel2_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = false;
        txtbox.Visible = false;
        can.Visible = true;
        unreadonlytext();
        lblMessage2.Visible = false;
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        CallFunction();
        lblmsg.Visible = false;
        lblMessage2.Visible = false;
        allclear();
        btndel.Visible = false;
        btnapproval.Visible = false;
        Proceed.Text = "Save";
        Proceed.Visible = true;
        unreadonlytext();
        can.Visible = true;
        //DDLine();
        //DDEstimate();
    }
    protected void btnapproval_Click(object sender, EventArgs e)
    {
                lblmsg.Visible = true;
                string scmdText = " BEGIN ";
                scmdText += string.Format(" UPDATE MCR SET  Estatus = '{0}' " +
                                         " WHERE etxno = {1} and contractor = '{2}' "
                                      , "OK", i, txtcontractor.Text);
                scmdText += " END ";
                DBConnection.executeNonQuery(scmdText);
                showMsg(lblmsg, Color.Red, "Confirmed Successfully!");
                allclear();
                gridbind();
            txtbox.Visible = false;
        can.Visible = true;

    }
    protected void btsearch_Click(object sender, EventArgs e)
    {
        string qry = string.Format("SELECT etxno,estid,estimate,subdivisionid,subdivisionname,divid,divisonname,Lineid,LineName,itemtype,itemcode,itemname,unit,goodstype,qtysanctioned,qtydrawn,contractor,jename,sdoname,Estatus,typecode FROM MCR " +
                                   "where subdivisionid={0} and lineid={1} and estid={2} " +
                                   "order by Estatus desc,LineName,estid,etxno desc"
                                   , Session["subdivisonid"], ddlinesearch.SelectedValue, ddestimatesearch.SelectedValue);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    protected void btsearchcancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SubdivisonMCR.aspx");
    }
    protected void GVInfo_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i <= GVInfo.Rows.Count - 1; i++)
        {
            Label lblstatus = (Label)GVInfo.Rows[i].FindControl("lblgridStatus");
            lblstatus.Font.Bold = true;

            if (lblstatus.Text == "Pending")
            {
                GVInfo.Rows[i].Cells[7].BackColor = System.Drawing.Color.Orange;
                lblstatus.ForeColor = System.Drawing.Color.White;
            }
            else if (lblstatus.Text == "OK")
            {
                GVInfo.Rows[i].Cells[7].BackColor = System.Drawing.Color.Green;
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
            string qry = string.Format("SELECT etxno,estid,estimate,subdivisionid,subdivisionname,divid,divisonname,Lineid,LineName,itemtype,itemcode,itemname,unit,goodstype,qtysanctioned,qtydrawn,contractor,jename,sdoname,Estatus,typecode FROM MCR " +
                                                " where etxno={0} "
                                                , k);

            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (ds.Tables[0].Rows[0]["Estatus"].ToString() == "OK")
                {
                     ButtonInVisible();
                    Proceed.Visible = true;
                    ddestimate.SelectedItem.Text = ds.Tables[0].Rows[0]["estimate"].ToString();
                 //   ddestimate.SelectedValue = ds.Tables[0].Rows[0]["estid"].ToString();
                    ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["LineName"].ToString();
                   // ddline.SelectedValue = ds.Tables[0].Rows[0]["Lineid"].ToString();
                    ddgoodstype.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
                    dditemtype.SelectedItem.Text = ds.Tables[0].Rows[0]["itemtype"].ToString();
                    dditemname.SelectedItem.Text = ds.Tables[0].Rows[0]["itemname"].ToString();
                    txtunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
                    txtqty.Text = ds.Tables[0].Rows[0]["qtysanctioned"].ToString();
                    txtcontractor.Text = ds.Tables[0].Rows[0]["contractor"].ToString();
                    txtje.Text = ds.Tables[0].Rows[0]["jename"].ToString();
                    txtsdo.Text = ds.Tables[0].Rows[0]["sdoname"].ToString();
                }
                else
                {
                    ButtonVisible();
                ddestimate.SelectedItem.Text = ds.Tables[0].Rows[0]["estimate"].ToString();
              //  ddestimate.SelectedValue = ds.Tables[0].Rows[0]["estid"].ToString();
                ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["LineName"].ToString();
               // ddline.SelectedValue = ds.Tables[0].Rows[0]["Lineid"].ToString();
                ddgoodstype.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
                dditemtype.SelectedItem.Text = ds.Tables[0].Rows[0]["itemtype"].ToString();
             //   dditemtype.SelectedValue = ds.Tables[0].Rows[0]["typecode"].ToString();
                dditemname.SelectedItem.Text = ds.Tables[0].Rows[0]["itemname"].ToString();
              //  dditemname.SelectedValue = ds.Tables[0].Rows[0]["itemcode"].ToString();
                txtunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
                txtqty.Text = ds.Tables[0].Rows[0]["qtysanctioned"].ToString();
                txtcontractor.Text = ds.Tables[0].Rows[0]["contractor"].ToString();
                txtje.Text = ds.Tables[0].Rows[0]["jename"].ToString();
                txtsdo.Text = ds.Tables[0].Rows[0]["sdoname"].ToString();
                }
            }

            ds.Clear();
            ds.Dispose();
            Proceed.Text = "Update";
            can.Visible = false;
            readonlytext();
            //DDLine();
            //DDEstimate();
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
    protected void btndel_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;
        unreadonlytext();
        DataSet ds;
        string qry = string.Format(" delete from MCR " +
                                   " where etxno={0} and contractor = '{1}' "
                                    , i, txtcontractor.Text);
        ds = DBConnection.fillDataSet(qry);
        ds.Clear();
        ds.Dispose();
        gridbind();
        lblMessage2.Text = "[Data Delete Successfully.]";
        lblMessage2.Visible = true;
        txtbox.Visible = false;
        can.Visible = true;
    }
    protected void ddline_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDEstimate();
    }
 
    protected void ddlinesearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDEstimateSearch();
    }    
}