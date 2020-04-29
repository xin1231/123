using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HeyOrder
{
    public partial class AdmAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        string sqlString;
        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                        "database=Project; Integrated Security=True";
                    cn.Open();
                    sqlString = "INSERT INTO Admin (tbAdmNO, tbAdmUid, tbAdmPwd, tbAdmNot) ";
                    sqlString += " Values(@tbANO, @tbAUid, @tbAPwd, @tbANot)";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);

                    cmd.Parameters.AddWithValue("@tbANO", txttbAdmNO.Text);
                    cmd.Parameters.AddWithValue("@tbAUid", txttbAdmUid.Text);
                    cmd.Parameters.AddWithValue("@tbAPwd", txttbAdmPwd.Text);
                    cmd.Parameters.AddWithValue("@tbANot", txttbAdmNot.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('確定要新增嗎?'); </script>");  //跳視窗
                    Response.Write("<script language=javascript>window.location.href='AdmList.aspx' </script>");
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
            Response.Redirect("AdmList.aspx");
        }
    }
}