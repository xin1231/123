using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeyOrder
{
    public partial class OrAdd : System.Web.UI.Page
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
                    sqlString = "INSERT INTO Order1(tbOrNO, tbMbrNO, tbShNam, tbMeNam, tbOrNum, tbOrNot, tbOrDct, tbOrSum, tbOrPay) ";
                    sqlString += " Values(@tbONO, @tbMNO, @tbSNam, @tbMNam, @tbONum, @tbONot, @tbODct, @tbOSum, @tbOPay)";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);

                    cmd.Parameters.AddWithValue("@tbONO", txttbOrNO.Text);
                    cmd.Parameters.AddWithValue("@tbMNO", txttbMbrNO.Text);
                    cmd.Parameters.AddWithValue("@tbSNam", txttbShNam.Text);
                    cmd.Parameters.AddWithValue("@tbMNam", txttbMeNam.Text);
                    cmd.Parameters.AddWithValue("@tbONum", txttbOrNum.Text);
                    cmd.Parameters.AddWithValue("@tbONot", txttbOrNot.Text);
                    cmd.Parameters.AddWithValue("@tbODct", txttbOrDct.Text);
                    cmd.Parameters.AddWithValue("@tbOSum", txttbOrSum.Text);
                    cmd.Parameters.AddWithValue("@tbOPay", txttbOrPay.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('確定要新增嗎?'); </script>");  //跳視窗
                    Response.Write("<script language=javascript>window.location.href='OrList.aspx' </script>");
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
            Response.Redirect("OrList.aspx");
        }
    }
}