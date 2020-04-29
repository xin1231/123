using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm1
{
    public partial class departDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string key = Request.QueryString["key"];
                // lbTitle.Text += key;
                txtID.Text = key;
                txtID.ReadOnly = true;
                showFieldsData(key);
            }
        }
        protected void showFieldsData(string key)
        {
            try
            {
                string sqlString;
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                        "database=DB1; Integrated Security=True";
                    cn.Open();
                    sqlString = "SELECT * FROM depart ";
                    sqlString += " Where ";
                    sqlString += " depNo = @pTxtQry";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@pTxtQry", key);
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    SqlDataReader DR = cmd.ExecuteReader();
                    if (DR.Read())
                    {
                        txtName.Text = DR["depName"].ToString();
                        txtRemark.Text = DR["depRemark"].ToString();
                    }
                    else
                    {
                        Response.Write("<script> confirm('查無資料'); </script>");
                    }

                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + @ex.Message + "'); </script>");
            }
        }
        string sqlString;
        string sqlCondition = "";
        string tbName = "depart";
        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                        "database=DB1; Integrated Security=True";
                    cn.Open();
                    sqlString = "DELETE  FROM " + tbName;
                    sqlString += " Where ";
                    sqlCondition = " depNo = @pTxtQry;";
                    sqlString += sqlCondition;
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@pTxtQry", txtID.Text.Trim());
                    cmd.CommandText = sqlString;
                   // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Response.Write("<script> confirm('完成刪除!!!'); </script>");
                    Response.Redirect("departLstR.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + ex.Message + "'); </script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("departLstR.aspx");
        }
    }
}