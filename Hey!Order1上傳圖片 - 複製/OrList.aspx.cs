using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeyOrder
{
    public partial class OrList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 由外部程式呼叫這個網頁
            if (!IsPostBack)    //第一次載入
            {
                btnQry_Click(sender, e);
            }
            else
            {
                // Response.Write("<script> confirm('This is a PostBack.'); </script>");
            }
        }
        DataSet ds = new DataSet();
        int num = 20;
        string sqlString;
        string selFields = " "; //保留一個空白
        string sqlCondition = "";
        string tbName = "Order1";
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrAdd.aspx");
        }

        protected void btnQry_Click(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(txtNum.Text);
                selFields += "tbOrNO as 訂單編號, ";
                selFields += "tbMbrNO as 會員編號, ";
                selFields += "tbShNam as 店家名稱, ";
                selFields += "tbMeNam as 餐點名稱, ";
                selFields += "tbOrNum as 訂購數量, ";
                selFields += "tbOrDct as 優惠碼, ";
                selFields += "tbOrNot as 備註, ";
                selFields += "tbOrSum as 訂單金額, ";
                selFields += "tbOrPay as 付款方式 ";

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "SELECT TOP " + num;
                    // sqlString += " * "; // 全部的欄位
                    sqlString += selFields;
                    sqlString += " FROM " + tbName;
                    sqlString += " Where ";
                    //sqlString += " depName LIKE '%" + txtQry.Text +"%'";
                    //sqlString += " OR depNo LIKE '%" + txtQry.Text + "%'";
                    sqlCondition += "tbOrNO like @txtQry ";
                    sqlCondition += " OR tbMbrNO like @txtQry;";
                    sqlString += sqlCondition;
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", "%" + txtQry.Text.Trim() + "%"); //過濾前後空白
                    cmd.CommandText = sqlString;
                    // 再將資料查詢結果放入ds(DataSet)物件中
                    SqlDataAdapter tbOrNO = new SqlDataAdapter("", cn);
                    tbOrNO.SelectCommand = cmd;
                    ds.Clear();
                    tbOrNO.Fill(ds, "訂單清單"); //使用cmd取出資料表的內容,存放到ds, 命名為"店家清單"
                    Repeater1.DataSource = ds.Tables["訂單清單"];
                    Repeater1.DataBind();
                    string rowsCount = ds.Tables["訂單清單"].Rows.Count.ToString();
                    lbRecords.Text = "符合查詢條件的有 " + rowsCount + " 筆資料";
                    btnDelAll.Text = "刪除全選的 " + rowsCount + " 筆資料";
                    btnDelAll.OnClientClick = "return confirm('一但刪除就無法回復， 確定要刪除 " + rowsCount + "筆資料?')";
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                Response.Write(ex.Message);
            }
        }

        protected void cbDelAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDelAll.Checked)
                btnDelAll.Visible = true;
            else
                btnDelAll.Visible = false;
        }

        protected void btnDelAll_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "DELETE  FROM " + tbName;
                    sqlString += " Where ";
                    sqlCondition += " tbOrNO like @txtQry ";
                    sqlCondition += " OR tbMbrNO like @txtQry;";
                    sqlString += sqlCondition;
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", "%" + txtQry.Text.Trim() + "%"); //過濾前後空白
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + sqlString + "'); </script>");
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('完成全選刪除!!!'); </script>");
                    cbDelAll.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + ex.Message + "'); </script>");
            }
        }

        protected void btnhome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}