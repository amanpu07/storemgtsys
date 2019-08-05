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
public partial class Inventory_StoreJESR : System.Web.UI.Page
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
            txtquantitystore();
        }
        lblaeeremarks.Visible = false;
    }
    private void gridbind()
    {
        string qry = string.Format("SELECT itxno,nameofsubdivision,srchallanbookno,srchallanpageno,srchallandate,nameofestimate,stockitemname,qtyindented,subdivstatus,ifield2,totalqtyestimate,qtydrawntilldate FROM stockissuetable " +
                                    "where istore='{0}' and subdivstatus='{1}' and subdivstatusid={2} and ifield7={3}" +
                                    "order by itxno desc,srchallanbookno,srchallanpageno,nameofsubdivision"
                                    , Session["StoreName"].ToString(), "OK", 2 ,1);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    private void grouphead()
    {
        DataSet ds;
        string qry = string.Format("SELECT groupid, (accategory + debitac) debit from MasterGroup where groupid = 0  union all  SELECT groupid,case when debitac = '' then accategory else accategory + ' ('  + debitac + ')' end as debit  FROM MasterGroup " +
                                   "where groupid <> 0 and status=4 order by groupid");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' groupid, 'NIL' debit";
            ds = DBConnection.fillDataSet(qry);
        }
        ddgrphead.DataTextField = ds.Tables[0].Columns["debit"].ToString();
        ddgrphead.DataValueField = ds.Tables[0].Columns["groupid"].ToString();
        ddgrphead.DataSource = ds.Tables[0];
        ddgrphead.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void subgrouphead()
    {
        DataSet ds;
        string qry = string.Format("SELECT subgroupid,case when subgrouphead = '' then credit  else subgrouphead + ' ('  + credit + ')' end as credit  FROM MasterSubGroupHead " +
                                    " where subgroupid <> 1 and status=104 and groupid={0} " +
                                    "order by subgroupid"
                                    , ddgrphead.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' subgroupid, 'NIL' credit";
            ds = DBConnection.fillDataSet(qry);
        }
        ddsubgrphead.DataTextField = ds.Tables[0].Columns["credit"].ToString();
        ddsubgrphead.DataValueField = ds.Tables[0].Columns["subgroupid"].ToString();
        ddsubgrphead.DataSource = ds.Tables[0];
        ddsubgrphead.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void calculateValues()
    {
        if (txtissuedqty.Text == "")
        {
            txtissuedqty.Text = "0.000";
        }
        if (txtissuedvalue.Text == "")
        {
            txtissuedvalue.Text = "0.00";
        }
        if (txtstorage.Text == "")
        {
            txtstorage.Text = "0.00";
        }

        if (txttotal.Text == "")
        {
            txttotal.Text = "0.00";
        }
        if (txtgrandtotal.Text == "")
        {
            txtgrandtotal.Text = "0.00";
        }

        txttotal.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtissuedqty.Text) * Convert.ToDecimal(txtissuedvalue.Text))) + ".00";

        txtgrandtotal.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txttotal.Text) + ((Convert.ToDecimal(txttotal.Text) * Convert.ToDecimal(txtstorage.Text)) / 100))) + ".00";

    }
    private void clear()
    {
        txtissuedqty.Text = "0.000";
        txtissuedvalue.Text = "0.00";
        txtstorage.Text = "0.00";
        txttotal.Text = "0.00";
        txtgrandtotal.Text = "0.00";
    }
    private void txtquantitystore()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;

        string qry = string.Format("select (isnull(r.receivedqty ,0)  - isnull(i.issuedqty1,0)) as availableqty from (select  itemcode ,itemname, sum(qtyaccepted) as receivedqty from stockreceipttable " +
                                   " where field2='OK' and field7=2 and itemcode = '{0}' and storename = '{1}' and goodstype = '{2}' group by itemname,itemcode ) r left outer join (select stockitemcode,stockitemname,sum(issuedqty) as issuedqty1 from stockissuetable where ifield2='OK' and stockitemcode = '{3}' and istore = '{4}'  and goodstype = '{5}' group by  stockitemname,stockitemcode) i on r.itemname = i.stockitemname "
                                    , dditemname.SelectedValue, Session["StoreName"].ToString(), ddgoodstype.SelectedItem.Text, dditemname.SelectedValue, Session["StoreName"].ToString(), ddgoodstype.SelectedItem.Text);
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
    protected void GVInfo_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void GVInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVInfo.PageIndex = e.NewPageIndex;
        gridbind();
        txtbox.Visible = false;
    }
    protected void GVInfo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
        Label2.Visible = false;
        LinkButton1.Visible = false;
        lblmsg.Visible = false; ;
        btnapproval.Visible = true;
        lblMessage2.Visible = false;
        txtbox.Visible = true;
        long k;
        k = Convert.ToInt32(GVInfo.DataKeys[e.NewSelectedIndex].Value);
        i = Convert.ToInt32(GVInfo.DataKeys[e.NewSelectedIndex].Value);
        DataSet ds;
        string qry = string.Format("SELECT ifield7,nameofsubdivision,srchallanbookno,srchallanpageno,srchallandate,estimateno,contractorname,nameofestimate,stockitemyype,stockitemcode,stockitemname," +
                                  " goodstype,unit,totalqtyestimate,qtydrawntilldate,qtyindented, recdempname,recdsdoname,lineid,linename,itemtypecode FROM stockissuetable " +
                                  " where itxno={0} ", k);

        ds = DBConnection.fillDataSet(qry);

        if (Convert.ToInt32(ds.Tables[0].Rows[0]["ifield7"]) == 1)
        {
            btnreview.Visible = true;
            btnapproval.Enabled = true;
        }
        else
        {
            btnreview.Visible = false;
            btnapproval.Enabled = false;
        }

        if (ds.Tables[0].Rows.Count != 0)
        {
            txtsubdivison.Text = ds.Tables[0].Rows[0]["nameofsubdivision"].ToString();
            ddestimate.SelectedItem.Text = ds.Tables[0].Rows[0]["nameofestimate"].ToString();
            ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["linename"].ToString();
            ddgoodstype.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
            dditemname.Items.Clear();
            dditemname.Items.Add(new ListItem(ds.Tables[0].Rows[0]["stockitemname"].ToString() ,ds.Tables[0].Rows[0]["stockitemcode"].ToString() ));
            //dditemname.SelectedValue = ;
            //dditemname.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemname"].ToString();
            dditemtype.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemyype"].ToString();
            //dditemtype.SelectedValue = ds.Tables[0].Rows[0]["itemtypecode"].ToString();
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

        string scmdText = "autovaluenew";
        string[][]  param = new string[][]{  new string[] {"@iitemcode", dditemname.SelectedItem.Text } 
                                            ,new string[] {"@istorename", Session["StoreName"].ToString()}
                                            ,new string[] {"@goodstatus" ,ddgoodstype.SelectedItem.Text }};
        DataTable dt = null;
        dt =   DBConnection1.executeProcedure(scmdText, param);
         if (dt.Rows.Count > 0)
            {
        string temp = dt.Rows[0][0].ToString();
        txtissuedvalue.Text = temp;
            }
         else
         {

             txtissuedvalue.Text = "0.000";
         }

        

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
        if( txtstrqty.Text == "0.000")
        {
            LinkButton1.Visible = true;
            Label2.Visible = true;
            // ClientScript.RegisterClientScriptBlock(this.GetType(), "ddd", "<script>alert('Select Item Type')</script>");
            showMsg(Label2, Color.Red, "Qty. in Store 0.000, Pls enter the Opening Balance");
            return;

        }
        else
        {
            LinkButton1.Visible = false;
        lblmsg.Visible = true;
        string scmdText = " BEGIN ";
        scmdText += string.Format(" UPDATE stockissuetable SET grpid={0},srgrphead='{1}',subgrpid={2},srsubgrphead='{3}', ifield7={4},issuedqty={5},qtyvalue={6},totalvalue={7},storagecharges={8},grandtotal={9} " +
                                 " WHERE srchallanbookno = '{10}' and srchallanpageno = '{11}' and itxno = {12} "
                              , ddgrphead.SelectedValue, ddgrphead.SelectedItem.Text, ddsubgrphead.SelectedValue, ddsubgrphead.SelectedItem.Text,2,Convert.ToDecimal(txtissuedqty.Text),
                              Convert.ToDecimal(txtissuedvalue.Text) ,Convert.ToDecimal(txttotal.Text),Convert.ToDecimal(txtstorage.Text),Convert.ToDecimal(txtgrandtotal.Text),
                              txtsrbook.Text, txtsrpage.Text, i);
        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        showMsg(lblmsg, Color.Red, "Successfully Sent for Approval!");
        txtbox.Visible = false;
        gridbind();
        clear();
        grouphead();
        subgrouphead();
            //ddgrphead.SelectedItem.Text = "....";
        }
    }
    protected void btnCancel2_Click(object sender, EventArgs e)
    {
        txtbox.Visible = false;
    }

    protected void txtissuedqty_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
      //  txtissuedvalue.Focus();
    }
    protected void txtissuedvalue_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
       // txtstorage.Focus();
    }
    protected void txtstorage_TextChanged(object sender, EventArgs e)
    {
        calculateValues();
    }
    protected void ddgrphead_SelectedIndexChanged(object sender, EventArgs e)
    {
        subgrouphead();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton1.Visible = true;
        Response.Redirect("OpeningBalance.aspx");
    }
    protected void btnreview_Click(object sender, EventArgs e)
    {
        lblMessage2.Visible = true;
        string scmdText = " BEGIN ";
        scmdText += string.Format(" UPDATE stockissuetable SET  subdivstatus = '{0}', ifield2 = '{1}',datesentstore = '{2}' " +
                                 " WHERE  itxno={3}  "
                              , "Pending","Reject",null, i);
        //scmdText += string.Format(" UPDATE stockissuetable SET  subdivstatus = '{0}', ifield2 = '{1}',datesentstore = '{2}' " +
        //                         " WHERE srchallanbookno = '{3}' and srchallanpageno = '{4}' and ifield7 = {5} "
        //                      , "Pending", "Reject", null, txtsrbook.Text, txtsrpage.Text, 1);
        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        showMsg(lblMessage2, Color.Red, "Sent back Successfully!");
        txtbox.Visible = false;
        gridbind();
    }
    protected void btsearch_Click(object sender, EventArgs e)
    {
        string qry = string.Format("SELECT itxno,nameofsubdivision,srchallanbookno,srchallanpageno,srchallandate,nameofestimate,stockitemname,qtyindented,subdivstatus,ifield2,totalqtyestimate,qtydrawntilldate FROM stockissuetable " +
                                    "where istore='{0}' and subdivstatus='{1}' and subdivstatusid={2} and ifield7={3}  and srchallanbookno = '{4}' and srchallanpageno = '{5}'" +
                                     "order by itxno desc,srchallanbookno,srchallanpageno,nameofsubdivision"
                                    , Session["StoreName"].ToString(), "OK", 2, 1, txtserbook.Text, txtserpage.Text);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    protected void btsearchcancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("StoreJESR.aspx");
    }
}