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
public partial class Inventory_SubdivisonSR : System.Web.UI.Page
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
            ddstorebind();
            DDLine();
            DDEstimate();           
            DDTypebind();
            DDNameItembind();
            DDGoodsType();
            txtunitbind();
            txtquantitystore();
           
            txtbox.Visible = false; 
        }
        lblaeeremarks.Visible = false;
    }
    private void CallFunction()
    {
        gridbind();
        ddstorebind();
        DDLine();
        DDEstimate();       
        DDTypebind();
        DDNameItembind();
        DDGoodsType();
        txtunitbind();
        txtquantitystore();
    }
    private void readonlytext()
    {
        ddestimate.Enabled = false;
        ddline.Enabled = false;
        ddgoodstype.Enabled = false;
        dditemtype.Enabled = false;
        dditemname.Enabled = false;
        txtunit.ReadOnly = true;
        txtqty.ReadOnly = true;
        txtqtydrwn.ReadOnly = true;
        txtcontractor.ReadOnly = true;
        txtje.ReadOnly = true;
        txtsdo.ReadOnly = true;
        ddstore.Enabled = false;
    }

    private void unreadonlytext()
    {
        ddestimate.Enabled = true;
        ddline.Enabled = true;
        ddgoodstype.Enabled = true;
        dditemtype.Enabled = true;
        dditemname.Enabled = true;
        txtunit.ReadOnly = false;
        txtqty.ReadOnly = false;
        txtqtydrwn.ReadOnly = false;
        txtcontractor.ReadOnly = false;
        txtje.ReadOnly = false;
        txtsdo.ReadOnly = false;
        ddstore.Enabled = true;
    }
    private void allclear()
    {
        txtsrbook.Text = "";
        txtsrpage.Text = "";
        txtqtyindent.Text = "0.000";
        txtsrdate.Text = "dd-mm-yyyy";

    }
    private void clear()
    {
       // txtsrbook.Text = "";
       // txtsrpage.Text = "";
        txtqtyindent.Text = "0.000";
       // txtsrdate.Text = "dd-mm-yyyy";
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
   
    private void gridbind()
    {
        string qry = string.Format("SELECT itxno,srchallanbookno,srchallanpageno,srchallandate,nameofestimate,stockitemname,qtyindented,subdivstatus FROM stockissuetable " +
                                   "where subdivid={0} and subdivstatusid = {1} and username = '{2}'" +
                                   "order by subdivstatus desc,itxno desc"
                                   , Session["subdivisonid"], 1, Session["UI"]);
        //string qry = string.Format("SELECT itxno,srchallanbookno,srchallanpageno,srchallandate,nameofestimate,stockitemname,qtyindented,subdivstatus FROM stockissuetable " +
        //                            "where istore='{0}' and subdivid={1} and subdivstatusid = {2} " +
        //                            "order by subdivstatus desc,itxno desc"
        //                            , Session["StoreName"].ToString(), Session["subdivisonid"], 1);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }

    private void ddstorebind()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("SELECT  storeid,storename from tblmasterstore where storeid = 0  union all SELECT distinct storeid,storename from tblmasterstore where storeid <> 0 order by storeid");
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
        ddgoodstype.DataTextField = ds.Tables[0].Columns["goodstype"].ToString();
        ddgoodstype.DataValueField = ds.Tables[0].Columns["goodstype"].ToString();
        ddgoodstype.DataSource = ds.Tables[0];
        ddgoodstype.DataBind();
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
            txtqty.Text = ds.Tables[0].Rows[0]["qtysanctioned"].ToString();
            txtqtydrwn.Text = ds.Tables[0].Rows[0]["qtydrawn"].ToString();
            txtcontractor.Text = ds.Tables[0].Rows[0]["contractor"].ToString();
            //txtje.Text = ds.Tables[0].Rows[0]["jename"].ToString();
            //txtsdo.Text = ds.Tables[0].Rows[0]["sdoname"].ToString();
            txtje.Text = Session["employeename"].ToString();
            txtsdo.Text = Session["employeecode"].ToString();
        }

        ds.Clear();
        ds.Dispose();
    }
    private void txtquantitystore()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("select (isnull(r.receivedqty ,0)  - isnull(i.issuedqty1,0)) as availableqty from (select  itemcode ,itemname, sum(qtyaccepted) as receivedqty from stockreceipttable " +
                                   " where field2='OK' and field7=2 and itemcode = '{0}' and storename = '{1}' and goodstype = '{2}' group by itemname,itemcode ) r left outer join (select stockitemcode,stockitemname,sum(issuedqty) as issuedqty1 from stockissuetable where stockitemcode = '{3}' and istore = '{4}'  and goodstype = '{5}' group by  stockitemname,stockitemcode) i on r.itemname = i.stockitemname "
                                    , dditemname.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype.SelectedItem.Text, dditemname.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype.SelectedItem.Text);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtstrqty.Text = ds.Tables[0].Rows[0]["availableqty"].ToString();
        }
        else
        {
            txtstrqty.Text = "0.000";
        }
        ds.Clear();
        ds.Dispose();
    }
    private void showMsg(Label lbl, Color color, string msg)
    {
        lbl.ForeColor = color;
        lbl.Text = msg;
    }
    protected void btsearch_Click(object sender, EventArgs e)
    {

    }
    protected void btsearchcancel_Click(object sender, EventArgs e)
    {

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        CallFunction();
        lblMessage2.Visible = false;
        lblmsg.Visible = false;
        lblmsg1.Visible = false;
        btndel.Visible = false;
        btnapproval.Visible = false;
        txtbox.Visible = true;
        Proceed.Text = "Save";
        Proceed.Visible = true;
        allclear();
        unreadonlytext();
        Label2.Visible = false;
    }
    protected void btCancel1_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePageSubDivison.aspx?F=0");
    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        lblmsg1.Visible = false;
        lblmsg.Visible = true;
        if (Proceed.Text == "Save")
        {
            if (Convert.ToDecimal(txtqtyindent.Text) <= (Convert.ToDecimal(txtqty.Text) - Convert.ToDecimal(txtqtydrwn.Text)))
            {
                DataSet ds;
                string qry = string.Format("select srchallanbookno,srchallanpageno,srchallandate,goodstype,estimateno,stockitemyype,stockitemcode,stockitemname,unit, " +
                                           " ifield2,ifield3,stockstatus from dbo.stockissuetable " +
                                           " where srchallanbookno='{0}' and srchallanpageno='{1}' and stockitemcode='{2}' and goodstype='{3}' and istore='{4}' " +
                                           " and issuetype = '{5}' "
                                            ,txtsrbook.Text,txtsrpage.Text,dditemname.SelectedValue,ddgoodstype.SelectedItem.Text, ddstore.SelectedItem.Text,"SR");
                ds = DBConnection.fillDataSet(qry);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    if (txtsrbook.Text == ds.Tables[0].Rows[0]["srchallanbookno"].ToString() && txtsrpage.Text == ds.Tables[0].Rows[0]["srchallanpageno"].ToString() && dditemname.SelectedValue == ds.Tables[0].Rows[0]["stockitemcode"].ToString() && ddgoodstype.SelectedItem.Text == ds.Tables[0].Rows[0]["goodstype"].ToString())
                    {
                        showMsg(lblmsg, Color.Red, "Record already Exits!");
                    }

                    ds.Clear();
                    ds.Dispose();
                }
                else
                {
                    if (ddstore.SelectedItem.Text == "....")
                    {
                        Label2.Visible = true;
                        // ClientScript.RegisterClientScriptBlock(this.GetType(), "ddd", "<script>alert('Select Item Type')</script>");
                        showMsg(Label2, Color.Red, "Select Store Name!");
                        return;
                    }

                    else
                    {
                        string scmdText = " BEGIN ";
                        DateTime srdate = new DateTime();
                        DateTime sysdate = new DateTime();
                        string sysTime = (System.DateTime.Now).ToString("HH:mm:ss");
                        srdate = Convert.ToDateTime(txtsrdate.Text);
                        sysdate = Convert.ToDateTime((System.DateTime.Now).ToString("dd-MM-yyyy"));
                        String srchdate, systemdate;
                        srchdate = srdate.ToString("yyyy-MM-dd");
                        systemdate = sysdate.ToString("yyyy-MM-dd");
                        scmdText += string.Format("Insert into stockissuetable (issuetype,istore,icurdate,srchallanbookno,srchallanpageno,srchallandate, " +
                                                  " estimateno,nameofsubdivision,nameofdivision,contractorname,nameofestimate,stockitemyype,stockitemcode,stockitemname," +
                                                  " goodstype,unit,totalqtyestimate,qtydrawntilldate,qtyindented," +
                                                  " issuedqty,qtyvalue,storagecharges,totalvalue,grandtotal,recdempname,recdsdoname," +
                                                 "  userrole,username,ifield2,ifield7,stockstatus," +
                                                  " subdivid,divid,lineid,linename,subdivstatus,subdivstatusid,itemtypecode,srchtime)" +
                                                  " VALUES ( '{0}' ,'{1}','{2}','{3}','{4}','{5}', " +
                                                  " '{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}'," +
                                                  "  '{14}','{15}',{16},{17},{18}, " +
                                                  " {19},{20},{21},{22},{23},'{24}','{25}'," +
                                                  " '{26}','{27}','{28}',{29},'{30}'," +
                                                  "  {31},{32},{33},'{34}','{35}',{36},{37},'{38}') "
                                                  , "SR", ddstore.SelectedItem.Text, systemdate, txtsrbook.Text, txtsrpage.Text, srchdate,
                                                     ddestimate.SelectedValue, Session["subdivison"], Session["divison"], txtcontractor.Text, ddestimate.SelectedItem.Text, dditemtype.SelectedItem.Text, dditemname.SelectedValue, dditemname.SelectedItem.Text,
                                                    ddgoodstype.SelectedItem.Text, txtunit.Text, Convert.ToDecimal(txtqty.Text), Convert.ToDecimal(txtqtydrwn.Text), Convert.ToDecimal(txtqtyindent.Text),
                                                    0.000, 0.000, 0.000, 0.000, 0.000, txtje.Text, txtsdo.Text,
                                                     Session["RoleN"], Session["UI"], "Pending", 1, "Work",
                                                      Session["subdivisonid"], Session["divisonid"], ddline.SelectedValue, ddline.SelectedItem.Text, "Pending", 1, dditemtype.SelectedValue, sysTime);
                        scmdText += " END ";
                        DBConnection.executeNonQuery(scmdText);
                        showMsg(lblmsg, Color.Red, "Saved Successfully!");
                        clear();
                        gridbind();
                        Label2.Visible=false;
                    }
                }
            }
            else
            {
                lblmsg1.Visible = true;
                showMsg(lblmsg1, Color.Red, "Indented Quantity must be less than or equal to balance Estimate Quantity!");
            }
        }
        else if (Proceed.Text == "Update")
        {
            if (Convert.ToDecimal(txtqtyindent.Text) <= (Convert.ToDecimal(txtqty.Text) - Convert.ToDecimal(txtqtydrwn.Text)))
            {
                DataSet ds;
                string qry = string.Format("select srchallanbookno,srchallanpageno,srchallandate,goodstype,estimateno,stockitemyype,stockitemcode,stockitemname,unit, " +
                                           " ifield2,ifield3,stockstatus,qtyindented from dbo.stockissuetable " +
                                           " where srchallanbookno='{0}' and srchallanpageno='{1}' and stockitemcode='{2}' and goodstype='{3}' and istore='{4}' " +
                                           " and issuetype = '{5}' and qtyindented = {6} "
                                            , txtsrbook.Text, txtsrpage.Text, dditemname.SelectedValue, ddgoodstype.SelectedItem.Text, ddstore.SelectedItem.Text, "SR",
                                            Convert.ToDecimal(txtqtyindent.Text));
                ds = DBConnection.fillDataSet(qry);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    if (txtsrbook.Text == ds.Tables[0].Rows[0]["srchallanbookno"].ToString() && txtsrpage.Text == ds.Tables[0].Rows[0]["srchallanpageno"].ToString() && dditemname.SelectedValue == ds.Tables[0].Rows[0]["stockitemcode"].ToString() && ddgoodstype.SelectedItem.Text == ds.Tables[0].Rows[0]["goodstype"].ToString() && txtqtyindent.Text == ds.Tables[0].Rows[0]["qtyindented"].ToString())
                    {
                        showMsg(lblmsg, Color.Red, "Record already Exits!");
                        txtbox.Visible = false;
                    }

                    ds.Clear();
                    ds.Dispose();
                }
                else
                {
                    string scmdText = " BEGIN ";
                    scmdText += string.Format(" UPDATE stockissuetable SET srchallanbookno = '{0}', srchallanpageno = '{1}', srchallandate = '{2}', qtyindented = {3} " +
                                                 " WHERE itxno = {4} "
                                              , txtsrbook.Text, txtsrpage.Text, Convert.ToDateTime(txtsrdate.Text), txtqtyindent.Text, i);
                    scmdText += " END ";
                    DBConnection.executeNonQuery(scmdText);
                    showMsg(lblmsg, Color.Red, "Updated Successfully!");
                    txtbox.Visible = false;
                    can.Visible = true;
                    clear();
                    gridbind();
                }
            }
            else
            {
                lblmsg1.Visible = true;
                showMsg(lblmsg1, Color.Red, "Indented Quantity must be less than or equal to balance Estimate Quantity!");
                txtbox.Visible = true;
            }
    
        }
        try
        {
            //clear();
            //gridbind();
        }
        catch (Exception ex)
        {
            showMsg(lblmsg, Color.Red, "Uploaded Error : " + ex.Message);
        }
             
    }
    protected void btnCancel2_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = false;
        lblmsg1.Visible = false;
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
        lblmsg1.Visible = false;
        allclear();
        btndel.Visible = false;
        btnapproval.Visible = false;
        Proceed.Text = "Save";
        Proceed.Visible = true;
        unreadonlytext();
        can.Visible = true;
    }
    protected void btnapproval_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;
        lblmsg1.Visible = false;
        string scmdText = " BEGIN ";
        scmdText += string.Format(" UPDATE stockissuetable SET  subdivstatusid = {0} " +
                                 " WHERE srchallanbookno = '{1}' and srchallanpageno = '{2}' and itxno={3} "
                              , 2, txtsrbook.Text, txtsrpage.Text, i);
        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        showMsg(lblmsg, Color.Red, "Confirmed Successfully!");
        allclear();
        gridbind();
        txtbox.Visible = false;
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = false;
        lblmsg1.Visible = false;
        unreadonlytext();
        DataSet ds;
        string qry = string.Format(" delete from stockissuetable " +
                                   " where itxno={0} and srchallanbookno = '{1}' "
                                    , i, txtsrbook.Text);
        ds = DBConnection.fillDataSet(qry);
        ds.Clear();
        ds.Dispose();
        gridbind();
        lblMessage2.Text = "[Data Delete Successfully.]";
        lblMessage2.Visible = true;
        txtbox.Visible = false;
        can.Visible = true;
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
    protected void GVInfo_EditClick(object sender, GridViewCommandEventArgs e)
    {
        //txtquantitystore();
        lblmsg.Visible = false;
        lblmsg1.Visible = false;
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
            string qry = string.Format("SELECT srchallanbookno,srchallanpageno,srchallandate,estimateno,contractorname,nameofestimate,stockitemyype,stockitemcode,stockitemname," +
                                      " goodstype,unit,totalqtyestimate,qtydrawntilldate,qtyindented, recdempname,recdsdoname,lineid,linename,itemtypecode,istore FROM stockissuetable " +
                                      " where itxno={0} ", k);

            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                    ddstore.SelectedItem.Text = ds.Tables[0].Rows[0]["istore"].ToString();
                    ddestimate.SelectedItem.Text = ds.Tables[0].Rows[0]["nameofestimate"].ToString();
                    ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["linename"].ToString();
                    ddgoodstype.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
                    dditemtype.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemyype"].ToString();
                    dditemname.Items.Clear();
                    dditemname.Items.Add(new ListItem(ds.Tables[0].Rows[0]["stockitemname"].ToString(), ds.Tables[0].Rows[0]["stockitemcode"].ToString()));
            
                //dditemname.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemname"].ToString();
                    txtunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
                    txtqty.Text = ds.Tables[0].Rows[0]["totalqtyestimate"].ToString();
                    txtcontractor.Text = ds.Tables[0].Rows[0]["contractorname"].ToString();
                    txtje.Text = ds.Tables[0].Rows[0]["recdempname"].ToString();
                    txtsdo.Text = ds.Tables[0].Rows[0]["recdsdoname"].ToString();
                    txtqtydrwn.Text = ds.Tables[0].Rows[0]["qtydrawntilldate"].ToString();
                    txtsrbook.Text = ds.Tables[0].Rows[0]["srchallanbookno"].ToString();
                    txtsrpage.Text = ds.Tables[0].Rows[0]["srchallanpageno"].ToString();
                    txtsrdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["srchallandate"]).ToString("dd-MM-yyyy");
                    txtqtyindent.Text = ds.Tables[0].Rows[0]["qtyindented"].ToString();

                    txtquantitystore();
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
    protected void dditemtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind();
        DDGoodsType();
        txtunitbind();
        txtquantitystore();
    }
   
    protected void dditemname_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDGoodsType();
        txtunitbind();
        txtquantitystore();
    }
    protected void ddestimate_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DDLine();
        DDTypebind();
        DDNameItembind();
        DDGoodsType();
        txtunitbind();
        txtquantitystore();
    }

    protected void ddline_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDEstimate();
        DDTypebind();
        DDNameItembind();
        DDGoodsType();
        txtunitbind();
        txtquantitystore();
    }
    
    protected void ddstore_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtquantitystore();
    }
}