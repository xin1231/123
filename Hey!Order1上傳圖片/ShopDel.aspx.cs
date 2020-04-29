using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeyOrder
{
    public partial class ShopDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string key = Request.QueryString["key"];
                // lbTitle.Text += key;
                txttbShNO.Text = key;
                txttbShNO.ReadOnly = true;
                showFieldsData(key);
            }
        }
        protected void showFieldsData(string key)         //顯示刪除或更新帶入的欄位
        { 
            try
            {
                string sqlString;
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost; Initial Catalog = Heyorder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "SELECT * FROM Shop ";
                    sqlString += " Where ";
                    sqlString += " tbShNO = @txtQry";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", key);
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    SqlDataReader DR = cmd.ExecuteReader();
                    if (DR.Read())
                    {
                        txttbShNam.Text = DR["tbShNam"].ToString();
                        txttbShTel.Text = DR["tbShTel"].ToString();
                        txttbShTim.Text = DR["tbShTim"].ToString();
                        txttbShNot.Text = DR["tbShNot"].ToString();
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
        string tbName = "Shop";
        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost; Initial Catalog = Heyorder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "DELETE  FROM " + tbName;
                    sqlString += " Where ";
                    sqlCondition = " tbShNO = @txtQry;";
                    sqlString += sqlCondition;
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", txttbShNO.Text.Trim());
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('確定刪除嗎???'); </script>");  //跳視窗
                    Response.Write("<script language=javascript>window.location.href='ShopList.aspx' </script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + ex.Message + "'); </script>");
            }
        }
        protected void btncel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShopList.aspx");
        }

        
    }
}