using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeyOrder
{
    public partial class Login : System.Web.UI.Page
    {
        cfg cfg = new cfg();
        LoginUsr LoginUsr;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUsr = new LoginUsr(Context);
            if (LoginUsr.UsrCde != "")
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            { // '頁面首次載入實執行

                lbTitle.Text = cfg.getAppSetting("WebName") + "管理登入";

                lbSubTitle.Text = "";//"<a href=\"#\">首頁</a> > " + "<a href=\"#\">" + "管理者登入" + "</a>";

            }
        }

        protected void bntSend_Click(object sender, EventArgs e)
        {
            String UID = txtUID.Text;
            String PWD = txtPWD.Text;
            LoginUsr.chkUidPwd(UID, PWD);


            Response.Redirect("Default.aspx");
        }
    }
}