using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace HeyOrder
{
    public partial class MeList : System.Web.UI.Page
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
        string tbName = "Meals";
        protected void btnQry_Click(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(txtNum.Text);
                selFields += "tbShNO as 所屬店家代碼, ";
                selFields += "tbMeNO as 餐點編號, ";
                selFields += "tbMeNam as 餐點名稱, ";
                selFields += "tbMePic as 餐點圖片, ";
                selFields += "tbMeCate as 餐點大類別, ";
                selFields += "tbMeTpe as 餐點小類別, ";
                selFields += "tbMeSiz as 餐點份量, ";
                selFields += "tbMeNum as 餐點數量, ";
                selFields += "tbMeNot as 餐點備註 ";

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
                    sqlCondition += "tbShNO like @txtQry ";
                    sqlCondition += " OR tbMeNO like @txtQry;";
                    sqlString += sqlCondition;
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", "%" + txtQry.Text.Trim() + "%"); //過濾前後空白
                    cmd.CommandText = sqlString;
                    // 再將資料查詢結果放入ds(DataSet)物件中
                    SqlDataAdapter Meals = new SqlDataAdapter("", cn);
                    Meals.SelectCommand = cmd;
                    ds.Clear();
                    Meals.Fill(ds, "菜單清單"); //使用cmd取出資料表的內容,存放到ds, 命名為"店家清單"

                    Repeater1.DataSource = ds.Tables["菜單清單"];
                    Repeater1.DataBind();
                    string rowsCount = ds.Tables["菜單清單"].Rows.Count.ToString();
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("MeAdd.aspx");
        }

        protected void btnhome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
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
            // Response.Write("<script> confirm('Delete all records...'); </script>");
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "DELETE  FROM " + tbName;
                    sqlString += " Where ";
                    sqlCondition += " tbShNO like @txtQry ";
                    sqlCondition += " OR tbMeNO like @txtQry;";
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
    }
}