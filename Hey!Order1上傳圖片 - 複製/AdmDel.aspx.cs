using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeyOrder
{
    public partial class AdmDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string key = Request.QueryString["key"];
                // lbTitle.Text += key;
                txttbAdmNO.Text = key;
                txttbAdmUid.ReadOnly = true;
                showFieldsData(key);
            }
        }
        protected void showFieldsData(string key)    //顯示刪除或更新帶入的欄位
        {
            try
            {
                string sqlString;
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                        "database=Project; Integrated Security=True";
                    cn.Open();
                    sqlString = "SELECT * FROM Admin ";
                    sqlString += " Where ";
                    sqlString += " tbAdmNO = @txtQry";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", key);
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    SqlDataReader DR = cmd.ExecuteReader();
                    if (DR.Read())
                    {
                        txttbAdmNO.Text = DR["tbAdmNO"].ToString();
                        txttbAdmUid.Text = DR["tbAdmUid"].ToString();
                        txttbAdmPwd.Text = DR["tbAdmPwd"].ToString();
                        txttbAdmNot.Text = DR["tbAdmNot"].ToString();
                        txttbAdmNot.Text = DR["tbAdmNot"].ToString();
                        txttbAdmNot.Text = DR["tbAdmNot"].ToString();
                        txttbFbkFlg.Text = DR["tbFbkFlg"].ToString();
                        txttbFbkCdt.Text = DR["tbFbkCdt"].ToString();
                    }
                    else
                    {
                        Response.Write("<script> confirm('查無資料'); </script>");
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
        string tbName = "Admin";
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
                    sqlCondition = " tbAdmNO = @txtQry;";
                    sqlString += sqlCondition;
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", txttbAdmNO.Text.Trim());
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('確定要刪除嗎???'); </script>");
                    Response.Write("<script language=javascript>window.location.href='AdmList.aspx' </script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + ex.Message + "'); </script>");
            }
        }

        protected void btncel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MbrList.aspx");
        }
    }
}