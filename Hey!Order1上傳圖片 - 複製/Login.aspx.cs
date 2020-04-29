using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES_SimpleDemo;

namespace HeyOrder
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //    if (txtUid.Text == "aaaa" & txtPwd.Text == "1111")
            //    {
            //        Session["Uid"] = txtUid.Text;
            //        Session["Pwd"] = txtPwd.Text;
            //        Response.Redirect("Default.aspx");
            //    }
            //    else { 
            //    Label1.Text = "帳號密碼有誤!";
            //}
            //獲取文字框中的值
            string username = this.txtUid.Text;
            string password = this.txtPwd.Text;

            if (username.Equals("") || password.Equals(""))//使用者名稱或密碼為空
            {
                MessageBox.Show("使用者名稱或密碼不能為空");
            }
            else//使用者名稱或密碼不為空
            {
                //到資料庫中驗證
                string selectSql = "select * from Admin where tbAdmUid='" + username + "' and tbAdmPwd='" + password + "'";
                SqlHelp sqlHelper = new SqlHelp();
                int count = sqlHelper.SqlServerRecordCount(selectSql);//返回符合的結果數量
                if (count > 0)//如果資訊>0則說明匹配成功
                {
                    MessageBox.Show("資訊驗證成功");

                    //將當前登入日誌資訊寫入資料庫(待開發...)

                    //跳轉到主頁面
                    Response.Redirect("Default.aspx");

                }
                else
                {
                    MessageBox.Show("使用者名稱或密碼錯誤");
                }
            }




        }

        /**輸入框重置*/
    }
}
