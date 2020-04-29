using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HeyOrder
{
    public partial class DeUpd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string key = Request.QueryString["key"];
                //lbTitle.Text += key;
                txttbDeNO.Text = key;
                txttbDeNO.ReadOnly = true;
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
                    cn.ConnectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    string tbName = "Detail";
                    SqlCommand cmd = new SqlCommand("", cn);
                    cmd.Parameters.AddWithValue("@tbDNO", txttbDeNO.Text);
                    cmd.Parameters.AddWithValue("@tbSNam", txttbShNam.Text);
                    cmd.Parameters.AddWithValue("@tbMNam", txttbMeNam.Text);
                    cmd.Parameters.AddWithValue("@tbDNum", txttbDeNum.Text);
                    cmd.Parameters.AddWithValue("@tbDNot", txttbDeNot.Text);
                    cmd.Parameters.AddWithValue("@tbDDct", txttbDeDct.Text);
                    cmd.Parameters.AddWithValue("@tbDSum", txttbDeSum.Text);
                    cmd.Parameters.AddWithValue("@tbDPay", txttbDePay.Text);

                    cmd.CommandText = "UPDATE " + tbName + " SET ";
                    cmd.CommandText += " tbShNam = @tbSNam";
                    cmd.CommandText += ", tbMeNam = @tbMNam";            //每個欄位打上才是都有更新到
                    cmd.CommandText += ", tbDeNum = @tbDNum";
                    cmd.CommandText += ", tbDeNot = @tbDNot";
                    cmd.CommandText += ", tbDeDct = @tbDDct";
                    cmd.CommandText += ", tbDeSum = @tbDSum";
                    cmd.CommandText += ", tbDePay = @tbDPay";
                    cmd.CommandText += " WHERE tbDeNO  = @tbDNO";

                    cmd.ExecuteNonQuery();

                    cn.Close();
                    Response.Write("<script>confirm('確定要更新嗎?'); </script>");//跳視窗
                    Response.Write("<script language=javascript>window.location.href='DeList.aspx' </script>");
                    showFieldsData(txttbDeNO.Text);
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
            Response.Redirect("DeList.aspx");
        }
    }
}