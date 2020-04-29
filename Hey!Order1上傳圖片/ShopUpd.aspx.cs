using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace HeyOrder
{
    public partial class ShopUpd : System.Web.UI.Page
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
        protected void showFieldsData(string key)     //顯示刪除或更新帶入的欄位
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
        protected void btncel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShopList.aspx");
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost; Initial Catalog = Heyorder; Integrated Security = True ";
                    cn.Open();
                    string tbName = "shop";
                    SqlCommand cmd = new SqlCommand("", cn);

                    cmd.Parameters.AddWithValue("@tbShNO", txttbShNO.Text);
                    cmd.Parameters.AddWithValue("@tbShNam", txttbShNam.Text);
                    cmd.Parameters.AddWithValue("@tbShTel", txttbShTel.Text);
                    cmd.Parameters.AddWithValue("@tbShTim", txttbShTim.Text);
                    cmd.Parameters.AddWithValue("@tbShNot", txttbShNot.Text);

                    cmd.CommandText = "UPDATE " + tbName + " SET ";
                    cmd.CommandText += "tbShNam = @tbShNam";            //每個欄位打上才是都有更新到
                    cmd.CommandText += ", tbShTel = @tbShTel";
                    cmd.CommandText += ", tbShTim = @tbShTim";
                    cmd.CommandText += ", tbShNot = @tbShNot";
                    cmd.CommandText += " WHERE tbShNO  = @tbShNO";

                    cmd.ExecuteNonQuery();

                    cn.Close();
                    Response.Write("<script> confirm('確定要更新嗎?'); </script>");  //跳視窗
                    Response.Write("<script language=javascript>window.location.href='ShopList.aspx' </script>");
                    // 顯示更新結果
                    showFieldsData(txttbShNO.Text);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + @ex.Message + "'); </script>");

                // Response.Write(ex.Message);
            }
        }
    }
}