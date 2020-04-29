using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MainNew
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int times = 0;
            times++;
            TextBox1.Text = TextBox1.Text + times;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int  times = 0;
            times--;
            TextBox1.Text = "" + times;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}