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
public partial class Inventory_SubdivisonSRWAE : System.Web.UI.Page
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
            //btnreview.Visible = true;
        }
        lblaeeremarks.Visible = false;
    }
    private void gridbind()
    {
        string qry = string.Format("SELECT rtxno,storechallanno,srwchallanDate,itemname,unit,qtyrecd,subdivstatus,datesentstore,dateapprovestore,field2 FROM stockreceipttable " +
                                    "where subdivstatusid=2 and smonth='GRSRW' and subdivid={0} " +
                                    " order by subdivstatus desc,rtxno desc "
                                    , Session["subdivisonid"]);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
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
            Label lblstatusstr = (Label)GVInfo.Rows[i].FindControl("lblgridStatusstr");
            lblstatusstr.Font.Bold = true;

            if (lblstatusstr.Text == "Pending")
            {
                GVInfo.Rows[i].Cells[7].BackColor = System.Drawing.Color.Orange;
                lblstatusstr.ForeColor = System.Drawing.Color.White;
            }
            else if (lblstatusstr.Text == "OK")
            {
                GVInfo.Rows[i].Cells[7].BackColor = System.Drawing.Color.Green;
                lblstatusstr.ForeColor = System.Drawing.Color.White;
            }
            else if (lblstatusstr.Text == "Reject")
            {
                GVInfo.Rows[i].Cells[7].BackColor = System.Drawing.Color.Red;
                lblstatusstr.ForeColor = System.Drawing.Color.White;
            }
        }
    }
    protected void GVInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVInfo.PageIndex = e.NewPageIndex;
        gridbind();
        txtbox.Visible = false;
    }
    protected void GVInfo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        lblmsg.Visible = false;;
      //  btnapproval.Visible = true;
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
                                              "empcode,empname,desg,stockrole,username,field7,field2,estimateno,estid,grtime,remarks,subdivstatus FROM stockreceipttable " +
                                                " where rtxno={0} "
                                                , k);

            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows[0]["subdivstatus"].ToString() == "OK")
            {
                btnreview.Visible = false;
                btnapproval.Enabled = false;
            }
            else
            {
                btnreview.Visible = true;
                btnapproval.Enabled = true;
            }
            if (ds.Tables[0].Rows.Count != 0)
            {
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
        DateTime sysdate = new DateTime();        
        sysdate = Convert.ToDateTime((System.DateTime.Now).ToString("dd-MM-yyyy"));
        String systemdate;       
        systemdate = sysdate.ToString("yyyy-MM-dd");
       // btnapproval.Enabled = true;
        lblmsg.Visible = true;
        string scmdText = " BEGIN ";
        scmdText += string.Format(" UPDATE stockreceipttable SET  subdivstatus = '{0}', datesentstore = '{1}'  " +
                                 " WHERE rtxno={2} "
                              , "OK", systemdate, i);      
        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        showMsg(lblmsg, Color.Red, "Confirmed Successfully!");
        txtbox.Visible = false;
        gridbind();
      //  btnreview.Visible = false;
    }
    protected void btnCancel2_Click(object sender, EventArgs e)
    {
        txtbox.Visible = false;
    }
    //protected void btsearch_Click(object sender, EventArgs e)
    //{
    //    string qry = string.Format("SELECT itxno,srchallanbookno,srchallanpageno,srchallandate,nameofestimate,stockitemname,qtyindented,subdivstatus,ifield2,totalqtyestimate,qtydrawntilldate FROM stockissuetable " +
    //                                "where subdivid={0} and subdivstatusid = {1} and srchallanbookno = '{2}' and srchallanpageno = '{3}' " +
    //                                "order by subdivstatus desc,itxno desc"
    //                                , Session["subdivisonid"], 2, txtserbook.Text, txtserpage.Text);
    //    DBConnection.fillGridView(ref GVInfo, qry);
    //    lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    //}
    //protected void btsearchcancel_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("SubdivisonSRAE.aspx");
    //}
    protected void btnreview_Click(object sender, EventArgs e)
    {
        lblMessage2.Visible = true;
        string scmdText = " BEGIN ";
        scmdText += string.Format(" UPDATE stockreceipttable SET  subdivstatusid = {0} " +
                                 " WHERE rtxno={1} "
                              , 1, i);
        //scmdText += string.Format(" UPDATE stockissuetable SET  subdivstatusid = {0} " +
        //                          " WHERE srchallanbookno = '{1}' and srchallanpageno = '{2}' and subdivstatus='{3}' "
        //                       , 1, txtsrbook.Text, txtsrpage.Text, "Pending");
        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        showMsg(lblMessage2, Color.Red, "Sent back Successfully!");
        txtbox.Visible = false;
        gridbind();
    }
}


