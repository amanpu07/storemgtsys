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
        string qry = string.Format("SELECT distinct transidsr, srchallanbookno,srchallanpageno,srchallandate,nameofestimate,istore,recdempname,subdivstatus,ifield2,datesentstore,dateapprovestore FROM stockissuetable " +
                                    "where subdivid={0} and subdivstatusid = {1}" +
                                  "order by subdivstatus desc,transidsr desc"
                                  , Session["subdivisonid"], 2);
        DBConnection.fillGridView(ref GVInfo, qry);
        lblRecordCount.Text = "<b>" + DBConnection.fillDataSet(qry).Tables[0].Rows.Count + "</b> record(s) found.";
    }
    private void txtquantitystore1()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;
        string qry = string.Format("select (isnull(r.receivedqty ,0)  - isnull(i.issuedqty1,0)) as availableqty from (select  itemcode ,itemname, sum(qtyaccepted) as receivedqty from stockreceipttable " +
                                   " where field2='OK' and field7=2 and itemcode = '{0}' and storename = '{1}' and goodstype = '{2}' group by itemname,itemcode ) r left outer join (select stockitemcode,stockitemname,sum(issuedqty) as issuedqty1 from stockissuetable where stockitemcode = '{3}' and istore = '{4}'  and goodstype = '{5}' group by  stockitemname,stockitemcode) i on r.itemname = i.stockitemname "
                                    , dditemname1.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype1.SelectedItem.Text, dditemname1.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype1.SelectedItem.Text);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtstrqty1.Text = ds.Tables[0].Rows[0]["availableqty"].ToString();
        }
        else
        {
            txtstrqty1.Text = "0.000";
        }
        ds.Clear();
        ds.Dispose();
    }
    private void txtquantitystore2()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;
        string qry = string.Format("select (isnull(r.receivedqty ,0)  - isnull(i.issuedqty1,0)) as availableqty from (select  itemcode ,itemname, sum(qtyaccepted) as receivedqty from stockreceipttable " +
                                  " where field2='OK' and field7=2 and itemcode = '{0}' and storename = '{1}' and goodstype = '{2}' group by itemname,itemcode ) r left outer join (select stockitemcode,stockitemname,sum(issuedqty) as issuedqty1 from stockissuetable where stockitemcode = '{3}' and istore = '{4}'  and goodstype = '{5}' group by  stockitemname,stockitemcode) i on r.itemname = i.stockitemname "
                                   , dditemname2.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype2.SelectedItem.Text, dditemname2.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype2.SelectedItem.Text);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtstrqty2.Text = ds.Tables[0].Rows[0]["availableqty"].ToString();
        }
        else
        {
            txtstrqty2.Text = "0.000";
        }
        ds.Clear();
        ds.Dispose();
    }
    private void txtquantitystore3()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;
        string qry = string.Format("select (isnull(r.receivedqty ,0)  - isnull(i.issuedqty1,0)) as availableqty from (select  itemcode ,itemname, sum(qtyaccepted) as receivedqty from stockreceipttable " +
                                   " where field2='OK' and field7=2 and itemcode = '{0}' and storename = '{1}' and goodstype = '{2}' group by itemname,itemcode ) r left outer join (select stockitemcode,stockitemname,sum(issuedqty) as issuedqty1 from stockissuetable where stockitemcode = '{3}' and istore = '{4}'  and goodstype = '{5}' group by  stockitemname,stockitemcode) i on r.itemname = i.stockitemname "
                                    , dditemname3.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype3.SelectedItem.Text, dditemname3.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype3.SelectedItem.Text);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtstrqty3.Text = ds.Tables[0].Rows[0]["availableqty"].ToString();
        }
        else
        {
            txtstrqty3.Text = "0.000";
        }
        ds.Clear();
        ds.Dispose();
    }
    private void txtquantitystore4()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;
        string qry = string.Format("select (isnull(r.receivedqty ,0)  - isnull(i.issuedqty1,0)) as availableqty from (select  itemcode ,itemname, sum(qtyaccepted) as receivedqty from stockreceipttable " +
                                   " where field2='OK' and field7=2 and itemcode = '{0}' and storename = '{1}' and goodstype = '{2}' group by itemname,itemcode ) r left outer join (select stockitemcode,stockitemname,sum(issuedqty) as issuedqty1 from stockissuetable where stockitemcode = '{3}' and istore = '{4}'  and goodstype = '{5}' group by  stockitemname,stockitemcode) i on r.itemname = i.stockitemname "
                                    , dditemname4.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype4.SelectedItem.Text, dditemname4.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype4.SelectedItem.Text);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtstrqty4.Text = ds.Tables[0].Rows[0]["availableqty"].ToString();
        }
        else
        {
            txtstrqty4.Text = "0.000";
        }
        ds.Clear();
        ds.Dispose();
    }
    private void txtquantitystore5()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;
        string qry = string.Format("select (isnull(r.receivedqty ,0)  - isnull(i.issuedqty1,0)) as availableqty from (select  itemcode ,itemname, sum(qtyaccepted) as receivedqty from stockreceipttable " +
                                   " where field2='OK' and field7=2 and itemcode = '{0}' and storename = '{1}' and goodstype = '{2}' group by itemname,itemcode ) r left outer join (select stockitemcode,stockitemname,sum(issuedqty) as issuedqty1 from stockissuetable where stockitemcode = '{3}' and istore = '{4}'  and goodstype = '{5}' group by  stockitemname,stockitemcode) i on r.itemname = i.stockitemname "
                                    , dditemname5.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype5.SelectedItem.Text, dditemname5.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype5.SelectedItem.Text);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtstrqty5.Text = ds.Tables[0].Rows[0]["availableqty"].ToString();
        }
        else
        {
            txtstrqty5.Text = "0.000";
        }
        ds.Clear();
        ds.Dispose();
    }
    private void txtquantitystore6()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;
        string qry = string.Format("select (isnull(r.receivedqty ,0)  - isnull(i.issuedqty1,0)) as availableqty from (select  itemcode ,itemname, sum(qtyaccepted) as receivedqty from stockreceipttable " +
                                   " where field2='OK' and field7=2 and itemcode = '{0}' and storename = '{1}' and goodstype = '{2}' group by itemname,itemcode ) r left outer join (select stockitemcode,stockitemname,sum(issuedqty) as issuedqty1 from stockissuetable where stockitemcode = '{3}' and istore = '{4}'  and goodstype = '{5}' group by  stockitemname,stockitemcode) i on r.itemname = i.stockitemname "
                                    , dditemname6.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype6.SelectedItem.Text, dditemname6.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype6.SelectedItem.Text);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtstrqty6.Text = ds.Tables[0].Rows[0]["availableqty"].ToString();
        }
        else
        {
            txtstrqty6.Text = "0.000";
        }
        ds.Clear();
        ds.Dispose();
    }
    private void txtquantitystore7()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;
        string qry = string.Format("select (isnull(r.receivedqty ,0)  - isnull(i.issuedqty1,0)) as availableqty from (select  itemcode ,itemname, sum(qtyaccepted) as receivedqty from stockreceipttable " +
                                   " where field2='OK' and field7=2 and itemcode = '{0}' and storename = '{1}' and goodstype = '{2}' group by itemname,itemcode ) r left outer join (select stockitemcode,stockitemname,sum(issuedqty) as issuedqty1 from stockissuetable where stockitemcode = '{3}' and istore = '{4}'  and goodstype = '{5}' group by  stockitemname,stockitemcode) i on r.itemname = i.stockitemname "
                                    , dditemname7.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype7.SelectedItem.Text, dditemname7.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype7.SelectedItem.Text);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtstrqty7.Text = ds.Tables[0].Rows[0]["availableqty"].ToString();
        }
        else
        {
            txtstrqty7.Text = "0.000";
        }
        ds.Clear();
        ds.Dispose();
    }
    private void txtquantitystore8()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;
        string qry = string.Format("select (isnull(r.receivedqty ,0)  - isnull(i.issuedqty1,0)) as availableqty from (select  itemcode ,itemname, sum(qtyaccepted) as receivedqty from stockreceipttable " +
                                   " where field2='OK' and field7=2 and itemcode = '{0}' and storename = '{1}' and goodstype = '{2}' group by itemname,itemcode ) r left outer join (select stockitemcode,stockitemname,sum(issuedqty) as issuedqty1 from stockissuetable where stockitemcode = '{3}' and istore = '{4}'  and goodstype = '{5}' group by  stockitemname,stockitemcode) i on r.itemname = i.stockitemname "
                                    , dditemname8.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype8.SelectedItem.Text, dditemname8.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype8.SelectedItem.Text);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtstrqty8.Text = ds.Tables[0].Rows[0]["availableqty"].ToString();
        }
        else
        {
            txtstrqty8.Text = "0.000";
        }
        ds.Clear();
        ds.Dispose();
    }
    private void txtquantitystore9()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;
        string qry = string.Format("select (isnull(r.receivedqty ,0)  - isnull(i.issuedqty1,0)) as availableqty from (select  itemcode ,itemname, sum(qtyaccepted) as receivedqty from stockreceipttable " +
                                   " where field2='OK' and field7=2 and itemcode = '{0}' and storename = '{1}' and goodstype = '{2}' group by itemname,itemcode ) r left outer join (select stockitemcode,stockitemname,sum(issuedqty) as issuedqty1 from stockissuetable where stockitemcode = '{3}' and istore = '{4}'  and goodstype = '{5}' group by  stockitemname,stockitemcode) i on r.itemname = i.stockitemname "
                                    , dditemname9.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype9.SelectedItem.Text, dditemname9.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype9.SelectedItem.Text);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtstrqty9.Text = ds.Tables[0].Rows[0]["availableqty"].ToString();
        }
        else
        {
            txtstrqty9.Text = "0.000";
        }
        ds.Clear();
        ds.Dispose();
    }
    private void txtquantitystore10()
    {
        // System.Threading.Thread.Sleep(5000);
        DataSet ds;
        string qry = string.Format("select (isnull(r.receivedqty ,0)  - isnull(i.issuedqty1,0)) as availableqty from (select  itemcode ,itemname, sum(qtyaccepted) as receivedqty from stockreceipttable " +
                                   " where field2='OK' and field7=2 and itemcode = '{0}' and storename = '{1}' and goodstype = '{2}' group by itemname,itemcode ) r left outer join (select stockitemcode,stockitemname,sum(issuedqty) as issuedqty1 from stockissuetable where stockitemcode = '{3}' and istore = '{4}'  and goodstype = '{5}' group by  stockitemname,stockitemcode) i on r.itemname = i.stockitemname "
                                    , dditemname10.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype10.SelectedItem.Text, dditemname10.SelectedValue, ddstore.SelectedItem.Text, ddgoodstype10.SelectedItem.Text);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count != 0)
        {
            txtstrqty10.Text = ds.Tables[0].Rows[0]["availableqty"].ToString();
        }
        else
        {
            txtstrqty10.Text = "0.000";
        }
        ds.Clear();
        ds.Dispose();
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
       // btnapproval.Visible = true;
        lblMessage2.Visible = false;
        txtbox.Visible = true;
        long k;
        k = Convert.ToInt32(GVInfo.DataKeys[e.NewSelectedIndex].Value);
        i = Convert.ToInt32(GVInfo.DataKeys[e.NewSelectedIndex].Value);
            DataSet ds;
            string qry = string.Format("SELECT srchallanbookno,srchallanpageno,srchallandate,estimateno,contractorname,nameofestimate,stockitemyype,stockitemcode,subdivstatus,stockitemname," +
                                      " goodstype,unit,totalqtyestimate,qtydrawntilldate,qtyindented, recdempname,recdsdoname,lineid,linename,itemtypecode,istore FROM stockissuetable " +
                                      " where transidsr={0} ", k);

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
              //  ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["linename"].ToString();
                txtcontractor.Text = ds.Tables[0].Rows[0]["contractorname"].ToString();
                txtje.Text = ds.Tables[0].Rows[0]["recdempname"].ToString();
                txtsdo.Text = ds.Tables[0].Rows[0]["recdsdoname"].ToString();
                txtsrbook.Text = ds.Tables[0].Rows[0]["srchallanbookno"].ToString();
                txtsrpage.Text = ds.Tables[0].Rows[0]["srchallanpageno"].ToString();
                txtsrdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["srchallandate"]).ToString("dd-MM-yyyy");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dditemtype1.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemyype"].ToString();
                    dditemname1.Items.Clear();
                    dditemname1.Items.Add(new ListItem(ds.Tables[0].Rows[0]["stockitemname"].ToString(), ds.Tables[0].Rows[0]["stockitemcode"].ToString()));
                    ddgoodstype1.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
                    txtunit1.Text = ds.Tables[0].Rows[0]["unit"].ToString();
                    txtquantitystore1();
                    txtqtyindent1.Text = ds.Tables[0].Rows[0]["qtyindented"].ToString();
                }
                if (ds.Tables[0].Rows.Count > 1)
                {
                    dditemtype2.SelectedItem.Text = ds.Tables[0].Rows[1]["stockitemyype"].ToString();
                    dditemname2.Items.Clear();
                    dditemname2.Items.Add(new ListItem(ds.Tables[0].Rows[1]["stockitemname"].ToString(), ds.Tables[0].Rows[1]["stockitemcode"].ToString()));
                    ddgoodstype2.SelectedItem.Text = ds.Tables[0].Rows[1]["goodstype"].ToString();
                    txtunit2.Text = ds.Tables[0].Rows[1]["unit"].ToString();
                    txtquantitystore2();
                    txtqtyindent2.Text = ds.Tables[0].Rows[1]["qtyindented"].ToString();
                }
                if (ds.Tables[0].Rows.Count > 2)
                {
                    dditemtype3.SelectedItem.Text = ds.Tables[0].Rows[2]["stockitemyype"].ToString();
                    dditemname3.Items.Clear();
                    dditemname3.Items.Add(new ListItem(ds.Tables[0].Rows[2]["stockitemname"].ToString(), ds.Tables[0].Rows[2]["stockitemcode"].ToString()));
                    ddgoodstype3.SelectedItem.Text = ds.Tables[0].Rows[2]["goodstype"].ToString();
                    txtunit3.Text = ds.Tables[0].Rows[2]["unit"].ToString();
                    txtquantitystore3();
                    txtqtyindent3.Text = ds.Tables[0].Rows[2]["qtyindented"].ToString();
                }
                if (ds.Tables[0].Rows.Count > 3)
                {
                    dditemtype4.SelectedItem.Text = ds.Tables[0].Rows[3]["stockitemyype"].ToString();
                    dditemname4.Items.Clear();
                    dditemname4.Items.Add(new ListItem(ds.Tables[0].Rows[3]["stockitemname"].ToString(), ds.Tables[0].Rows[3]["stockitemcode"].ToString()));
                    ddgoodstype4.SelectedItem.Text = ds.Tables[0].Rows[3]["goodstype"].ToString();
                    txtunit4.Text = ds.Tables[0].Rows[3]["unit"].ToString();
                    txtquantitystore4();
                    txtqtyindent4.Text = ds.Tables[0].Rows[3]["qtyindented"].ToString();
                }
                if (ds.Tables[0].Rows.Count > 4)
                {
                    dditemtype5.SelectedItem.Text = ds.Tables[0].Rows[4]["stockitemyype"].ToString();
                    dditemname5.Items.Clear();
                    dditemname5.Items.Add(new ListItem(ds.Tables[0].Rows[4]["stockitemname"].ToString(), ds.Tables[0].Rows[4]["stockitemcode"].ToString()));
                    ddgoodstype5.SelectedItem.Text = ds.Tables[0].Rows[4]["goodstype"].ToString();
                    txtunit5.Text = ds.Tables[0].Rows[4]["unit"].ToString();
                    txtquantitystore5();
                    txtqtyindent5.Text = ds.Tables[0].Rows[4]["qtyindented"].ToString();
                }
                if (ds.Tables[0].Rows.Count > 5)
                {
                    dditemtype6.SelectedItem.Text = ds.Tables[0].Rows[5]["stockitemyype"].ToString();
                    dditemname6.Items.Clear();
                    dditemname6.Items.Add(new ListItem(ds.Tables[0].Rows[5]["stockitemname"].ToString(), ds.Tables[0].Rows[5]["stockitemcode"].ToString()));
                    ddgoodstype6.SelectedItem.Text = ds.Tables[0].Rows[5]["goodstype"].ToString();
                    txtunit6.Text = ds.Tables[0].Rows[5]["unit"].ToString();
                    txtquantitystore6();
                    txtqtyindent6.Text = ds.Tables[0].Rows[5]["qtyindented"].ToString();
                }
                if (ds.Tables[0].Rows.Count > 6)
                {
                    dditemtype7.SelectedItem.Text = ds.Tables[0].Rows[6]["stockitemyype"].ToString();
                    dditemname7.Items.Clear();
                    dditemname7.Items.Add(new ListItem(ds.Tables[0].Rows[6]["stockitemname"].ToString(), ds.Tables[0].Rows[6]["stockitemcode"].ToString()));
                    ddgoodstype7.SelectedItem.Text = ds.Tables[0].Rows[6]["goodstype"].ToString();
                    txtunit7.Text = ds.Tables[0].Rows[6]["unit"].ToString();
                    txtquantitystore7();
                    txtqtyindent7.Text = ds.Tables[0].Rows[6]["qtyindented"].ToString();
                }
                if (ds.Tables[0].Rows.Count > 7)
                {
                    dditemtype8.SelectedItem.Text = ds.Tables[0].Rows[7]["stockitemyype"].ToString();
                    dditemname8.Items.Clear();
                    dditemname8.Items.Add(new ListItem(ds.Tables[0].Rows[7]["stockitemname"].ToString(), ds.Tables[0].Rows[7]["stockitemcode"].ToString()));
                    ddgoodstype8.SelectedItem.Text = ds.Tables[0].Rows[7]["goodstype"].ToString();
                    txtunit8.Text = ds.Tables[0].Rows[7]["unit"].ToString();
                    txtquantitystore8();
                    txtqtyindent8.Text = ds.Tables[0].Rows[7]["qtyindented"].ToString();
                }
                if (ds.Tables[0].Rows.Count > 8)
                {
                    dditemtype9.SelectedItem.Text = ds.Tables[0].Rows[8]["stockitemyype"].ToString();
                    dditemname9.Items.Clear();
                    dditemname9.Items.Add(new ListItem(ds.Tables[0].Rows[8]["stockitemname"].ToString(), ds.Tables[0].Rows[8]["stockitemcode"].ToString()));
                    ddgoodstype9.SelectedItem.Text = ds.Tables[0].Rows[8]["goodstype"].ToString();
                    txtunit9.Text = ds.Tables[0].Rows[8]["unit"].ToString();
                    txtquantitystore9();
                    txtqtyindent9.Text = ds.Tables[0].Rows[8]["qtyindented"].ToString();
                }
                if (ds.Tables[0].Rows.Count > 9)
                {
                    dditemtype10.SelectedItem.Text = ds.Tables[0].Rows[9]["stockitemyype"].ToString();
                    dditemname10.Items.Clear();
                    dditemname10.Items.Add(new ListItem(ds.Tables[0].Rows[9]["stockitemname"].ToString(), ds.Tables[0].Rows[9]["stockitemcode"].ToString()));
                    ddgoodstype10.SelectedItem.Text = ds.Tables[0].Rows[9]["goodstype"].ToString();
                    txtunit10.Text = ds.Tables[0].Rows[9]["unit"].ToString();
                    txtquantitystore10();
                    txtqtyindent10.Text = ds.Tables[0].Rows[9]["qtyindented"].ToString();
                }
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
        scmdText += string.Format(" UPDATE stockissuetable SET  subdivstatus = '{0}', datesentstore = '{1}' , ifield2 = '{2}' " +
                                 " WHERE srchallanbookno = '{3}' and srchallanpageno = '{4}' and transidsr={5} "
                              , "OK", systemdate,"Pending", txtsrbook.Text, txtsrpage.Text, i);
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
        string qry = string.Format("SELECT distinct transidsr, srchallanbookno,srchallanpageno,srchallandate,nameofestimate,istore,recdempname,subdivstatus,ifield2,datesentstore,dateapprovestore FROM stockissuetable " +
                                    "where subdivid={0} and subdivstatusid = {1} and srchallanbookno = '{2}' and srchallanpageno = '{3}' " +
                                    "order by subdivstatus desc,transidsr desc"
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
                                 " WHERE transidsr={1} "
                              , 1, i);
        //scmdText += string.Format(" UPDATE stockissuetable SET  subdivstatusid = {0} " +
        //                         " WHERE srchallanbookno = '{1}' and srchallanpageno = '{2}' and subdivstatus='{3}' "
        //                      , 1, txtsrbook.Text, txtsrpage.Text, "Pending");
        scmdText += " END ";
        DBConnection.executeNonQuery(scmdText);
        showMsg(lblMessage2, Color.Red, "Sent back Successfully!");
        txtbox.Visible = false;
        gridbind();
    }
   
}