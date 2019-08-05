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

public partial class Inventory_SubdivisonLineMaster : System.Web.UI.Page
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
          //  DDLine();
            gridbind();
            //DDLineSearch();
            txtbox.Visible = false;
        }
        txtline.Focus();
        lblaeeremarks.Visible = false;
    }

    private void CallFunction()
    {
        gridbind();
        //DDLine();
    }
    private void readonlytext()
    {
      //  txtline.Enabled = false;
    }

    private void unreadonlytext()
    {
        //txtline.Enabled = true;
    }
    private void allclear()
    {
        txtline.Text = "";

    }
    private void clear()
    {
        txtline.Text = "";
    }
    private void gridbind()
    {
        string qry = string.Format("SELECT Lineid,LineName,StoreName,subdivisionid,subdivisionname,divid,divisonname,Estatus FROM LineMaster " +
                                    "where subdivisionid={0} " +
                                    "order by Estatus desc,Lineid desc"
                                    , Session["subdivisonid"]);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
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

     protected void btnProceed1_Click(object sender, EventArgs e)
       {
        lblmsg.Visible = true;
        if (Proceed.Text == "Save")
        {
            string scmdText = " BEGIN ";
            scmdText += string.Format("Insert into lineMaster (LineName,subdivisionid,subdivisionname,divid,divisonname,Estatus) VALUES ('{0}' ,{1},'{2}',{3},'{4}', '{5}' ) "
                   , txtline.Text, Session["subdivisonid"], Session["subdivison"], Session["divisonid"], Session["divison"], "Pending");
            scmdText += " END ";
            DBConnection.executeNonQuery(scmdText);
            showMsg(lblmsg, Color.Red, "Saved Successfully!");
        }
        else if (Proceed.Text == "Update")
        {
            string scmdText = " BEGIN ";
            scmdText += string.Format(" UPDATE lineMaster SET  LineName ='{0}' " +
                                         " WHERE Lineid = {1} "
                                      , txtline.Text, i);
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

          protected void btnAddNew_Click(object sender, EventArgs e)
          {
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
              scmdText += string.Format(" UPDATE lineMaster SET Estatus = '{0}' " +
                                       " WHERE Lineid = {1} and LineName = '{2}' "
                                    , "OK", i, txtline.Text);
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
              string qry = string.Format(" delete from lineMaster " +
                                         " where Lineid={0} and LineName = '{1}' "
                                          , i, txtline.Text);
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
                      GVInfo.Rows[i].Cells[2].BackColor = System.Drawing.Color.Orange;
                      lblstatus.ForeColor = System.Drawing.Color.White;
                  }
                  else if (lblstatus.Text == "OK")
                  {
                      GVInfo.Rows[i].Cells[2].BackColor = System.Drawing.Color.Green;
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
                  string qry = string.Format("SELECT Lineid,LineName,subdivisionid,subdivisionname,divid,divisonname,Estatus FROM LineMaster " +
                                                      " where Lineid={0} "
                                                      , k);

                  ds = DBConnection.fillDataSet(qry);
                  if (ds.Tables[0].Rows.Count != 0)
                  {
                      if (ds.Tables[0].Rows[0]["Estatus"].ToString() == "OK")
                      {
                          ButtonInVisible();
                          txtline.Text = ds.Tables[0].Rows[0]["LineName"].ToString();
                      }
                      else
                      {
                          ButtonVisible();
                          txtline.Text = ds.Tables[0].Rows[0]["LineName"].ToString();
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
}
