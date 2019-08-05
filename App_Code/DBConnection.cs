using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class DBConnection1
{
    private const string sConnectionString = "Data Source=DESKTOP-FDBGPRF\\AMAN;Initial Catalog=pstclinventory;Persist Security Info=True;User ID=sa;Password=strong";

    public static System.Data.SqlClient.SqlConnection connect()
    {
        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(sConnectionString);
        try
        {
            con.Open();
            return con;
        }
        catch (Exception ex)
        {
            con.Close();
            return con;
        }
    }
   public static System.Data.SqlClient.SqlConnection connect(string user, string password, string host, string service)
    {
        string sConnectionString = string.Format("user id={0};password={1};data source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={2})(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME={3})))", user, password, host, service);
        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(sConnectionString);
        try
        {
            con.Open();
            return con;
        }
        catch (Exception ex)
        {
            con.Close();
            throw ex;
        }
    }
    public static void disconnect(System.Data.SqlClient.SqlConnection con)
    {
        try
        {
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static DataTable executeProcedure(string sCommandText, string[][] param)
    {
        System.Data.SqlClient.SqlConnection con = connect();
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sCommandText, con);
        cmd.CommandType = CommandType.StoredProcedure;

        foreach (var r in param)
        {
            cmd.Parameters.AddWithValue(r[0], r[1]);
         
        }

        SqlDataReader dr = null;
        try
        {
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

            disconnect(con);
        }
    }
    public static DataSet fillDataSet(string sCommandText)
    {
        System.Data.SqlClient.SqlConnection con = connect();
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sCommandText, con);
        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            adp.Dispose();
            cmd.Dispose();
            disconnect(con);
        }
    }
    public static DataSet fillDataSet(string user, string password, string host, string service, string sCommandText)
    {
        System.Data.SqlClient.SqlConnection con = connect(user, password, host, service);
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sCommandText, con);
        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            adp.Dispose();
            cmd.Dispose();
            disconnect(con);
        }
    }
    public static Boolean fillDataSet(ref DataSet dataSet, string dataTableName, string sCommandText)
    {
        System.Data.SqlClient.SqlConnection con = connect();
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sCommandText, con);
        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
        dataSet.Tables.Add(new DataTable(dataTableName));
        try
        {
            adp.Fill(dataSet.Tables[dataTableName]);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            adp.Dispose();
            cmd.Dispose();
            disconnect(con);
        }
    }
    public static Boolean fillGridView(ref System.Web.UI.WebControls.GridView gridView, string sCommandText)
    {
        DataSet dataSet;
        try
        {
            dataSet = fillDataSet(sCommandText);
            gridView.DataSource = dataSet;
            gridView.DataBind();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static int executeNonQuery(string sCommandText)
    {
        System.Data.SqlClient.SqlConnection con = connect();
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sCommandText, con);
        try
        {
            return cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Dispose();
            disconnect(con);
        }
    }
    //public static int executeNonQuery(DataSet ds)
    //{
    //    System.Data.SqlClient.SqlConnection con = connect();
    //    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter ();
    //    System.Data.SqlClient.SqlCommandBuilder cmd = new System.Data.SqlClient.SqlCommandBuilder(da); 

    //    da.Update(da
    //    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sCommandText, con);
    //    try
    //    {
    //        return cmd.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        cmd.Dispose();
    //        disconnect(con);
    //    }
    //}

}