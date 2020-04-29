using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebForm1
{
    public partial class departUpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("departLstR.aspx");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                    "database=DB1; Integrated Security=True";
                    cn.Open();
                    string tbName = "depart";
                    SqlCommand cmd = new SqlCommand("", cn);
                   
                    cmd.Parameters.AddWithValue("@pKey", txtID.Text);
                    cmd.Parameters.AddWithValue("@pName", txtName.Text);
                    cmd.Parameters.AddWithValue("@pRemark", txtRemark.Text);
                    
                    cmd.CommandText = "UPDATE " + tbName + " SET ";
                    cmd.CommandText += "depName = @pName";
                    cmd.CommandText += ", depRemark = @pRemark";
                    cmd.CommandText += " WHERE depNo  = @pKey";
                    
                    cmd.ExecuteNonQuery();

                    cn.Close();
                    Response.Write("<script> confirm('更新成功!'); </script>");
                    // 顯示更新結果
                    showFieldsData(txtID.Text);
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