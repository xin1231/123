using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// IzDataSource 的摘要描述
/// </summary>
public class IzDataSource : System.Web.UI.WebControls.SqlDataSource
{
    public IzDataSource()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
        this.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlSvrStr"].ConnectionString;

    }

    /// <summary>
    /// 依SQL取資料表
    /// </summary>
    /// <param name="SqlStr"></param>
    /// <returns></returns>
    public System.Data.DataTable GenDataTable(String SqlStr)
    {

        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
        conn.Open();

        System.Data.DataTable tb = new System.Data.DataTable();

        try
        {
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(SqlStr, conn);

            da.Fill(tb);
            da.Dispose();
            return tb;
        }
        catch
        {
            return tb;
        }
        finally
        {
            conn.Close();
            conn = null;
        }

    }
    /// <summary>
    /// 直接執行SQL語法
    /// </summary>
    /// <param name="SqlStr"></param>
    public void ExecuteSQLNoneQuery(String SqlStr)
    {
        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
        conn.Open();

        try
        {
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = conn;
            comm.CommandText = SqlStr;
            comm.ExecuteNonQuery();
            comm.Dispose();
        }
        finally
        {
            conn.Close();
            conn = null;
        }
    }


    /// <summary>
    /// SQL處理與法(帶參數)
    /// </summary>
    public String SelectString = "";
    private System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
    /// <summary>
    /// 清除參數設定
    /// </summary>
    public void ParametersClear()
    {
        comm.Parameters.Clear();
    }
    /// <summary>
    /// 設定參數值
    /// </summary>
    /// <param name="ParameterName">參數名稱</param>
    /// <param name="ParameterValue">參數值</param>
    public void ParametersAdd(String ParameterName, Object ParameterValue)
    {

        comm.Parameters.AddWithValue(ParameterName, ParameterValue);

    }
    /// <summary>
    /// 使用select取得DataTable
    /// </summary>
    /// <returns></returns>
    public System.Data.DataTable SelectDataTable()
    {

        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
        conn.Open();

        System.Data.DataTable tb = new System.Data.DataTable();

        try
        {
            comm.Connection = conn;
            comm.CommandText = SelectString;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(comm);

            da.Fill(tb);
            da.Dispose();

            return tb;
        }
        catch
        {

            return tb;
        }
        finally
        {

            conn.Close();
            conn.Dispose();
        }


    }

    /// <summary>
    /// 開啟資料連結
    /// </summary>
    /// <returns></returns>
    public System.Data.SqlClient.SqlConnection OpenConn()
    {
        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
        conn.Open();
        return conn;
    }
    /// <summary>
    /// 關閉資料連結
    /// </summary>
    /// <param name="conn"></param>
    public void CloseConn(System.Data.SqlClient.SqlConnection conn)
    {
        conn.Close();
        conn.Dispose();
    }

}