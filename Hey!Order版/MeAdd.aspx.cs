using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeyOrder
{
    public partial class MeAdd : System.Web.UI.Page
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
                    sqlString = "INSERT INTO Meals (tbShNO, tbMeNO, tbMeNam, tbMePic, tbMeCate, tbMeTpe, tbMeSiz, tbMeNum, tbMeNot) ";
                    sqlString += " Values(@tbSNO, @tbMNO, @tbMNam,  @tbMPic, @tbMCate, @tbMTpe, @tbMSiz, @tbMNum, @tbMNot)";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);

                    cmd.Parameters.AddWithValue("@tbSNO", txttbShNO.Text);
                    cmd.Parameters.AddWithValue("@tbMNO", txttbMeNO.Text);
                    cmd.Parameters.AddWithValue("@tbMNam", txttbMeNam.Text);
                    cmd.Parameters.AddWithValue("@tbMPic", txttbMePic.Text);
                    cmd.Parameters.AddWithValue("@tbMCate", txttbMeCate.Text);
                    cmd.Parameters.AddWithValue("@tbMTpe", txttbMeTpe.Text);
                    cmd.Parameters.AddWithValue("@tbMSiz", txttbMeSiz.Text);
                    cmd.Parameters.AddWithValue("@tbMNum", txttbMeNum.Text);
                    cmd.Parameters.AddWithValue("@tbMNot", txttbMeNot.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('確定要新增嗎?'); </script>");  //跳視窗
                    Response.Write("<script language=javascript>window.location.href='MeList.aspx' </script>");
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
            Response.Redirect("MeList.aspx");
        }
    }
}