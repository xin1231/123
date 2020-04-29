using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HeyOrder
{
    public partial class MeUpd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string key = Request.QueryString["key"];
                // lbTitle.Text += key;
                txttbMeNO.Text = key;
                txttbMeNO.ReadOnly = true;
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
                    cn.ConnectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "SELECT * FROM Meals ";
                    sqlString += " Where ";
                    sqlString += " tbMeNO = @txtQry";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", key);
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    SqlDataReader DR = cmd.ExecuteReader();
                    if (DR.Read())
                    {
                        txttbShNO.Text = DR["tbShNO"].ToString();
                        txttbMeNam.Text = DR["tbMeNam"].ToString();
                        txttbMePic.Text = DR["tbMePic"].ToString();
                        txttbMeCate.Text = DR["tbMeCate"].ToString();
                        txttbMeTpe.Text = DR["tbMeTpe"].ToString();
                        txttbMeSiz.Text = DR["tbMeSiz"].ToString();
                        txttbMeNum.Text = DR["tbMeNum"].ToString();
                        txttbMeNot.Text = DR["tbMeNot"].ToString();
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
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                    "database=Project; Integrated Security=True";
                    cn.Open();
                    string tbName = "Meals";
                    SqlCommand cmd = new SqlCommand("", cn);

                    cmd.Parameters.AddWithValue("@tbSNO", txttbShNO.Text);
                    cmd.Parameters.AddWithValue("@tbMNO", txttbMeNO.Text);
                    cmd.Parameters.AddWithValue("@tbMNam", txttbMeNam.Text);
                    cmd.Parameters.AddWithValue("@tbMPic", txttbMePic.Text);
                    cmd.Parameters.AddWithValue("@tbMCate", txttbMeCate.Text);
                    cmd.Parameters.AddWithValue("@tbMTpe", txttbMeTpe.Text);
                    cmd.Parameters.AddWithValue("@tbMSiz", txttbMeSiz.Text);
                    cmd.Parameters.AddWithValue("@tbMNum", txttbMeNum.Text);
                    cmd.Parameters.AddWithValue("@tbMNot", txttbMeNot.Text);

                    cmd.CommandText = "UPDATE " + tbName + " SET ";
                    cmd.CommandText += "tbShNO = @tbSNO";
                    cmd.CommandText += ", tbMeNam = @tbMNam";
                    cmd.CommandText += ", tbMePic = @tbMPic";           //每個欄位打上才是都有更新到
                    cmd.CommandText += ", tbMeCate = @tbMCate";
                    cmd.CommandText += ", tbMeTpe = @tbMTpe";
                    cmd.CommandText += ", tbMeSiz = @tbMSiz";
                    cmd.CommandText += ", tbMeNum = @tbMNum";
                    cmd.CommandText += ", tbMeNot = @tbMNot";
                    cmd.CommandText += " WHERE tbMeNO  = @tbMNO";

                    cmd.ExecuteNonQuery();

                    cn.Close();
                    Response.Write("<script> confirm('確定要更新嗎?'); </script>");    //跳視窗
                    Response.Write("<script language=javascript>window.location.href='MeList.aspx' </script>");
                    // 顯示更新結果
                    showFieldsData(txttbMeNO.Text);
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
            Response.Redirect("MeList.aspx");
        }
    }
}