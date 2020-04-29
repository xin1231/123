using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeyOrder
{
    public partial class WebForm1 : System.Web.UI.Page
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
                    cn.ConnectionString = @"Data Source = localhost; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "INSERT INTO Shop (tbShNO, tbShNam, tbShTel, tbShPic, tbShTim ,tbShNot)";
                    sqlString += " Values(@tbSNO, @tbSNam, @tbSTel, @tbSPic, @tbSTim, @tbSNot)";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);

                    cmd.Parameters.AddWithValue("@tbSNO", txttbShNO.Text);
                    cmd.Parameters.AddWithValue("@tbSNam", txttbShNam.Text);
                    cmd.Parameters.AddWithValue("@tbSTel", txttbShTel.Text);
                    cmd.Parameters.AddWithValue("@tbSPic", txttbShPic.Text);
                    cmd.Parameters.AddWithValue("@tbSTim", txttbShTim.Text);
                    cmd.Parameters.AddWithValue("@tbSNot", txttbShNot.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('確定要新增嗎?'); </script>");  //跳視窗
                    Response.Write("<script language=javascript>window.location.href='ShopList.aspx' </script>");
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
            Response.Redirect("ShopList.aspx");
        }

        
    }
}