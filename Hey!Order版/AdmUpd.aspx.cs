using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HeyOrder
{
    public partial class AdmUpd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string key = Request.QueryString["key"];
                //lbTitle.Text += key;
                txttbAdmNO.Text = key;
                txttbAdmNO.ReadOnly = true;
                showFieldsData(key);
            }
        }
        protected void showFieldsData(string key)     //顯示刪除或更新帶入的欄位
        {
            try
            {
                string sqlString;
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost; Initial Catalog = HeyOrder; Integrated Security = True ";
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
                    }
                    else
                    {
                        Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    }

                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + @ex.Message + "'); </script>");
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    string tbName = "Admin";
                    SqlCommand cmd = new SqlCommand("", cn);
                    cmd.Parameters.AddWithValue("@tbANO", txttbAdmNO.Text);
                    cmd.Parameters.AddWithValue("@tbAUid", txttbAdmUid.Text);
                    cmd.Parameters.AddWithValue("@tbAPwd", txttbAdmPwd.Text);
                    cmd.Parameters.AddWithValue("@tbANot", txttbAdmNot.Text);

                    cmd.CommandText = "UPDATE " + tbName + " SET ";
                    cmd.CommandText += " tbAdmUid = @tbAUid";
                    cmd.CommandText += ", tbAdmPwd = @tbAPwd";            //每個欄位打上才是都有更新到
                    cmd.CommandText += ", tbAdmNot = @tbANot";
                    cmd.CommandText += " WHERE tbAdmNO  = @tbANO";

                    cmd.ExecuteNonQuery();

                    cn.Close();
                    Response.Write("<script>confirm('確定要更新嗎?'); </script>");//跳視窗
                    Response.Write("<script language=javascript>window.location.href='AdmList.aspx' </script>");
                    showFieldsData(txttbAdmNO.Text);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + @ex.Message + "'); </script>");
                // Response.Write(ex.Message);
            }
        }

        protected void btncel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdmList.aspx");
        }
    }
}