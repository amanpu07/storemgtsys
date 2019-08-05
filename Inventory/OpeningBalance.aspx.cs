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

public partial class Inventory_OpeningBalance : System.Web.UI.Page
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
            DDGoodsType();
            DDTypebind();
            DDNameItembind();
            txtunitbind();
            Label2.Visible = false;
        }
        lblaeeremarks.Visible = false;
    }
    private void gridbind()
    {
        string qry = string.Format("SELECT rtxno,grpageno,grbookno,grdate,itemname,unit,grandtotal,field2,goodstype,itype FROM stockreceipttable " +
                                    "where smonth='GROpeningbalance' and storename='{0}' and  grbookno=100000" +
                                    " order by field2 desc,rtxno desc "
                                    , Session["StoreName"].ToString());
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
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
       txttotal.Text = Convert.ToString(Math.Round(d5)) + ".00";
        //Calculate Grand Total
        d6 = Math.Round((Convert.ToDecimal(txttotal.Text) * Convert.ToDecimal(txtvat.Text)) / 100); // calculate vat
        txtgrandtotal.Text = Convert.ToString(Math.Round((Convert.ToDecimal(txttotal.Text) + (Convert.ToDecimal(txttotal.Text) * Convert.ToDecimal(txtvat.Text)) / 100 + Convert.ToDecimal(txtfreight.Text) + Convert.ToDecimal(txtprcvar.Text)))) + ".00";

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
        DDGoodsType();
        DDTypebind();
        DDNameItembind();
        txtunitbind();
    }
    private void allclear()
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
        DDGoodsType();
        DDTypebind();
        DDNameItembind();
        txtunitbind();
    }
    private void readonlytext()
    {
        dditemtype.Enabled = false;
        dditemname.Enabled = false;
        txtunit.ReadOnly = true;
        ddstatus.Enabled = false;
    }

    private void unreadonlytext()
    {
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
        for (int i = 0; i <= GVInfo.Rows.Count - 1; i++)
        {
            Label lblstatus = (Label)GVInfo.Rows[i].FindControl("lblgridStatus");
            lblstatus.Font.Bold = true;

            if (lblstatus.Text == "Pending")
            {
                GVInfo.Rows[i].Cells[6].BackColor = System.Drawing.Color.Orange;
                lblstatus.ForeColor = System.Drawing.Color.White;
            }
            else if (lblstatus.Text == "OK")
            {
                GVInfo.Rows[i].Cells[6].BackColor = System.Drawing.Color.Green;
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
                                              "empcode,empname,desg,stockrole,username,field7,field2,estimateno,estid,grtime FROM stockreceipttable " +
                                                " where rtxno={0} "
                                                , k);

            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {

                if (ds.Tables[0].Rows[0]["field2"].ToString() == "OK")
                {
                    ButtonInVisible();
                    ddstatus.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
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
                }
                else
                {
                    ButtonVisible();
                    ddstatus.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
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
                }
            
            }
            ds.Clear();
            ds.Dispose();
            Proceed.Text = "Update";
            can.Visible = true;
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
        Label3.Text = (System.DateTime.Now).ToString("dd-MM-yyyy");
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
                                       " where goodstype='{0}' and itemcode='{1}' " +
                                       "  and storename='{2}' and  grbookno=100000"
                                        , ddstatus.SelectedItem.Text, dditemname.SelectedValue, Session["StoreName"].ToString());
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (ddstatus.SelectedItem.Text == ds.Tables[0].Rows[0]["goodstype"].ToString() && dditemname.SelectedValue == ds.Tables[0].Rows[0]["itemcode"].ToString() && ds.Tables[0].Rows[0]["grbookno"].ToString() == "100000")
                {
                    showMsg(lblmsg, Color.Red, "Opening Balance already Exits!");
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
                            DateTime grdate = new DateTime();
                            DateTime sysdate = new DateTime();
                            string sysTime = (System.DateTime.Now).ToString("HH:mm:ss");
                            // grdate = Convert.ToDateTime(txtgrdate.Text);
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
                                                      , "GROpeningbalance", "", systemdate, Session["StoreName"], 100000, 100000, "2017-12-31", "Firm",
                                                        100000, "NA", 100000, "NA", 100000, "NA", 100000, "NA", "NA", ddstatus.SelectedItem.Text,
                                                      "", "", "", "", "", "", 100, "", 100, "", dditemtype.SelectedValue, dditemtype.SelectedItem.Text, dditemname.SelectedValue, dditemname.SelectedItem.Text,
                                                     txtunit.Text, Convert.ToDecimal(txtrvalue.Text), Convert.ToDecimal(txtrvalue.Text), Convert.ToDecimal(txtrate.Text), Convert.ToDecimal(Convert.ToDecimal(txtrvalue.Text) * Convert.ToDecimal(txtrate.Text)), Convert.ToDecimal(txted.Text), Convert.ToDecimal(txtcess.Text), Convert.ToDecimal(txtheducess.Text), Convert.ToDecimal(txttotal.Text), Convert.ToDecimal(txtvat.Text), Convert.ToDecimal(txtfreight.Text), 0.00, Convert.ToDecimal(txtprcvar.Text), Convert.ToDecimal(txtgrandtotal.Text),
                                                      "", "", "", Session["RoleN"].ToString(), Session["UI"].ToString(), 1, "Pending", "", 0, sysTime);


                            scmdText += " END ";
                            DBConnection.executeNonQuery(scmdText);
                            showMsg(lblmsg, Color.Red, "Saved Successfully!");
                            Label2.Visible = false;
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
            scmdText += string.Format(" UPDATE stockreceipttable SET qtyrecd = {0} ,qtyaccepted = {1} ,rate = {2}, " +
                                      " edpercentage = {3} ,cesspercentage = {4} ,highereducesspercentage = {5} ,cstvatpercentage = {6} ,freight = {7}, " +
                                      " field4 = {8} , subtotal = {9}, total = {10}, grandtotal = {11} " +
                                      " WHERE rtxno = {12} "
                                          , Convert.ToDecimal(txtrvalue.Text),
                                          Convert.ToDecimal(txtrvalue.Text), Convert.ToDecimal(txtrate.Text), Convert.ToDecimal(txted.Text), Convert.ToDecimal(txtcess.Text),
                                          Convert.ToDecimal(txtheducess.Text), Convert.ToDecimal(txtvat.Text), Convert.ToDecimal(txtfreight.Text),
                                          Convert.ToDecimal(txtprcvar.Text),  Convert.ToDecimal(Convert.ToDecimal(txtrvalue.Text) * Convert.ToDecimal(txtrate.Text)), Convert.ToDecimal(txttotal.Text), Convert.ToDecimal(txtgrandtotal.Text), i);
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
        scmdText += string.Format(" UPDATE stockreceipttable SET field2='{0}',field7={1} " +
                                 " WHERE  rtxno={2} "
                                  , "OK",2, i);
        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        showMsg(lblmsg, Color.Red, "Successfully Approved!");
        txtbox.Visible = true;
        gridbind();
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;
        unreadonlytext();
        DataSet ds;
        string qry = string.Format(" delete from stockreceipttable " +
                                   " where rtxno={0} "
                                    , i);
        ds = DBConnection.fillDataSet(qry);
        ds.Clear();
        ds.Dispose();
        gridbind();
        lblMessage2.Text = "[Data Delete Successfully.]";
        lblMessage2.Visible = true;
        txtbox.Visible = false;
        can.Visible = true;
    }
    protected void txtrquantity_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
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
   
    protected void dditemtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind();
        txtunitbind();
    }
    protected void dditemname_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtunitbind();
    }
   
}