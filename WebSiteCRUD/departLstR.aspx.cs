using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm1
{
    public partial class departLstR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // 由外部程式呼叫這個網頁時
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
        string tbName = "depart";
        protected void btnQry_Click(object sender, EventArgs e)
        {
            try
            {
                num = int.Parse(txtNum.Text);
                selFields += "depNo as 部門號, ";
                selFields += "depName as 名稱, ";
                selFields += "depRemark as 備註 ";

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                        "database=DB1; Integrated Security=True";
                    cn.Open();
                    sqlString = "SELECT TOP " + num;
                    sqlString += selFields;
                    sqlString += " FROM " + tbName;
                    sqlString += " Where ";
                    //sqlString += " depName LIKE '%" + txtQry.Text +"%'";
                    //sqlString += " OR depNo LIKE '%" + txtQry.Text + "%'";
                    sqlCondition = " depName like @pTxtQry ";
                    sqlCondition += " OR depNo like @pTxtQry;";
                    sqlString += sqlCondition;
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@pTxtQry", "%" + txtQry.Text.Trim() + "%"); //過濾前後空白
                    cmd.CommandText = sqlString;
                    // 再將資料查詢結果放入ds(DataSet)物件中
                    SqlDataAdapter daDep = new SqlDataAdapter("", cn);
                    daDep.SelectCommand = cmd;
                    ds.Clear();
                    daDep.Fill(ds, "部門清單"); //使用cmd取出資料表的內容,存放到ds, 命名為"部門清單"
                    // 前端使用Repeater1
                    Repeater1.DataSource = ds.Tables["部門清單"];
                    Repeater1.DataBind();
                    string rowsCount = ds.Tables["部門清單"].Rows.Count.ToString();
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
            //轉到新增資料的程
            Response.Redirect("departAdd.aspx");
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
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                        "database=DB1; Integrated Security=True";
                    cn.Open();
                    sqlString = "DELETE  FROM " + tbName;
                    sqlString += " Where ";
                    sqlCondition = " depName like @pTxtQry ";
                    sqlCondition += " OR depNo like @pTxtQry;";
                    sqlString += sqlCondition;
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@pTxtQry", "%" + txtQry.Text.Trim() + "%"); //過濾前後空白
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