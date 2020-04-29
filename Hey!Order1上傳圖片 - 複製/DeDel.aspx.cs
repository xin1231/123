using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HeyOrder
{
    public partial class DeDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string key = Request.QueryString["key"];
                // lbTitle.Text += key;
                txttbDeNO.Text = key;
                txttbDeNO.ReadOnly = true;
                showFieldsData(key);
            }
        }
        protected void showFieldsData(string key)      //顯示刪除或更新帶入的欄位
        {
            try
            {
                string sqlString;
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "SELECT * FROM Detail ";
                    sqlString += " Where ";
                    sqlString += " tbDeNO = @txtQry";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", key);
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    SqlDataReader DR = cmd.ExecuteReader();
                    if (DR.Read())
                    {
                        txttbDeNO.Text = DR["tbDeNO"].ToString();
                        txttbShNam.Text = DR["tbShNam"].ToString();
                        txttbMeNam.Text = DR["tbMeNam"].ToString();
                        txttbDeNum.Text = DR["tbDeNum"].ToString();
                        txttbDeNot.Text = DR["tbDeNot"].ToString();
                        txttbDeDct.Text = DR["tbDeDct"].ToString();
                        txttbDeSum.Text = DR["tbDeSum"].ToString();
                        txttbDePay.Text = DR["tbDePay"].ToString();
                    }
                    else
                    {
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + @ex.Message + "'); </script>");
            }
        }
        string sqlString;
        string sqlCondition = "";
        string tbName = "Detail";
        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                        "database=Project; Integrated Security=True";
                    cn.Open();
                    sqlString = "DELETE  FROM " + tbName;
                    sqlString += " Where ";
                    sqlCondition = " tbDeNO = @txtQry;";
                    sqlString += sqlCondition;
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", txttbDeNO.Text.Trim());
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('確定要刪除嗎???'); </script>");
                    Response.Write("<script language=javascript>window.location.href='DeList.aspx' </script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + ex.Message + "'); </script>");
            }
        }

        protected void btncel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeList.aspx");
        }
    }
}