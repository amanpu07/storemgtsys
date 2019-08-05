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

public partial class Inventory_SubdivisonEstimateMaster : System.Web.UI.Page
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
            DDLine();
            gridbind();
            DDLineSearch();
            txtbox.Visible = false;
            txtempid.Text = Session["employeecode"].ToString();
        }       
        txtestimate.Focus();
        lblaeeremarks.Visible = false;
    }

    private void CallFunction()
    {
        gridbind();
        DDLine();
    }
    private void readonlytext()
    {
        ddline.Enabled = false;
    }

    private void unreadonlytext()
    {
        ddline.Enabled = true;
    }
    private void allclear()
    {
        txtestimate.Text = "";

    }
    private void clear()
    {
        txtestimate.Text = "";
    }
    private void gridbind()
    {
        string qry = string.Format("SELECT a.estid estid,a.estimate estimate,a.subdivisionid subdivisionid,a.subdivisionname subdivisionname,a.divid divid,a.divisonname divisonname,a.LineCode LineCode,a.Estatus Estatus,b.LineName LineName FROM EstimateMaster a, LineMaster b " +
                                    "where a.subdivisionid={0} and a.LineCode = b.Lineid " +
                                    "order by a.Estatus desc,a.LineCode,a.estid desc"
                                    , Session["subdivisonid"]);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    private void DDLineSearch()
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
        ddlinesearch.DataTextField = ds.Tables[0].Columns["LineName"].ToString();
        ddlinesearch.DataValueField = ds.Tables[0].Columns["Lineid"].ToString();
        ddlinesearch.DataSource = ds.Tables[0];
        ddlinesearch.DataBind();
        ds.Clear();
        ds.Dispose();
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
   

    private void DDLine()
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
        ddline.DataTextField = ds.Tables[0].Columns["LineName"].ToString();
        ddline.DataValueField = ds.Tables[0].Columns["Lineid"].ToString();
        ddline.DataSource = ds.Tables[0];
        ddline.DataBind();
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
        string qry = string.Format("SELECT a.estid estid,a.estimate estimate,a.subdivisionid subdivisionid,a.subdivisionname subdivisionname,a.divid divid,a.divisonname divisonname,a.LineCode LineCode,a.Estatus Estatus,b.LineName LineName FROM EstimateMaster a, LineMaster b " +
                                  "where a.subdivisionid={0} and a.LineCode={1} and a.LineCode = b.Lineid " +
                                  "order by a.Estatus desc,a.estid desc"
                                  , Session["subdivisonid"], ddlinesearch.SelectedValue);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    protected void btsearchcancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SubdivisonEstimateMaster.aspx");
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        txtestimate.Enabled = true;
        CheckBox1.Checked = false;
        CallFunction();
        lblMessage2.Visible = false;
        lblmsg.Visible = false;
        btndel.Visible = false;
        btnapproval.Visible = false;
        txtbox.Visible = true;
        Proceed.Text = "Save";
        allclear();
        unreadonlytext();
    }
    protected void btCancel1_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePageSubDivison.aspx?F=0");
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
        txtestimate.Enabled = true;
        CheckBox1.Checked = false;
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
    }
    protected void btnapproval_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;
        string scmdText = " BEGIN ";
        scmdText += string.Format(" UPDATE EstimateMaster SET  Estatus = '{0}' " +
                                 " WHERE estid = {1} and estimate = '{2}' "
                              , "OK", i, txtestimate.Text);
        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        showMsg(lblmsg, Color.Red, "Confirmed Successfully!");
        allclear();
        gridbind();
        txtbox.Visible = false;
        can.Visible = true;

    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        lblmsg.Visible = true;
        unreadonlytext();
        DataSet ds;
        string qry = string.Format(" delete from EstimateMaster " +
                                   " where estid={0} and estimate = '{1}' "
                                    , i, txtestimate.Text);
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
                GVInfo.Rows[i].Cells[3].BackColor = System.Drawing.Color.Orange;
                lblstatus.ForeColor = System.Drawing.Color.White;
            }
            else if (lblstatus.Text == "OK")
            {
                GVInfo.Rows[i].Cells[3].BackColor = System.Drawing.Color.Green;
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
            string qry = string.Format("SELECT a.estid estid,a.estimate estimate,a.subdivisionid subdivisionid,a.subdivisionname subdivisionname,a.divid divid,a.divisonname divisonname,a.LineCode LineCode,a.Estatus Estatus,b.LineName LineName FROM EstimateMaster a, LineMaster b " +
                                                " where a.estid={0} and a.LineCode = b.Lineid "
                                                , k);

            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (ds.Tables[0].Rows[0]["Estatus"].ToString() == "OK")
                {
                    ButtonInVisible();
                    ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["LineName"].ToString();
                    txtestimate.Text = ds.Tables[0].Rows[0]["estimate"].ToString();
                }
                else
                {
                    ButtonVisible();
                    ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["LineName"].ToString();
                    txtestimate.Text = ds.Tables[0].Rows[0]["estimate"].ToString();
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
    protected void GVInfo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GVInfo_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
         lblmsg.Visible = true;
        if (Proceed.Text == "Save")
        {
            string scmdText = " BEGIN ";
            scmdText += string.Format("Insert into EstimateMaster (estimate,subdivisionid,subdivisionname,divid,divisonname,LineCode,Estatus) VALUES ('{0}' ,{1},'{2}',{3},'{4}',{5}, '{6}') "
            , txtestimate.Text, Session["subdivisonid"], Session["subdivison"], Session["divisonid"], Session["divison"], ddline.SelectedValue, "Pending");
            scmdText += " END ";
            DBConnection.executeNonQuery(scmdText);
            showMsg(lblmsg, Color.Red, "Saved Successfully!");
        }
        else if (Proceed.Text == "Update")
        {
            string scmdText = " BEGIN ";
            scmdText += string.Format(" UPDATE EstimateMaster SET  estimate ='{0}' " +
                                         " WHERE estid = {1} "
                                      , txtestimate.Text, i);
            scmdText += " END ";
            DBConnection.executeNonQuery(scmdText);
            showMsg(lblmsg, Color.Red, "Updated Successfully!");
        }
        try
        {
            allclear();
            gridbind();
        }
        catch (Exception ex)
        {
            showMsg(lblmsg, Color.Red, "Uploaded Error : " + ex.Message);
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
         DataSet ds;
            string qry = string.Format("SELECT max(estid) as estid FROM EstimateMaster");

            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (CheckBox1.Checked == true)
                {
                    txtestimate.Text = "UE/2018-19/" + Session["StoreLoc"] + "/" + ds.Tables[0].Rows[0]["estid"].ToString();
                    Label1.Text = "Unsanctioned Estimate-" + ddline.SelectedItem.Text;
                    txtestimate.Enabled = false;
                    Label1.Visible = true;
                }
                else
                {
                    txtestimate.Text = "";
                    txtestimate.Enabled = true;
                    Label1.Visible = false;
                }
              
            }

            ds.Clear();
            ds.Dispose();

        //if (CheckBox1.Checked == true)
        //{
        //    txtestimate.Text = "Unsanctioned Estimate-" + ddline.SelectedItem.Text;
        //    txtestimate.Enabled = false;
        //}
        //else
        //{
        //    txtestimate.Text = "";
        //    txtestimate.Enabled = true;
        //}
    }
    protected void ddline_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds;
        string qry = string.Format("SELECT max(estid) as estid FROM EstimateMaster");

        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            if (CheckBox1.Checked == true)
            {
                txtestimate.Text = "UE/2018-19/" + Session["StoreLoc"] + "/" + ds.Tables[0].Rows[0]["estid"].ToString();
                Label1.Text = "Unsanctioned Estimate-" + ddline.SelectedItem.Text;
                txtestimate.Enabled = false;
                Label1.Visible = true;
            }
            else
            {
                txtestimate.Text = "";
                txtestimate.Enabled = true;
                Label1.Visible = false;
            }

        }

        ds.Clear();
        ds.Dispose();
    }
}