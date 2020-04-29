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
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                        "database=Project; Integrated Security=True";
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
                        txttbShPic.Text = DR["tbShPic"].ToString();
                        txttbShTim.Text = DR["tbShTim"].ToString();
                        txttbShNot.Text = DR["tbShNot"].ToString();
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
        string tbName = "Shop";


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
                    sqlCondition = " tbShNO = @txtQry;";
                    sqlString += sqlCondition;
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", txttbShNO.Text.Trim());
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    ////Response.Write("<script>if (confirm(msg)==true) else {}</script>")
                    //Response.Write("<script> confirm('確定要刪除嗎???'); </script>");
                    ////Response.Write("<script language=javascript>window.location.href='ShopDel.aspx' </script>");
                    //Response.Write("<script language=javascript>window.location.href='ShopList.aspx' </script>");
                    //Response.Write("<script> confirm('完成刪除!!!'); </script>");
                    //Response.Redirect("ShopList.aspx");
                    Response.Write("<script>alert('確定要刪除嗎???');location.href='ShopList.aspx';</script>");
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