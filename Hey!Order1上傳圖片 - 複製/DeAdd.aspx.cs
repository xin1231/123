using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeyOrder
{
    public partial class DeAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string sqlString;
        protected void btnOk_Click(object sender, EventArgs e)
        {
            string exMsg;
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "INSERT INTO Detail(tbDeNO, tbShNam, tbMeNam, tbDeNum, tbDeNot, tbDeDct, tbDeSum, tbDePay) ";
                    sqlString += " Values(@tbDNO, @tbSNam, @tbMeNam, @tbDNum, @tbDNot, @tbDDct, @tbDSum, @tbDPay)";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);

                    cmd.Parameters.AddWithValue("@tbDNO", txttbDeNO.Text);
                    cmd.Parameters.AddWithValue("@tbSNam", txttbShNam.Text);
                    cmd.Parameters.AddWithValue("@tbMeNam", txttbMeNam.Text);
                    cmd.Parameters.AddWithValue("@tbDNum", txttbDeNum.Text);
                    cmd.Parameters.AddWithValue("@tbDNot", txttbDeNot.Text);
                    cmd.Parameters.AddWithValue("@tbDDct", txttbDeDct.Text);
                    cmd.Parameters.AddWithValue("@tbDSum", txttbDeSum.Text);
                    cmd.Parameters.AddWithValue("@tbDPay", txttbDePay.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('確定要新增嗎?'); </script>");  //跳視窗
                    Response.Write("<script language=javascript>window.location.href='DeList.aspx' </script>");
                    // 顯示更新結果
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