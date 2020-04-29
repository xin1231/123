using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HeyOrder
{
    public partial class MbrUpd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string key = Request.QueryString["key"];
                //lbTitle.Text += key;
                txttbMbrNO.Text = key;
                txttbMbrNO.ReadOnly = true;
                showFieldsData(key);
            }
        }

        protected void showFieldsData(string key)     //顯示刪除或更新帶入的欄位
        {
            try
            {
                string sqlString;
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = HeyOrder; Integrated Security = True ";
                    cn.Open();
                    sqlString = "SELECT * FROM Member ";
                    sqlString += " Where ";
                    sqlString += " tbMbrNO = @txtQry";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", key);
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    SqlDataReader DR = cmd.ExecuteReader();
                    if (DR.Read())
                    {
                        txttbMbrCde.Text = DR["tbMbrCde"].ToString();
                        txttbMbrNam.Text = DR["tbMbrNam"].ToString();
                        txttbMbrUid.Text = DR["tbMbrUid"].ToString();
                        txttbMbrPwd.Text = DR["tbMbrPwd"].ToString();
                        txttbMbrTel.Text = DR["tbMbrTel"].ToString();
                        txttbMbrEM.Text = DR["tbMbrEM"].ToString();
                        txttbMbrNot.Text = DR["tbMbrNot"].ToString();
                    }
                    else
                    {
                        Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    }
                    
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + @ex.Message + "'); </script>");
            }
        }

        protected void btncel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MbrList.aspx");
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                    "database=Project; Integrated Security=True";
                    cn.Open();
                    string tbName = "Member";
                    SqlCommand cmd = new SqlCommand("", cn);
                    cmd.Parameters.AddWithValue("@tbMCde", txttbMbrCde.Text);
                    cmd.Parameters.AddWithValue("@tbMNO", txttbMbrNO.Text);
                    cmd.Parameters.AddWithValue("@tbMNam", txttbMbrNam.Text);
                    cmd.Parameters.AddWithValue("@tbMUid", txttbMbrUid.Text);
                    cmd.Parameters.AddWithValue("@tbMPwd", txttbMbrPwd.Text);
                    cmd.Parameters.AddWithValue("@tbMTel", txttbMbrTel.Text);
                    cmd.Parameters.AddWithValue("@tbMEM", txttbMbrEM.Text);
                    cmd.Parameters.AddWithValue("@tbMNot", txttbMbrNot.Text); ;

                    cmd.CommandText = "UPDATE " + tbName + " SET ";
                    cmd.CommandText += " tbMbrCde = @tbMCde";
                    cmd.CommandText += ", tbMbrNam = @tbMNam";
                    cmd.CommandText += ", tbMbrUid = @tbMUid";            //每個欄位打上才是都有更新到
                    cmd.CommandText += ", tbMbrPwd = @tbMPwd";
                    cmd.CommandText += ", tbMbrTel = @tbMTel";
                    cmd.CommandText += ", tbMbrEM = @tbMEM";
                    cmd.CommandText += ", tbMbrNot = @tbMNot";
                    cmd.CommandText += " WHERE tbMbrNO  = @tbMNO";

                    cmd.ExecuteNonQuery();

                    cn.Close();
                    Response.Write ("<script>confirm('確定要更新嗎?'); </script>") ;//跳視窗
                    Response.Write("<script language=javascript>window.location.href='MbrList.aspx' </script>");
                    showFieldsData(txttbMbrNO.Text);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + @ex.Message + "'); </script>");
                // Response.Write(ex.Message);
            }
        }
    }
}