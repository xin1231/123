using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeyOrder
{
    public partial class MbrDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string key = Request.QueryString["key"];
                // lbTitle.Text += key;
                txttbMbrNO.Text = key;
                txttbMbrNO.ReadOnly = true;
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
                    cn.ConnectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "SELECT * FROM Member ";
                    sqlString += " Where ";
                    sqlString += " tbMbrNO = @txtQry";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", key);
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    SqlDataReader DR = cmd.ExecuteReader();
                    if (DR.Read())
                    {
                        txttbMbrCde.Text = DR["tbMbrCde"].ToString();
                        txttbMbrNam.Text = DR["tbMbrNam"].ToString();
                        txttbMbrUid.Text = DR["tbMbrUid"].ToString();
                        txttbMbrPwd.Text = DR["tbMbrPwd"].ToString();
                        txttbMbrTel.Text = DR["tbMbrTel"].ToString();
                        txttbMbrEM.Text = DR["tbMbrEM"].ToString();
                        txttbMbrNot.Text = DR["tbMbrNot"].ToString();
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
        string tbName = "Member";
        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost\SQLEXPRESS; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "DELETE  FROM " + tbName;
                    sqlString += " Where ";
                    sqlCondition = " tbMbrNO = @txtQry;";
                    sqlString += sqlCondition;
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", txttbMbrNO.Text.Trim());
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('確定要刪除嗎???'); </script>");
                    Response.Write("<script language=javascript>window.location.href='MbrList.aspx' </script>");
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