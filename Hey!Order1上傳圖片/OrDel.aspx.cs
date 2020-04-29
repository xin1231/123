using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HeyOrder
{
    public partial class OrDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string key = Request.QueryString["key"];
                // lbTitle.Text += key;
                txttbOrNO.Text = key;
                txttbOrNO.ReadOnly = true;
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
                    sqlString = "SELECT * FROM Order1 ";
                    sqlString += " Where ";
                    sqlString += " tbOrNO = @txtQry";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", key);
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    SqlDataReader DR = cmd.ExecuteReader();
                    if (DR.Read())
                    {
                        txttbOrNO.Text = DR["tbOrNO"].ToString();
                        txttbMbrNO.Text = DR["tbMbrNO"].ToString();
                        txttbShNam.Text = DR["tbShNam"].ToString();
                        txttbMeNam.Text = DR["tbMeNam"].ToString();
                        txttbOrNum.Text = DR["tbOrNum"].ToString();
                        txttbOrNot.Text = DR["tbOrNot"].ToString();
                        txttbOrDct.Text = DR["tbOrDct"].ToString();
                        txttbOrSum.Text = DR["tbOrSum"].ToString();
                        txttbOrPay.Text = DR["tbOrPay"].ToString();
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
        string tbName = "Order1";
        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "DELETE  FROM " + tbName;
                    sqlString += " Where ";
                    sqlCondition = " tbOrNO = @txtQry;";
                    sqlString += sqlCondition;
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", txttbOrNO.Text.Trim());
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('確定要刪除嗎???'); </script>");
                    Response.Write("<script language=javascript>window.location.href='OrList.aspx' </script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + ex.Message + "'); </script>");
            }
        }

        protected void btncel_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrList.aspx");
        }
    }
}