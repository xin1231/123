using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HeyOrder
{
    public partial class MbrAdd : System.Web.UI.Page
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
                    cn.ConnectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "INSERT INTO Member (tbMbrCde, tbMbrNO, tbMbrNam, tbMbrUid, tbMbrPwd, tbMbrTel, tbMbrTelOK, tbMbrEM, tbMbrEMOK, tbMbrNot) ";
                    sqlString += " Values(@tbMCde, @tbMNO, @tbMNam, @tbMUid, @tbMPwd, @tbMTel, @tbMTelOK, @tbMEM, @tbMEMOK, @tbMNot)";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);

                    cmd.Parameters.AddWithValue("@tbMCde", txttbMbrCde.Text);
                    cmd.Parameters.AddWithValue("@tbMNO", txttbMbrNO.Text);
                    cmd.Parameters.AddWithValue("@tbMNam", txttbMbrNam.Text);
                    cmd.Parameters.AddWithValue("@tbMUid", txttbMbrUid.Text);
                    cmd.Parameters.AddWithValue("@tbMPwd", txttbMbrPwd.Text);
                    cmd.Parameters.AddWithValue("@tbMTel", txttbMbrTel.Text);
                    cmd.Parameters.AddWithValue("@tbMTelOK", txttbMbrTelOK.Text);
                    cmd.Parameters.AddWithValue("@tbMEM", txttbMbrEM.Text);
                    cmd.Parameters.AddWithValue("@tbMEMOK", txttbMbrEMOK.Text);
                    cmd.Parameters.AddWithValue("@tbMNot", txttbMbrNot.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('確定要新增嗎?'); </script>");  //跳視窗
                    Response.Write("<script language=javascript>window.location.href='MbrList.aspx' </script>");
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
            Response.Redirect("MbrList.aspx");
        }

        
    }
}