﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace HeyOrder
{
    public partial class OrUpd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string key = Request.QueryString["key"];
                // lbTitle.Text += key;
                txttbOrNO.Text = key;
                txttbOrNO.ReadOnly = true;
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
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                        "database=Project; Integrated Security=True";
                    cn.Open();
                    sqlString = "SELECT * FROM Order1 ";
                    sqlString += " Where ";
                    sqlString += " tbOrNO = @txtQry";
                    SqlCommand cmd = new SqlCommand(sqlString, cn);
                    cmd.Parameters.AddWithValue("@txtQry", key);
                    cmd.CommandText = sqlString;
                    // Response.Write("<script> confirm('" + @sqlString + "'); </script>");
                    SqlDataReader DR = cmd.ExecuteReader();
                    if (DR.Read())
                    {
                        txttbOrNO.Text = DR["tbOrNO"].ToString();
                        txttbMbrNO.Text = DR["tbMbrNO"].ToString();
                        txttbShNam.Text = DR["tbShNam"].ToString();
                        txttbMeNam.Text = DR["tbMeNam"].ToString();
                        txttbOrNum.Text = DR["tbOrNum"].ToString();
                        txttbOrNot.Text = DR["tbOrNot"].ToString();
                        txttbOrDct.Text = DR["tbOrDct"].ToString();
                        txttbOrSum.Text = DR["tbOrSum"].ToString();
                        txttbOrPay.Text = DR["tbOrPay"].ToString();
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
        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Server=localhost\SQLEXPRESS;" +
                    "database=Project; Integrated Security=True";
                    cn.Open();
                    string tbName = "Order1";
                    SqlCommand cmd = new SqlCommand("", cn);

                    cmd.Parameters.AddWithValue("@tbONO", txttbOrNO.Text);
                    cmd.Parameters.AddWithValue("@tbMNO", txttbMbrNO.Text);
                    cmd.Parameters.AddWithValue("@tbSNam", txttbShNam.Text);
                    cmd.Parameters.AddWithValue("@tbMNam", txttbMeNam.Text);
                    cmd.Parameters.AddWithValue("@tbONum", txttbOrNum.Text);
                    cmd.Parameters.AddWithValue("@tbONot", txttbOrNot.Text);
                    cmd.Parameters.AddWithValue("@tbODct", txttbOrDct.Text);
                    cmd.Parameters.AddWithValue("@tbOSum", txttbOrSum.Text);
                    cmd.Parameters.AddWithValue("@tbOPay", txttbOrPay.Text);

                    cmd.CommandText = "UPDATE " + tbName + " SET ";
                    cmd.CommandText += " tbMbrNO = @tbMNO";            //每個欄位打上才是都有更新到
                    cmd.CommandText += ", tbShNam = @tbSNam";
                    cmd.CommandText += ", tbMeNam = @tbMNam";
                    cmd.CommandText += ", tbOrNum = @tbONum";
                    cmd.CommandText += ", tbOrNot = @tbONot";
                    cmd.CommandText += ", tbOrDct = @tbODct";
                    cmd.CommandText += ", tbOrSum = @tbOSum";
                    cmd.CommandText += ", tbOrPay = @tbOPay";
                    cmd.CommandText += " WHERE tbOrNO = @tbONO";

                    cmd.ExecuteNonQuery();

                    cn.Close();
                    Response.Write("<script> confirm('確定要更新嗎?'); </script>");  //跳視窗
                    Response.Write("<script language=javascript>window.location.href='OrList.aspx' </script>");
                    // 顯示更新結果
                    showFieldsData(txttbOrNO.Text);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> confirm('" + @ex.Message + "'); </script>");

                // Response.Write(ex.Message);
            }
        }

        protected void btncel_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrList.aspx");
        }
    }
}