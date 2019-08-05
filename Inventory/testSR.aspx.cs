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

public partial class Inventory_testSR : System.Web.UI.Page
{
    static long i;
    // private SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString;
        //if (con.State == ConnectionState.Closed)
        //{
        //    con.Open();
        //}
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
            DDTypebind1();
            DDTypebind2();
            DDTypebind3();
            DDTypebind4();
            DDTypebind5();
            DDTypebind6();
            DDTypebind7();
            DDTypebind8();
            DDTypebind9();
            DDTypebind10();
            DDNameItembind1();
            DDNameItembind2();
            DDNameItembind3();
            DDNameItembind4();
            DDNameItembind5();
            DDNameItembind6();
            DDNameItembind7();
            DDNameItembind8();
            DDNameItembind9();
            DDNameItembind10();
            DDGoodsType1();
            DDGoodsType2();
            DDGoodsType3();
            DDGoodsType4();
            DDGoodsType5();
            DDGoodsType6();
            DDGoodsType7();
            DDGoodsType8();
            DDGoodsType9();
            DDGoodsType10();
            txtunitbind1();
            txtunitbind2();
            txtunitbind3();
            txtunitbind4();
            txtunitbind5();
            txtunitbind6();
            txtunitbind7();
            txtunitbind8();
            txtunitbind9();
            txtunitbind10();
            txtquantitystore1();
            txtquantitystore2();
            txtquantitystore3();
            txtquantitystore4();
            txtquantitystore5();
            txtquantitystore6();
            txtquantitystore7();
            txtquantitystore8();
            txtquantitystore9();
            txtquantitystore10();
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
        DDTypebind1();
        DDTypebind2();
        DDTypebind3();
        DDTypebind4();
        DDTypebind5();
        DDTypebind6();
        DDTypebind7();
        DDTypebind8();
        DDTypebind9();
        DDTypebind10();
        DDNameItembind1();
        DDNameItembind2();
        DDNameItembind3();
        DDNameItembind4();
        DDNameItembind5();
        DDNameItembind6();
        DDNameItembind7();
        DDNameItembind8();
        DDNameItembind9();
        DDNameItembind10();
        DDGoodsType1();
        DDGoodsType2();
        DDGoodsType3();
        DDGoodsType4();
        DDGoodsType5();
        DDGoodsType6();
        DDGoodsType7();
        DDGoodsType8();
        DDGoodsType9();
        DDGoodsType10();
        txtunitbind1();
        txtunitbind2();
        txtunitbind3();
        txtunitbind4();
        txtunitbind5();
        txtunitbind6();
        txtunitbind7();
        txtunitbind8();
        txtunitbind9();
        txtunitbind10();
        txtquantitystore1();
        txtquantitystore2();
        txtquantitystore3();
        txtquantitystore4();
        txtquantitystore5();
        txtquantitystore6();
        txtquantitystore7();
        txtquantitystore8();
        txtquantitystore9();
        txtquantitystore10();
    }
    private void readonlytext()
    {
        ddstore.Enabled = false;
        ddestimate.Enabled = false;
        ddline.Enabled = false;
        dditemtype1.Enabled = false;
        dditemtype2.Enabled = false;
        dditemtype3.Enabled = false;
        dditemtype4.Enabled = false;
        dditemtype5.Enabled = false;
        dditemtype6.Enabled = false;
        dditemtype7.Enabled = false;
        dditemtype8.Enabled = false;
        dditemtype9.Enabled = false;
        dditemtype10.Enabled = false;
        dditemname1.Enabled = false;
        dditemname2.Enabled = false;
        dditemname3.Enabled = false;
        dditemname4.Enabled = false;
        dditemname5.Enabled = false;
        dditemname6.Enabled = false;
        dditemname7.Enabled = false;
        dditemname8.Enabled = false;
        dditemname9.Enabled = false;
        dditemname10.Enabled = false;
        ddgoodstype1.Enabled = false;
        ddgoodstype2.Enabled = false;
        ddgoodstype3.Enabled = false;
        ddgoodstype4.Enabled = false;
        ddgoodstype5.Enabled = false;
        ddgoodstype6.Enabled = false;
        ddgoodstype7.Enabled = false;
        ddgoodstype8.Enabled = false;
        ddgoodstype9.Enabled = false;
        ddgoodstype10.Enabled = false;
        txtunit1.ReadOnly = true;
        txtunit2.ReadOnly = true;
        txtunit3.ReadOnly = true;
        txtunit4.ReadOnly = true;
        txtunit5.ReadOnly = true;
        txtunit6.ReadOnly = true;
        txtunit7.ReadOnly = true;
        txtunit8.ReadOnly = true;
        txtunit9.ReadOnly = true;
        txtunit10.ReadOnly = true;

        //txtqty.ReadOnly = true;
        //txtqtydrwn.ReadOnly = true;
        //txtcontractor.ReadOnly = true;
        //txtje.ReadOnly = true;
        //txtsdo.ReadOnly = true;        
    }

    private void unreadonlytext()
    {
        ddstore.Enabled = true;
        ddestimate.Enabled = true;
        ddline.Enabled = true;
        dditemtype1.Enabled = true;
        dditemtype2.Enabled = true;
        dditemtype3.Enabled = true;
        dditemtype4.Enabled = true;
        dditemtype5.Enabled = true;
        dditemtype6.Enabled = true;
        dditemtype7.Enabled = true;
        dditemtype8.Enabled = true;
        dditemtype9.Enabled = true;
        dditemtype10.Enabled = true;
        dditemname1.Enabled = true;
        dditemname2.Enabled = true;
        dditemname3.Enabled = true;
        dditemname4.Enabled = true;
        dditemname5.Enabled = true;
        dditemname6.Enabled = true;
        dditemname7.Enabled = true;
        dditemname8.Enabled = true;
        dditemname9.Enabled = true;
        dditemname10.Enabled = true;
        ddgoodstype1.Enabled = true;
        ddgoodstype2.Enabled = true;
        ddgoodstype3.Enabled = true;
        ddgoodstype4.Enabled = true;
        ddgoodstype5.Enabled = true;
        ddgoodstype6.Enabled = true;
        ddgoodstype7.Enabled = true;
        ddgoodstype8.Enabled = true;
        ddgoodstype9.Enabled = true;
        ddgoodstype10.Enabled = true;
        txtunit1.ReadOnly = false;
        txtunit2.ReadOnly = false;
        txtunit3.ReadOnly = false;
        txtunit4.ReadOnly = false;
        txtunit5.ReadOnly = false;
        txtunit6.ReadOnly = false;
        txtunit7.ReadOnly = false;
        txtunit8.ReadOnly = false;
        txtunit9.ReadOnly = false;
        txtunit10.ReadOnly = false;
    }
    private void allclear()
    {
        txtsrbook.Text = "";
        txtsrpage.Text = "";
        txtqtyindent1.Text = "0.000";
        txtqtyindent2.Text = "0.000";
        txtqtyindent3.Text = "0.000";
        txtqtyindent4.Text = "0.000";
        txtqtyindent5.Text = "0.000";
        txtqtyindent6.Text = "0.000";
        txtqtyindent7.Text = "0.000";
        txtqtyindent8.Text = "0.000";
        txtqtyindent9.Text = "0.000";
        txtqtyindent10.Text = "0.000";
        txtsrdate.Text = "dd-mm-yyyy";

    }
    private void clear()
    {
        // txtsrbook.Text = "";
        // txtsrpage.Text = "";
        txtqtyindent1.Text = "0.000";
        txtqtyindent2.Text = "0.000";
        txtqtyindent3.Text = "0.000";
        txtqtyindent4.Text = "0.000";
        txtqtyindent5.Text = "0.000";
        txtqtyindent6.Text = "0.000";
        txtqtyindent7.Text = "0.000";
        txtqtyindent8.Text = "0.000";
        txtqtyindent9.Text = "0.000";
        txtqtyindent10.Text = "0.000";
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
        string qry = string.Format("SELECT distinct transidsr, srchallanbookno,srchallanpageno,srchallandate,nameofestimate,subdivstatus,istore,recdempname FROM stockissuetable " +
                                   "where subdivid={0} and subdivstatusid = {1} and username = '{2}'" +
                                   "order by subdivstatus desc,transidsr desc"
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
        //DataSet ds;
        //string qry = string.Format("SELECT Lineid,LineName from LineMaster" +
        //                           " where subdivisionid={0} and Estatus='{1}' " +
        //                           "order by LineName"
        //                            , Session["subdivisonid"], "OK");
        //ds = DBConnection.fillDataSet(qry);
        //if (ds.Tables[0].Rows.Count == 0)
        //{
        //    qry = "SELECT 'NIL' Lineid, 'NIL' LineName";
        //    ds = DBConnection.fillDataSet(qry);
        //}
        //ddline.DataTextField = ds.Tables[0].Columns["LineName"].ToString();
        //ddline.DataValueField = ds.Tables[0].Columns["Lineid"].ToString();
        //ddline.DataSource = ds.Tables[0];
        //ddline.DataBind();
        //ds.Clear();
        //ds.Dispose();
    }
    private void DDEstimate()
    {
        if (ddline.SelectedItem.Text == "NIL")
        {

        }
        else
        {
            //System.Threading.Thread.Sleep(5000);
            //DataSet ds;
            //string qry = string.Format("SELECT estid,estimate from EstimateMaster" +
            //                           " where subdivisionid={0} and LineCode={1} and Estatus='{2}' " +
            //                           "order by estimate"
            //                            , Session["subdivisonid"], ddline.SelectedValue, "OK");
            //ds = DBConnection.fillDataSet(qry);
            //if (ds.Tables[0].Rows.Count == 0)
            //{
            //    qry = "SELECT 'NIL' estid, 'NIL' estimate";
            //    ds = DBConnection.fillDataSet(qry);
            //}
            //ddestimate.DataTextField = ds.Tables[0].Columns["estimate"].ToString();
            //ddestimate.DataValueField = ds.Tables[0].Columns["estid"].ToString();
            //ddestimate.DataSource = ds.Tables[0];
            //ddestimate.DataBind();
            //ds.Clear();
            //ds.Dispose();

            DataSet ds;
            string qry = string.Format("SELECT estid,estimate from EstimateMaster order by estimate");// +
            // " where subdivisionid={0} and LineCode={1} and Estatus='{2}' " +
            // "order by estimate"
            // , Session["subdivisonid"], ddline.SelectedValue, "OK");
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

    private void DDTypebind1()
    {
        // commented codes used for MCR linking 
        //DataSet ds; 
        //string qry = string.Format("Select distinct itemtype,typecode  from MCR " +
        //                           " where subdivisionid={0} and Estatus='{1}' and estid={2} " +
        //                           "order by itemtype"
        //                            , Session["subdivisonid"], "OK", ddestimate.SelectedValue);
        //ds = DBConnection.fillDataSet(qry);
        //if (ds.Tables[0].Rows.Count == 0)
        //{
        //    qry = "SELECT 'NIL' itemtype,'NIL' typecode";
        //    ds = DBConnection.fillDataSet(qry);
        //}
        //dditemtype.DataTextField = ds.Tables[0].Columns["itemtype"].ToString();
        //dditemtype.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        //dditemtype.DataSource = ds.Tables[0];
        //dditemtype.DataBind();
        //ds.Clear();
        //ds.Dispose();

        DataSet ds;
        string qry = string.Format("Select distinct itype,typecode  from MASTINVENTORY order by itype");
        ds = DBConnection.fillDataSet(qry);

        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' itype,'NIL' typecode";
            ds = DBConnection.fillDataSet(qry);

        }
        dditemtype1.DataTextField = ds.Tables[0].Columns["itype"].ToString();
        dditemtype1.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype1.DataSource = ds.Tables[0];
        dditemtype1.DataBind();

        ds.Clear();
        ds.Dispose();

    }
    private void DDTypebind2()
    {
        DataSet ds;
        string qry = string.Format("Select distinct itype,typecode  from MASTINVENTORY order by itype");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' itype,'NIL' typecode";
            ds = DBConnection.fillDataSet(qry);
        }

        dditemtype2.DataTextField = ds.Tables[0].Columns["itype"].ToString();
        dditemtype2.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype2.DataSource = ds.Tables[0];
        dditemtype2.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDTypebind3()
    {
        DataSet ds;
        string qry = string.Format("Select distinct itype,typecode  from MASTINVENTORY order by itype");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' itype,'NIL' typecode";
            ds = DBConnection.fillDataSet(qry);
        }

        dditemtype3.DataTextField = ds.Tables[0].Columns["itype"].ToString();
        dditemtype3.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype3.DataSource = ds.Tables[0];
        dditemtype3.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDTypebind4()
    {
        DataSet ds;
        string qry = string.Format("Select distinct itype,typecode  from MASTINVENTORY order by itype");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' itype,'NIL' typecode";
            ds = DBConnection.fillDataSet(qry);
        }

        dditemtype4.DataTextField = ds.Tables[0].Columns["itype"].ToString();
        dditemtype4.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype4.DataSource = ds.Tables[0];
        dditemtype4.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDTypebind5()
    {
        DataSet ds;
        string qry = string.Format("Select distinct itype,typecode  from MASTINVENTORY order by itype");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' itype,'NIL' typecode";
            ds = DBConnection.fillDataSet(qry);
        }

        dditemtype5.DataTextField = ds.Tables[0].Columns["itype"].ToString();
        dditemtype5.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype5.DataSource = ds.Tables[0];
        dditemtype5.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDTypebind6()
    {
        DataSet ds;
        string qry = string.Format("Select distinct itype,typecode  from MASTINVENTORY order by itype");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' itype,'NIL' typecode";
            ds = DBConnection.fillDataSet(qry);
        }

        dditemtype6.DataTextField = ds.Tables[0].Columns["itype"].ToString();
        dditemtype6.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype6.DataSource = ds.Tables[0];
        dditemtype6.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDTypebind7()
    {
        DataSet ds;
        string qry = string.Format("Select distinct itype,typecode  from MASTINVENTORY order by itype");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' itype,'NIL' typecode";
            ds = DBConnection.fillDataSet(qry);
        }

        dditemtype7.DataTextField = ds.Tables[0].Columns["itype"].ToString();
        dditemtype7.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype7.DataSource = ds.Tables[0];
        dditemtype7.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDTypebind8()
    {
        DataSet ds;
        string qry = string.Format("Select distinct itype,typecode  from MASTINVENTORY order by itype");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' itype,'NIL' typecode";
            ds = DBConnection.fillDataSet(qry);
        }

        dditemtype8.DataTextField = ds.Tables[0].Columns["itype"].ToString();
        dditemtype8.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype8.DataSource = ds.Tables[0];
        dditemtype8.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDTypebind9()
    {
        DataSet ds;
        string qry = string.Format("Select distinct itype,typecode  from MASTINVENTORY order by itype");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' itype,'NIL' typecode";
            ds = DBConnection.fillDataSet(qry);
        }

        dditemtype9.DataTextField = ds.Tables[0].Columns["itype"].ToString();
        dditemtype9.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype9.DataSource = ds.Tables[0];
        dditemtype9.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDTypebind10()
    {
        DataSet ds;
        string qry = string.Format("Select distinct itype,typecode  from MASTINVENTORY order by itype");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' itype,'NIL' typecode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemtype10.DataTextField = ds.Tables[0].Columns["itype"].ToString();
        dditemtype10.DataValueField = ds.Tables[0].Columns["typecode"].ToString();
        dditemtype10.DataSource = ds.Tables[0];
        dditemtype10.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDNameItembind1()
    {
        // commented codes used for MCR linking   
        //if (dditemtype.SelectedItem.Text == "NIL")
        //{
        //    dditemname.SelectedItem.Text = "NIL";           
        //}
        //else
        //{
        //    DataSet ds;
        //    string qry = string.Format("Select distinct itemcode,itemname from MCR" +
        //                               " where typecode={0} and estid={1} and subdivisionid={2}" +
        //                               " order by itemname"
        //                                , dditemtype.SelectedValue, ddestimate.SelectedValue, Session["subdivisonid"]);
        //    ds = DBConnection.fillDataSet(qry);
        //    if (ds.Tables[0].Rows.Count == 0)
        //    {
        //        qry = "SELECT 'NIL' itemname, 'NIL' itemcode";
        //        ds = DBConnection.fillDataSet(qry);
        //    }
        //    dditemname.DataTextField = ds.Tables[0].Columns["itemname"].ToString();
        //    dditemname.DataValueField = ds.Tables[0].Columns["itemcode"].ToString();
        //    dditemname.DataSource = ds.Tables[0];
        //    dditemname.DataBind();
        //    ds.Clear();
        //    ds.Dispose();
        //}

        DataSet ds;
        string qry = string.Format("Select  iname,icode  from mastinventory" +
                                   " where typecode='{0}' " +
                                   " order by iname"
                                    , dditemtype1.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' iname, 'NIL' icode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemname1.DataTextField = ds.Tables[0].Columns["iname"].ToString();
        dditemname1.DataValueField = ds.Tables[0].Columns["icode"].ToString();
        dditemname1.DataSource = ds.Tables[0];
        dditemname1.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDNameItembind2()
    {
        DataSet ds;
        string qry = string.Format("Select  iname,icode  from mastinventory" +
                                  " where typecode='{0}' " +
                                  " order by iname"
                                   , dditemtype2.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' iname, 'NIL' icode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemname2.DataTextField = ds.Tables[0].Columns["iname"].ToString();
        dditemname2.DataValueField = ds.Tables[0].Columns["icode"].ToString();
        dditemname2.DataSource = ds.Tables[0];
        dditemname2.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDNameItembind3()
    {
        DataSet ds;
        string qry = string.Format("Select  iname,icode  from mastinventory" +
                                  " where typecode='{0}' " +
                                  " order by iname"
                                   , dditemtype3.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' iname, 'NIL' icode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemname3.DataTextField = ds.Tables[0].Columns["iname"].ToString();
        dditemname3.DataValueField = ds.Tables[0].Columns["icode"].ToString();
        dditemname3.DataSource = ds.Tables[0];
        dditemname3.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDNameItembind4()
    {
        DataSet ds;
        string qry = string.Format("Select  iname,icode  from mastinventory" +
                                  " where typecode='{0}' " +
                                  " order by iname"
                                   , dditemtype4.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' iname, 'NIL' icode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemname4.DataTextField = ds.Tables[0].Columns["iname"].ToString();
        dditemname4.DataValueField = ds.Tables[0].Columns["icode"].ToString();
        dditemname4.DataSource = ds.Tables[0];
        dditemname4.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDNameItembind5()
    {
        DataSet ds;
        string qry = string.Format("Select  iname,icode  from mastinventory" +
                                  " where typecode='{0}' " +
                                  " order by iname"
                                   , dditemtype5.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' iname, 'NIL' icode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemname5.DataTextField = ds.Tables[0].Columns["iname"].ToString();
        dditemname5.DataValueField = ds.Tables[0].Columns["icode"].ToString();
        dditemname5.DataSource = ds.Tables[0];
        dditemname5.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDNameItembind6()
    {
        DataSet ds;
        string qry = string.Format("Select  iname,icode  from mastinventory" +
                                  " where typecode='{0}' " +
                                  " order by iname"
                                   , dditemtype6.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' iname, 'NIL' icode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemname6.DataTextField = ds.Tables[0].Columns["iname"].ToString();
        dditemname6.DataValueField = ds.Tables[0].Columns["icode"].ToString();
        dditemname6.DataSource = ds.Tables[0];
        dditemname6.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDNameItembind7()
    {
        DataSet ds;
        string qry = string.Format("Select  iname,icode  from mastinventory" +
                                  " where typecode='{0}' " +
                                  " order by iname"
                                   , dditemtype7.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' iname, 'NIL' icode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemname7.DataTextField = ds.Tables[0].Columns["iname"].ToString();
        dditemname7.DataValueField = ds.Tables[0].Columns["icode"].ToString();
        dditemname7.DataSource = ds.Tables[0];
        dditemname7.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDNameItembind8()
    {
        DataSet ds;
        string qry = string.Format("Select  iname,icode  from mastinventory" +
                                  " where typecode='{0}' " +
                                  " order by iname"
                                   , dditemtype8.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' iname, 'NIL' icode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemname8.DataTextField = ds.Tables[0].Columns["iname"].ToString();
        dditemname8.DataValueField = ds.Tables[0].Columns["icode"].ToString();
        dditemname8.DataSource = ds.Tables[0];
        dditemname8.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDNameItembind9()
    {
        DataSet ds;
        string qry = string.Format("Select  iname,icode  from mastinventory" +
                                  " where typecode='{0}' " +
                                  " order by iname"
                                   , dditemtype9.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' iname, 'NIL' icode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemname9.DataTextField = ds.Tables[0].Columns["iname"].ToString();
        dditemname9.DataValueField = ds.Tables[0].Columns["icode"].ToString();
        dditemname9.DataSource = ds.Tables[0];
        dditemname9.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDNameItembind10()
    {
        DataSet ds;
        string qry = string.Format("Select  iname,icode  from mastinventory" +
                                  " where typecode='{0}' " +
                                  " order by iname"
                                   , dditemtype10.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' iname, 'NIL' icode";
            ds = DBConnection.fillDataSet(qry);
        }
        dditemname10.DataTextField = ds.Tables[0].Columns["iname"].ToString();
        dditemname10.DataValueField = ds.Tables[0].Columns["icode"].ToString();
        dditemname10.DataSource = ds.Tables[0];
        dditemname10.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDGoodsType1()
    {
        // commented codes used for MCR linking   
        //DataSet ds;
        //string qry = string.Format("SELECT distinct goodstype from MCR" +
        //                           " where subdivisionid={0} and Estatus='{1}' and itemcode='{2}' and estid={3} " +
        //                           "order by goodstype"
        //                            , Session["subdivisonid"], "OK", dditemname.SelectedValue, ddestimate.SelectedValue);
        //ds = DBConnection.fillDataSet(qry);
        //if (ds.Tables[0].Rows.Count == 0)
        //{
        //    qry = "SELECT 'NIL' goodstype";
        //    ds = DBConnection.fillDataSet(qry);
        //}
        //ddgoodstype.DataTextField = ds.Tables[0].Columns["goodstype"].ToString();
        //ddgoodstype.DataValueField = ds.Tables[0].Columns["goodstype"].ToString();
        //ddgoodstype.DataSource = ds.Tables[0];
        //ddgoodstype.DataBind();
        //ds.Clear();
        //ds.Dispose();

        DataSet ds;
        string qry = string.Format("SELECT goodsid,goodsstatus from MasterGoodsStatus");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' goodsid, 'NIL' goodsstatus";
            ds = DBConnection.fillDataSet(qry);
        }
        ddgoodstype1.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
        ddgoodstype1.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
        ddgoodstype1.DataSource = ds.Tables[0];
        ddgoodstype1.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDGoodsType2()
    {
        DataSet ds;
        string qry = string.Format("SELECT goodsid,goodsstatus from MasterGoodsStatus");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' goodsid, 'NIL' goodsstatus";
            ds = DBConnection.fillDataSet(qry);
        }
        ddgoodstype2.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
        ddgoodstype2.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
        ddgoodstype2.DataSource = ds.Tables[0];
        ddgoodstype2.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDGoodsType3()
    {
        DataSet ds;
        string qry = string.Format("SELECT goodsid,goodsstatus from MasterGoodsStatus");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' goodsid, 'NIL' goodsstatus";
            ds = DBConnection.fillDataSet(qry);
        }
        ddgoodstype3.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
        ddgoodstype3.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
        ddgoodstype3.DataSource = ds.Tables[0];
        ddgoodstype3.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDGoodsType4()
    {
        DataSet ds;
        string qry = string.Format("SELECT goodsid,goodsstatus from MasterGoodsStatus");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' goodsid, 'NIL' goodsstatus";
            ds = DBConnection.fillDataSet(qry);
        }
        ddgoodstype4.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
        ddgoodstype4.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
        ddgoodstype4.DataSource = ds.Tables[0];
        ddgoodstype4.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDGoodsType5()
    {
        DataSet ds;
        string qry = string.Format("SELECT goodsid,goodsstatus from MasterGoodsStatus");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' goodsid, 'NIL' goodsstatus";
            ds = DBConnection.fillDataSet(qry);
        }
        ddgoodstype5.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
        ddgoodstype5.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
        ddgoodstype5.DataSource = ds.Tables[0];
        ddgoodstype5.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDGoodsType6()
    {
        DataSet ds;
        string qry = string.Format("SELECT goodsid,goodsstatus from MasterGoodsStatus");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' goodsid, 'NIL' goodsstatus";
            ds = DBConnection.fillDataSet(qry);
        }
        ddgoodstype6.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
        ddgoodstype6.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
        ddgoodstype6.DataSource = ds.Tables[0];
        ddgoodstype6.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDGoodsType7()
    {
        DataSet ds;
        string qry = string.Format("SELECT goodsid,goodsstatus from MasterGoodsStatus");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' goodsid, 'NIL' goodsstatus";
            ds = DBConnection.fillDataSet(qry);
        }
        ddgoodstype7.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
        ddgoodstype7.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
        ddgoodstype7.DataSource = ds.Tables[0];
        ddgoodstype7.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDGoodsType8()
    {
        DataSet ds;
        string qry = string.Format("SELECT goodsid,goodsstatus from MasterGoodsStatus");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' goodsid, 'NIL' goodsstatus";
            ds = DBConnection.fillDataSet(qry);
        }
        ddgoodstype8.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
        ddgoodstype8.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
        ddgoodstype8.DataSource = ds.Tables[0];
        ddgoodstype8.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDGoodsType9()
    {
        DataSet ds;
        string qry = string.Format("SELECT goodsid,goodsstatus from MasterGoodsStatus");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' goodsid, 'NIL' goodsstatus";
            ds = DBConnection.fillDataSet(qry);
        }
        ddgoodstype9.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
        ddgoodstype9.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
        ddgoodstype9.DataSource = ds.Tables[0];
        ddgoodstype9.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void DDGoodsType10()
    {
        DataSet ds;
        string qry = string.Format("SELECT goodsid,goodsstatus from MasterGoodsStatus");
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' goodsid, 'NIL' goodsstatus";
            ds = DBConnection.fillDataSet(qry);
        }
        ddgoodstype10.DataTextField = ds.Tables[0].Columns["goodsstatus"].ToString();
        ddgoodstype10.DataValueField = ds.Tables[0].Columns["goodsid"].ToString();
        ddgoodstype10.DataSource = ds.Tables[0];
        ddgoodstype10.DataBind();
        ds.Clear();
        ds.Dispose();
    }
    private void txtunitbind1()
    {
        // commented codes used for MCR linking  
        //DataSet ds;
        //string qry = string.Format("SELECT distinct unit,qtysanctioned,qtydrawn,contractor,jename,sdoname from MCR" +
        //                           " where subdivisionid={0} and Estatus='{1}' and itemcode='{2}' and estid={3} " 
        //                            , Session["subdivisonid"], "OK", dditemname.SelectedValue, ddestimate.SelectedValue);
        //ds = DBConnection.fillDataSet(qry);
        //if (ds.Tables[0].Rows.Count != 0)
        //{
        //    txtunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
        //    txtqty.Text = ds.Tables[0].Rows[0]["qtysanctioned"].ToString();
        //    txtqtydrwn.Text = ds.Tables[0].Rows[0]["qtydrawn"].ToString();
        //    txtcontractor.Text = ds.Tables[0].Rows[0]["contractor"].ToString();
        //    //txtje.Text = ds.Tables[0].Rows[0]["jename"].ToString();
        //    //txtsdo.Text = ds.Tables[0].Rows[0]["sdoname"].ToString();
        //    txtje.Text = Session["employeename"].ToString();
        //    txtsdo.Text = Session["employeecode"].ToString();
        //}
        //ds.Clear();
        //ds.Dispose();

        DataSet ds;
        string qry = string.Format("Select  field1 from mastinventory" +
                                   " where icode='{0}'"
                                    , dditemname1.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' field1";
            ds = DBConnection.fillDataSet(qry);
        }
        txtunit1.Text = ds.Tables[0].Rows[0]["field1"].ToString();
        ds.Clear();
        ds.Dispose();
    }
    private void txtunitbind2()
    {
        DataSet ds;
        string qry = string.Format("Select  field1 from mastinventory" +
                                   " where icode='{0}'"
                                    , dditemname2.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' field1";
            ds = DBConnection.fillDataSet(qry);
        }
        txtunit2.Text = ds.Tables[0].Rows[0]["field1"].ToString();
        ds.Clear();
        ds.Dispose();
    }
    private void txtunitbind3()
    {
        DataSet ds;
        string qry = string.Format("Select  field1 from mastinventory" +
                                   " where icode='{0}'"
                                    , dditemname3.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' field1";
            ds = DBConnection.fillDataSet(qry);
        }
        txtunit3.Text = ds.Tables[0].Rows[0]["field1"].ToString();
        ds.Clear();
        ds.Dispose();
    }
    private void txtunitbind4()
    {
        DataSet ds;
        string qry = string.Format("Select  field1 from mastinventory" +
                                   " where icode='{0}'"
                                    , dditemname4.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' field1";
            ds = DBConnection.fillDataSet(qry);
        }
        txtunit4.Text = ds.Tables[0].Rows[0]["field1"].ToString();
        ds.Clear();
        ds.Dispose();
    }
    private void txtunitbind5()
    {
        DataSet ds;
        string qry = string.Format("Select  field1 from mastinventory" +
                                   " where icode='{0}'"
                                    , dditemname5.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' field1";
            ds = DBConnection.fillDataSet(qry);
        }
        txtunit5.Text = ds.Tables[0].Rows[0]["field1"].ToString();
        ds.Clear();
        ds.Dispose();
    }
    private void txtunitbind6()
    {
        DataSet ds;
        string qry = string.Format("Select  field1 from mastinventory" +
                                   " where icode='{0}'"
                                    , dditemname6.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' field1";
            ds = DBConnection.fillDataSet(qry);
        }
        txtunit6.Text = ds.Tables[0].Rows[0]["field1"].ToString();
        ds.Clear();
        ds.Dispose();
    }
    private void txtunitbind7()
    {
        DataSet ds;
        string qry = string.Format("Select  field1 from mastinventory" +
                                   " where icode='{0}'"
                                    , dditemname7.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' field1";
            ds = DBConnection.fillDataSet(qry);
        }
        txtunit7.Text = ds.Tables[0].Rows[0]["field1"].ToString();
        ds.Clear();
        ds.Dispose();
    }
    private void txtunitbind8()
    {
        DataSet ds;
        string qry = string.Format("Select  field1 from mastinventory" +
                                   " where icode='{0}'"
                                    , dditemname8.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' field1";
            ds = DBConnection.fillDataSet(qry);
        }
        txtunit8.Text = ds.Tables[0].Rows[0]["field1"].ToString();
        ds.Clear();
        ds.Dispose();
    }
    private void txtunitbind9()
    {
        DataSet ds;
        string qry = string.Format("Select  field1 from mastinventory" +
                                   " where icode='{0}'"
                                    , dditemname9.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' field1";
            ds = DBConnection.fillDataSet(qry);
        }
        txtunit9.Text = ds.Tables[0].Rows[0]["field1"].ToString();
        ds.Clear();
        ds.Dispose();
    }
    private void txtunitbind10()
    {
        DataSet ds;
        string qry = string.Format("Select  field1 from mastinventory" +
                                   " where icode='{0}'"
                                    , dditemname10.SelectedValue);
        ds = DBConnection.fillDataSet(qry);
        if (ds.Tables[0].Rows.Count == 0)
        {
            qry = "SELECT 'NIL' field1";
            ds = DBConnection.fillDataSet(qry);
        }
        txtunit10.Text = ds.Tables[0].Rows[0]["field1"].ToString();
        ds.Clear();
        ds.Dispose();
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

            //SqlCommand cmd = new SqlCommand("autonoincrement", con);//hod
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Connection = con;
            //cmd.Parameters.AddWithValue("@storename", ddstore.SelectedItem.Text);
            //cmd.Parameters.AddWithValue("@srchallanbookno", txtsrbook.Text);
            //cmd.Parameters.AddWithValue("@srchallanpageno", txtsrpage.Text);
            //cmd.ExecuteNonQuery();
            //cmd.Dispose();

            //if (Convert.ToDecimal(txtqtyindent.Text) <= (Convert.ToDecimal(txtqty.Text) - Convert.ToDecimal(txtqtydrwn.Text)))
            //{
            DataSet ds;
            string qry = string.Format("select srchallanbookno,srchallanpageno,srchallandate,goodstype,estimateno,stockitemyype,stockitemcode,stockitemname,unit, " +
                                       " ifield2,ifield3,stockstatus from dbo.stockissuetable " +
                                       " where srchallanbookno='{0}' and srchallanpageno='{1}' and stockitemcode='{2}' and goodstype='{3}' and istore='{4}' " +
                                       " and issuetype = '{5}' "
                                        , txtsrbook.Text, txtsrpage.Text, dditemname1.SelectedValue, ddgoodstype1.SelectedItem.Text, ddstore.SelectedItem.Text, "SR");
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (txtsrbook.Text == ds.Tables[0].Rows[0]["srchallanbookno"].ToString() && txtsrpage.Text == ds.Tables[0].Rows[0]["srchallanpageno"].ToString() && dditemname1.SelectedValue == ds.Tables[0].Rows[0]["stockitemcode"].ToString() && ddgoodstype1.SelectedItem.Text == ds.Tables[0].Rows[0]["goodstype"].ToString())
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
                    DateTime srdate = new DateTime();
                    DateTime sysdate = new DateTime();
                    string sysTime = (System.DateTime.Now).ToString("HH:mm:ss");
                    srdate = Convert.ToDateTime(txtsrdate.Text);
                    sysdate = Convert.ToDateTime((System.DateTime.Now).ToString("dd-MM-yyyy"));
                    String srchdate, systemdate;
                    srchdate = srdate.ToString("yyyy-MM-dd");
                    systemdate = sysdate.ToString("yyyy-MM-dd");
                    if (dditemtype1.SelectedItem.Text != "....")
                    {
                        string scmdText = " BEGIN ";
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
                                                     ddestimate.SelectedValue, Session["subdivison"], Session["divison"], txtcontractor.Text, ddestimate.SelectedItem.Text, dditemtype1.SelectedItem.Text, dditemname1.SelectedValue, dditemname1.SelectedItem.Text,
                                                    ddgoodstype1.SelectedItem.Text, txtunit1.Text, 786, 786, Convert.ToDecimal(txtqtyindent1.Text),
                                                    0.000, 0.000, 0.000, 0.000, 0.000, txtje.Text, txtsdo.Text,
                                                     Session["RoleN"], Session["UI"], "Pending", 1, "Work",
                                                      Session["subdivisonid"], Session["divisonid"], ddline.SelectedValue, ddline.SelectedItem.Text, "Pending", 1, dditemtype1.SelectedValue, sysTime);
                        scmdText += " END ";
                        DBConnection.executeNonQuery(scmdText);
                    }
                    if (dditemtype2.SelectedItem.Text != "....")
                    {
                        string scmdText2 = " BEGIN ";
                        scmdText2 += string.Format("Insert into stockissuetable (issuetype,istore,icurdate,srchallanbookno,srchallanpageno,srchallandate, " +
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
                                                    ddestimate.SelectedValue, Session["subdivison"], Session["divison"], txtcontractor.Text, ddestimate.SelectedItem.Text, dditemtype2.SelectedItem.Text, dditemname2.SelectedValue, dditemname2.SelectedItem.Text,
                                                   ddgoodstype2.SelectedItem.Text, txtunit2.Text, 786, 786, Convert.ToDecimal(txtqtyindent2.Text),
                                                   0.000, 0.000, 0.000, 0.000, 0.000, txtje.Text, txtsdo.Text,
                                                    Session["RoleN"], Session["UI"], "Pending", 1, "Work",
                                                     Session["subdivisonid"], Session["divisonid"], ddline.SelectedValue, ddline.SelectedItem.Text, "Pending", 1, dditemtype2.SelectedValue, sysTime);
                        scmdText2 += " END ";
                        DBConnection.executeNonQuery(scmdText2);
                    }
                    if (dditemtype3.SelectedItem.Text != "....")
                    {
                        string scmdText3 = " BEGIN ";
                        scmdText3 += string.Format("Insert into stockissuetable (issuetype,istore,icurdate,srchallanbookno,srchallanpageno,srchallandate, " +
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
                                                    ddestimate.SelectedValue, Session["subdivison"], Session["divison"], txtcontractor.Text, ddestimate.SelectedItem.Text, dditemtype3.SelectedItem.Text, dditemname3.SelectedValue, dditemname3.SelectedItem.Text,
                                                   ddgoodstype3.SelectedItem.Text, txtunit3.Text, 786, 786, Convert.ToDecimal(txtqtyindent3.Text),
                                                   0.000, 0.000, 0.000, 0.000, 0.000, txtje.Text, txtsdo.Text,
                                                    Session["RoleN"], Session["UI"], "Pending", 1, "Work",
                                                     Session["subdivisonid"], Session["divisonid"], ddline.SelectedValue, ddline.SelectedItem.Text, "Pending", 1, dditemtype3.SelectedValue, sysTime);
                        scmdText3 += " END ";
                        DBConnection.executeNonQuery(scmdText3);
                    }
                    if (dditemtype4.SelectedItem.Text != "....")
                    {
                        string scmdText4 = " BEGIN ";
                        scmdText4 += string.Format("Insert into stockissuetable (issuetype,istore,icurdate,srchallanbookno,srchallanpageno,srchallandate, " +
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
                                                    ddestimate.SelectedValue, Session["subdivison"], Session["divison"], txtcontractor.Text, ddestimate.SelectedItem.Text, dditemtype4.SelectedItem.Text, dditemname4.SelectedValue, dditemname4.SelectedItem.Text,
                                                   ddgoodstype4.SelectedItem.Text, txtunit4.Text, 786, 786, Convert.ToDecimal(txtqtyindent4.Text),
                                                   0.000, 0.000, 0.000, 0.000, 0.000, txtje.Text, txtsdo.Text,
                                                    Session["RoleN"], Session["UI"], "Pending", 1, "Work",
                                                     Session["subdivisonid"], Session["divisonid"], ddline.SelectedValue, ddline.SelectedItem.Text, "Pending", 1, dditemtype4.SelectedValue, sysTime);
                        scmdText4 += " END ";
                        DBConnection.executeNonQuery(scmdText4);
                    }
                    if (dditemtype5.SelectedItem.Text != "....")
                    {
                        string scmdText5 = " BEGIN ";
                        scmdText5 += string.Format("Insert into stockissuetable (issuetype,istore,icurdate,srchallanbookno,srchallanpageno,srchallandate, " +
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
                                                    ddestimate.SelectedValue, Session["subdivison"], Session["divison"], txtcontractor.Text, ddestimate.SelectedItem.Text, dditemtype5.SelectedItem.Text, dditemname5.SelectedValue, dditemname5.SelectedItem.Text,
                                                   ddgoodstype5.SelectedItem.Text, txtunit5.Text, 786, 786, Convert.ToDecimal(txtqtyindent5.Text),
                                                   0.000, 0.000, 0.000, 0.000, 0.000, txtje.Text, txtsdo.Text,
                                                    Session["RoleN"], Session["UI"], "Pending", 1, "Work",
                                                     Session["subdivisonid"], Session["divisonid"], ddline.SelectedValue, ddline.SelectedItem.Text, "Pending", 1, dditemtype5.SelectedValue, sysTime);
                        scmdText5 += " END ";
                        DBConnection.executeNonQuery(scmdText5);
                    }
                    if (dditemtype6.SelectedItem.Text != "....")
                    {
                        string scmdText6 = " BEGIN ";
                        scmdText6 += string.Format("Insert into stockissuetable (issuetype,istore,icurdate,srchallanbookno,srchallanpageno,srchallandate, " +
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
                                                    ddestimate.SelectedValue, Session["subdivison"], Session["divison"], txtcontractor.Text, ddestimate.SelectedItem.Text, dditemtype6.SelectedItem.Text, dditemname6.SelectedValue, dditemname6.SelectedItem.Text,
                                                   ddgoodstype6.SelectedItem.Text, txtunit6.Text, 786, 786, Convert.ToDecimal(txtqtyindent6.Text),
                                                   0.000, 0.000, 0.000, 0.000, 0.000, txtje.Text, txtsdo.Text,
                                                    Session["RoleN"], Session["UI"], "Pending", 1, "Work",
                                                     Session["subdivisonid"], Session["divisonid"], ddline.SelectedValue, ddline.SelectedItem.Text, "Pending", 1, dditemtype6.SelectedValue, sysTime);
                        scmdText6 += " END ";
                        DBConnection.executeNonQuery(scmdText6);
                    }
                    if (dditemtype7.SelectedItem.Text != "....")
                    {
                        string scmdText7 = " BEGIN ";
                        scmdText7 += string.Format("Insert into stockissuetable (issuetype,istore,icurdate,srchallanbookno,srchallanpageno,srchallandate, " +
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
                                                    ddestimate.SelectedValue, Session["subdivison"], Session["divison"], txtcontractor.Text, ddestimate.SelectedItem.Text, dditemtype7.SelectedItem.Text, dditemname7.SelectedValue, dditemname7.SelectedItem.Text,
                                                   ddgoodstype7.SelectedItem.Text, txtunit7.Text, 786, 786, Convert.ToDecimal(txtqtyindent7.Text),
                                                   0.000, 0.000, 0.000, 0.000, 0.000, txtje.Text, txtsdo.Text,
                                                    Session["RoleN"], Session["UI"], "Pending", 1, "Work",
                                                     Session["subdivisonid"], Session["divisonid"], ddline.SelectedValue, ddline.SelectedItem.Text, "Pending", 1, dditemtype7.SelectedValue, sysTime);
                        scmdText7 += " END ";
                        DBConnection.executeNonQuery(scmdText7);
                    }
                    if (dditemtype8.SelectedItem.Text != "....")
                    {
                        string scmdText8 = " BEGIN ";
                        scmdText8 += string.Format("Insert into stockissuetable (issuetype,istore,icurdate,srchallanbookno,srchallanpageno,srchallandate, " +
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
                                                    ddestimate.SelectedValue, Session["subdivison"], Session["divison"], txtcontractor.Text, ddestimate.SelectedItem.Text, dditemtype8.SelectedItem.Text, dditemname8.SelectedValue, dditemname8.SelectedItem.Text,
                                                   ddgoodstype8.SelectedItem.Text, txtunit8.Text, 786, 786, Convert.ToDecimal(txtqtyindent8.Text),
                                                   0.000, 0.000, 0.000, 0.000, 0.000, txtje.Text, txtsdo.Text,
                                                    Session["RoleN"], Session["UI"], "Pending", 1, "Work",
                                                     Session["subdivisonid"], Session["divisonid"], ddline.SelectedValue, ddline.SelectedItem.Text, "Pending", 1, dditemtype8.SelectedValue, sysTime);
                        scmdText8 += " END ";
                        DBConnection.executeNonQuery(scmdText8);
                    }
                    if (dditemtype9.SelectedItem.Text != "....")
                    {
                        string scmdText9 = " BEGIN ";
                        scmdText9 += string.Format("Insert into stockissuetable (issuetype,istore,icurdate,srchallanbookno,srchallanpageno,srchallandate, " +
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
                                                    ddestimate.SelectedValue, Session["subdivison"], Session["divison"], txtcontractor.Text, ddestimate.SelectedItem.Text, dditemtype9.SelectedItem.Text, dditemname9.SelectedValue, dditemname9.SelectedItem.Text,
                                                   ddgoodstype9.SelectedItem.Text, txtunit9.Text, 786, 786, Convert.ToDecimal(txtqtyindent9.Text),
                                                   0.000, 0.000, 0.000, 0.000, 0.000, txtje.Text, txtsdo.Text,
                                                    Session["RoleN"], Session["UI"], "Pending", 1, "Work",
                                                     Session["subdivisonid"], Session["divisonid"], ddline.SelectedValue, ddline.SelectedItem.Text, "Pending", 1, dditemtype9.SelectedValue, sysTime);
                        scmdText9 += " END ";
                        DBConnection.executeNonQuery(scmdText9);
                    }
                    if (dditemtype10.SelectedItem.Text != "....")
                    {
                        string scmdText10 = " BEGIN ";
                        scmdText10 += string.Format("Insert into stockissuetable (issuetype,istore,icurdate,srchallanbookno,srchallanpageno,srchallandate, " +
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
                                                    ddestimate.SelectedValue, Session["subdivison"], Session["divison"], txtcontractor.Text, ddestimate.SelectedItem.Text, dditemtype10.SelectedItem.Text, dditemname10.SelectedValue, dditemname10.SelectedItem.Text,
                                                   ddgoodstype10.SelectedItem.Text, txtunit10.Text, 786, 786, Convert.ToDecimal(txtqtyindent10.Text),
                                                   0.000, 0.000, 0.000, 0.000, 0.000, txtje.Text, txtsdo.Text,
                                                    Session["RoleN"], Session["UI"], "Pending", 1, "Work",
                                                     Session["subdivisonid"], Session["divisonid"], ddline.SelectedValue, ddline.SelectedItem.Text, "Pending", 1, dditemtype10.SelectedValue, sysTime);
                        scmdText10 += " END ";
                        DBConnection.executeNonQuery(scmdText10);
                    }
                    showMsg(lblmsg, Color.Red, "Saved Successfully!");
                    clear();
                    gridbind();
                    Label2.Visible = false;
                }
            }
            // }
            //else
            //{
            //    lblmsg1.Visible = true;
            //    showMsg(lblmsg1, Color.Red, "Indented Quantity must be less than or equal to balance Estimate Quantity!");
            //}
        }
        else if (Proceed.Text == "Update")
        {
            //if (Convert.ToDecimal(txtqtyindent.Text) <= (Convert.ToDecimal(txtqty.Text) - Convert.ToDecimal(txtqtydrwn.Text)))
            //{
            DataSet ds;
            string qry = string.Format("select srchallanbookno,srchallanpageno,srchallandate,goodstype,estimateno,stockitemyype,stockitemcode,stockitemname,unit, " +
                                       " ifield2,ifield3,stockstatus,qtyindented from dbo.stockissuetable " +
                                       " where srchallanbookno='{0}' and srchallanpageno='{1}' and stockitemcode='{2}' and goodstype='{3}' and istore='{4}' " +
                                       " and issuetype = '{5}' and qtyindented = {6} "
                                        , txtsrbook.Text, txtsrpage.Text, dditemname1.SelectedValue, ddgoodstype1.SelectedItem.Text, ddstore.SelectedItem.Text, "SR",
                                        Convert.ToDecimal(txtqtyindent1.Text));
            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (txtsrbook.Text == ds.Tables[0].Rows[0]["srchallanbookno"].ToString() && txtsrpage.Text == ds.Tables[0].Rows[0]["srchallanpageno"].ToString() && dditemname1.SelectedValue == ds.Tables[0].Rows[0]["stockitemcode"].ToString() && ddgoodstype1.SelectedItem.Text == ds.Tables[0].Rows[0]["goodstype"].ToString() && txtqtyindent1.Text == ds.Tables[0].Rows[0]["qtyindented"].ToString())
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
                                          , txtsrbook.Text, txtsrpage.Text, Convert.ToDateTime(txtsrdate.Text), txtqtyindent1.Text, i);
                scmdText += " END ";
                DBConnection.executeNonQuery(scmdText);
                showMsg(lblmsg, Color.Red, "Updated Successfully!");
                txtbox.Visible = false;
                can.Visible = true;
                clear();
                gridbind();
            }
            //  }
            //else
            //{
            //    lblmsg1.Visible = true;
            //    showMsg(lblmsg1, Color.Red, "Indented Quantity must be less than or equal to balance Estimate Quantity!");
            //    txtbox.Visible = true;
            //}

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
        scmdText += string.Format(" UPDATE stockissuetable SET  subdivstatusid = {0}, ifield2 = '{1}' " +
                                 " WHERE itxno={2} "
                              , 2, "Pending", i);
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
                                      " where transidsr={0} ", k);

            ds = DBConnection.fillDataSet(qry);
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddstore.SelectedItem.Text = ds.Tables[0].Rows[0]["istore"].ToString();
                ddestimate.SelectedItem.Text = ds.Tables[0].Rows[0]["nameofestimate"].ToString();
                ddline.SelectedItem.Text = ds.Tables[0].Rows[0]["linename"].ToString();


                int rowIdx = 1;
                foreach (DataRow drc in ds.Tables[0].Rows)
                {
                    String ddname = "dditemname" + rowIdx++;

                  //  string = "dditemname" + rowIdx++;
                    Control control = dditemname2.Parent;  //.FindControl("dditemname2");
                    DropDownList dd = control as DropDownList;

                    if (drc != null)
                    {
                        dditemname2.SelectedItem.Text = drc["stockitemname"].ToString();
                    }
                }


                ddgoodstype1.SelectedItem.Text = ds.Tables[0].Rows[0]["goodstype"].ToString();
                dditemtype1.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemyype"].ToString();
                dditemtype2.SelectedItem.Text = ds.Tables[0].Rows[1]["stockitemyype"].ToString();
                dditemname1.Items.Clear();
                dditemname1.Items.Add(new ListItem(ds.Tables[0].Rows[0]["stockitemname"].ToString(), ds.Tables[0].Rows[0]["stockitemcode"].ToString()));

                //dditemname.SelectedItem.Text = ds.Tables[0].Rows[0]["stockitemname"].ToString();
                txtunit1.Text = ds.Tables[0].Rows[0]["unit"].ToString();
                //txtqty.Text = ds.Tables[0].Rows[0]["totalqtyestimate"].ToString();
                //txtcontractor.Text = ds.Tables[0].Rows[0]["contractorname"].ToString();
                //txtje.Text = ds.Tables[0].Rows[0]["recdempname"].ToString();
                //txtsdo.Text = ds.Tables[0].Rows[0]["recdsdoname"].ToString();
                //txtqtydrwn.Text = ds.Tables[0].Rows[0]["qtydrawntilldate"].ToString();
                txtsrbook.Text = ds.Tables[0].Rows[0]["srchallanbookno"].ToString();
                txtsrpage.Text = ds.Tables[0].Rows[0]["srchallanpageno"].ToString();
                txtsrdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["srchallandate"]).ToString("dd-MM-yyyy");
                txtqtyindent1.Text = ds.Tables[0].Rows[0]["qtyindented"].ToString();

                txtquantitystore1();
                txtquantitystore2();
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
    protected void dditemtype1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind1();
        DDGoodsType1();
        txtunitbind1();
        txtquantitystore1();

    }

    protected void dditemname1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDGoodsType1();
        txtunitbind1();
        txtquantitystore1();

    }
    //protected void ddestimate_SelectedIndexChanged(object sender, EventArgs e)
    //{   
    //Commented code used for MCR linking
    //    DDTypebind();
    //    DDNameItembind();
    //    DDGoodsType();
    //    txtunitbind();
    //    txtquantitystore();
    //}

    protected void ddline_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDEstimate();
        DDTypebind1();
        DDNameItembind1();
        DDGoodsType1();
        txtunitbind1();
        txtquantitystore1();
        txtquantitystore2();
    }

    protected void ddstore_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtquantitystore1();
        txtquantitystore2();
        txtquantitystore3();
        txtquantitystore4();
        txtquantitystore5();
        txtquantitystore6();
        txtquantitystore7();
        txtquantitystore8();
        txtquantitystore9();
        txtquantitystore10();
    }
    protected void ddgoodstype1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtquantitystore1();
    }
    protected void dditemtype_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dditemname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddgoodstype_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dditemtype2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind2();
        DDGoodsType2();
        txtunitbind2();
        txtquantitystore2();
    }
    protected void dditemname2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDGoodsType2();
        txtunitbind2();
        txtquantitystore2();
    }
    protected void ddgoodstype2_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtquantitystore2();
    }
    protected void dditemtype3_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind3();
        DDGoodsType3();
        txtunitbind3();
        txtquantitystore3();
    }
    protected void dditemtype4_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind4();
        DDGoodsType4();
        txtunitbind4();
        txtquantitystore4();
    }
    protected void dditemtype5_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind5();
        DDGoodsType5();
        txtunitbind5();
        txtquantitystore5();
    }
    protected void dditemtype6_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind6();
        DDGoodsType6();
        txtunitbind6();
        txtquantitystore6();
    }
    protected void dditemtype7_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind7();
        DDGoodsType7();
        txtunitbind7();
        txtquantitystore7();
    }
    protected void dditemtype8_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind8();
        DDGoodsType8();
        txtunitbind8();
        txtquantitystore8();
    }
    protected void dditemtype9_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind9();
        DDGoodsType9();
        txtunitbind9();
        txtquantitystore9();
    }
    protected void dditemtype10_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDNameItembind10();
        DDGoodsType10();
        txtunitbind10();
        txtquantitystore10();
    }
    protected void dditemname3_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDGoodsType3();
        txtunitbind3();
        txtquantitystore3();
    }
    protected void dditemname4_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDGoodsType4();
        txtunitbind4();
        txtquantitystore4();
    }
    protected void dditemname5_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDGoodsType5();
        txtunitbind5();
        txtquantitystore5();
    }
    protected void dditemname6_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDGoodsType6();
        txtunitbind6();
        txtquantitystore6();
    }
    protected void dditemname7_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDGoodsType7();
        txtunitbind7();
        txtquantitystore7();
    }
    protected void dditemname8_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDGoodsType8();
        txtunitbind8();
        txtquantitystore8();
    }
    protected void dditemname9_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDGoodsType9();
        txtunitbind9();
        txtquantitystore9();
    }
    protected void dditemname10_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDGoodsType10();
        txtunitbind10();
        txtquantitystore10();
    }
    protected void ddgoodstype3_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtquantitystore3();
    }
    protected void ddgoodstype4_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtquantitystore4();
    }
    protected void ddgoodstype5_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtquantitystore5();
    }
    protected void ddgoodstype6_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtquantitystore6();
    }
    protected void ddgoodstype7_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtquantitystore7();
    }
    protected void ddgoodstype8_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtquantitystore8();
    }
    protected void ddgoodstype9_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtquantitystore9();
    }
    protected void ddgoodstype10_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtquantitystore10();
    }
}