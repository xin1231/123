using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HeyOrder
{
    public partial class ChgPwd : System.Web.UI.Page
    {
        IZCls.WebFormBase WebFormBase = new IZCls.WebFormBase();
        mnuDA mnuDA = new mnuDA();
        LoginUsr LoginUsr;
        protected void Page_Load(object sender, EventArgs e)
        {

            LoginUsr = new LoginUsr(Context);
            LoginUsr.chkLogin();


            if (Context.Request.QueryString["f"] != null) lbSubTitle.Text = mnuDA.GenPageTitle(Context.Request.QueryString["f"].ToString());

        }
        string sqlString;
        protected void bntSend_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                        "database=WebCSRdb; Integrated Security=True";
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    if (txtPwdOld.Text == "")
                    {
                        WebFormBase.ShowJavaScriptMsgBack(Response, "請填原帳號", "");
                    }
                    if (txtPwdNew.Text == "")
                    {
                        WebFormBase.ShowJavaScriptMsgBack(Response, "請填新帳號", "");
                    }
                    if (txtPwdNewR.Text == "")
                    {
                        WebFormBase.ShowJavaScriptMsgBack(Response, "請再輸入一次新帳號", "");
                    }
                    if (txtPwdNew.Text != txtPwdNewR.Text)
                    {
                        WebFormBase.ShowJavaScriptMsgBack(Response, "再輸入一次新帳號錯誤", "");
                    }
                    if (LoginUsr.ChkPwd(txtPwdOld.Text) == false)
                    {
                        WebFormBase.ShowJavaScriptMsgBack(Response, "原帳號錯誤", "");
                    }

                    LoginUsr.UpdatePwd(txtPwdNew.Text);

                    WebFormBase.ShowJavaScriptMsgBack(Response, "修改完成!", "Default.aspx");
                    cmd.ExecuteNonQuery();
                    cn.Close();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + ex.Message + "'); </script>");
            }
        }
    }
}