using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Logout : System.Web.UI.Page
{
    LoginUsr LoginUsr;
    protected void Page_Load(object sender, EventArgs e)
    {
           LoginUsr = new LoginUsr(Context);

           LoginUsr.LogOut();
    }
}