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

public partial class Inventory_SubdivisonSRAE : System.Web.UI.Page
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
           // btnapproval.Visible = true;
            //btnreview.Visible = true;
        }
        lblaeeremarks.Visible = false;
    }
    private void gridbind()
    {
        string qry = string.Format("SELECT itxno,istore,srchallanbookno,srchallanpageno,srchallandate,nameofestimate,stockitemname,unit,qtyindented,subdivstatus,ifield2,totalqtyestimate,qtydrawntilldate,datesentstore,dateapprovestore,issuedqty FROM stockissuetable " +
                                    "where subdivid={0} and subdivstatusid = {1} " +
                                    "order by subdivstatus desc,itxno desc"
                                    , Session["subdivisonid"], 2);
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
                GVInfo.Rows[i].Cells[11].BackColor = System.Drawing.Color.Orange;
                lblstatus.ForeColor = System.Drawing.Color.White;
            }
            else if (lblstatus.Text == "OK")
            {
                GVInfo.Rows[i].Cells[11].BackColor = System.Drawing.Color.Green;
                lblstatus.ForeColor = System.Drawing.Color.White;
            }
            Label lblstatusstr = (Label)GVInfo.Rows[i].FindControl("lblgridStatusstr");
            lblstatusstr.Font.Bold = true;

            if (lblstatusstr.Text == "Pending")
            {
                GVInfo.Rows[i].Cells[12].BackColor = System.Drawing.Color.Orange;
                lblstatusstr.ForeColor = System.Drawing.Color.White;
            }
            else if (lblstatusstr.Text == "OK")
            {
                GVInfo.Rows[i].Cells[12].BackColor = System.Drawing.Color.Green;
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
       // btnapproval.Visible = true;
        lblMessage2.Visible = false;
        txtbox.Visible = true;
        long k;
        k = Convert.ToInt32(GVInfo.DataKeys[e.NewSelectedIndex].Value);
        i = Convert.ToInt32(GVInfo.DataKeys[e.NewSelectedIndex].Value);
            DataSet ds;
            string qry = string.Format("SELECT istore,srchallanbookno,srchallanpageno,srchallandate,estimateno,contractorname,nameofestimate,stockitemyype,stockitemcode,stockitemname," +
                                      " goodstype,unit,totalqtyestimate,qtydrawntilldate,qtyindented, recdempname,recdsdoname,lineid,linename,itemtypecode,subdivstatus FROM stockissuetable " +
                                      " where itxno={0} ", k);

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
                ddstore.SelectedItem.Text = ds.Tables[0].Rows[0]["istore"].ToString();
                ddestimate.SelectedItem.Text = ds.Tables[0].Rows[0]["nameofestimate"].ToString();
                ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["linename"].ToString();
                ddgoodstype.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
                dditemtype.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemyype"].ToString();
                dditemname.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemname"].ToString();
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
        lblmsg.Visible = true;
        string scmdText = " BEGIN ";
        scmdText += string.Format(" UPDATE stockissuetable SET  subdivstatus = '{0}', datesentstore = '{1}'  " +
                                 " WHERE srchallanbookno = '{2}' and srchallanpageno = '{3}' and itxno={4} "
                              , "OK", systemdate, txtsrbook.Text, txtsrpage.Text, i);
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
    protected void btsearch_Click(object sender, EventArgs e)
    {
        string qry = string.Format("SELECT itxno,srchallanbookno,srchallanpageno,srchallandate,nameofestimate,stockitemname,qtyindented,subdivstatus,ifield2,totalqtyestimate,qtydrawntilldate FROM stockissuetable " +
                                    "where subdivid={0} and subdivstatusid = {1} and srchallanbookno = '{2}' and srchallanpageno = '{3}' " +
                                    "order by subdivstatus desc,itxno desc"
                                    , Session["subdivisonid"], 2, txtserbook.Text, txtserpage.Text);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    protected void btsearchcancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SubdivisonSRAE.aspx");
    }
    protected void btnreview_Click(object sender, EventArgs e)
    {
        lblMessage2.Visible = true;
        string scmdText = " BEGIN ";
        scmdText += string.Format(" UPDATE stockissuetable SET  subdivstatusid = {0} " +
                                 " WHERE srchallanbookno = '{1}' and srchallanpageno = '{2}' "
                              , 1, txtsrbook.Text, txtsrpage.Text);
        //scmdText += string.Format(" UPDATE stockissuetable SET  subdivstatusid = {0} " +
        //                        " WHERE srchallanbookno = '{1}' and srchallanpageno = '{2}' and itxno={3} "
        //                     , 1, txtsrbook.Text, txtsrpage.Text, i);
        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        showMsg(lblMessage2, Color.Red, "Sent back Successfully!");
        txtbox.Visible = false;
        gridbind();
    }
   
}