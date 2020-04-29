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
    public partial class WebDepartLst : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)    //第一次載入
            {
                btnQry_Click(sender, e);
            }
        }
        DataSet ds = new DataSet();
        protected void btnQry_Click(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(txtNum.Text);
                string sqlString;
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                        "database=DB1; Integrated Security=True";
                    cn.Open();
                    sqlString = "SELECT TOP " + num;
                    // sqlString += " * "; // 全部的欄位
                    sqlString += "depNo as 部門號, ";
                    sqlString += "depName as 名稱, ";
                    sqlString += "depRemark as 備註 ";
                    sqlString += " FROM depart ";
                    sqlString += " Where ";
                    //sqlString += " depName LIKE '%" + txtQry.Text +"%'";
                    //sqlString += " OR depNo LIKE '%" + txtQry.Text + "%'";

                    sqlString += " depName like @pTxtQry ";
                    sqlString += " OR depNo like @pTxtQry;";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@pTxtQry", "%" + txtQry.Text.Trim() + "%"); //過濾前後空白
                    cmd.CommandText = sqlString;
                    // 再將資料查詢結果放入ds(DataSet)物件中
                    SqlDataAdapter daDep = new SqlDataAdapter("", cn);
                    daDep.SelectCommand = cmd;
                    ds.Clear();
                    daDep.Fill(ds, "部門清單"); //使用cmd取出資料表的內容,存放到ds, 命名為"部門清單"

                    GridView1.DataSource = ds.Tables["部門清單"];
                    GridView1.DataBind();
                    lbRecords.Text = "符合查詢條件的有 " + ds.Tables["部門清單"].Rows.Count.ToString() + " 筆資料";
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                Response.Write(ex.Message);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row =GridView1.SelectedRow;
            lbRowKey.Text = "選擇的資料是: " + row.Cells[0].Text;
            Response.Write(lbRowKey.Text);

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("departAdd.aspx");
        }
    }
}