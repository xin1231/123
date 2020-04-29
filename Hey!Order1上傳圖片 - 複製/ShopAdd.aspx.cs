using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace HeyOrder
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string sqlString;
        string photoFileName;
        SqlConnection cnn;
        string myConnectString = @"Data Source = localhost; Initial Catalog = Heyorder; Integrated Security = True ";
        protected void myUploadFile()  //連結資料庫
        {
            try
            {
                //SqlCommand myComm = new SqlCommand("", cnn);
                string folderPath = Server.MapPath("~/photo");    //取得絕對圖檔路徑
                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath);
                }
                // 判斷 Server 上檔案名稱是否有重覆情況，有的話必須進行更名
                // 使用 Path.Combine 來集合路徑的優點
                //  以前發生過儲存 Table 內的是 \\ServerName\Dir（最後面沒有 \ 符號），
                //  直接跟 FileName 來進行結合，會變成 \\ServerName\DirFileName 的情況，
                //  資料夾路徑的最後面有沒有 \ 符號變成還需要判斷，但用 Path.Combine 來結合的話，
                //  資料夾路徑沒有 \ 符號，會自動補上，有的話，就直接結合
                string filename = FU1.FileName;
                string extension = Path.GetExtension(filename).ToLowerInvariant();
                // 絶對路徑+檔名
                string serverFilePath = Path.Combine(folderPath, filename);
                string fileNameOnly = Path.GetFileNameWithoutExtension(filename);
                int fileCount = 1;
                while (File.Exists(serverFilePath))
                {
                    // 重覆檔案的命名規則為 檔名_1、檔名_2 以此類推
                    filename = string.Concat(fileNameOnly, "_", fileCount, extension);
                    serverFilePath = Path.Combine(folderPath, filename);
                    fileCount++;
                }
                //Save the File to the Directory (Folder).
                // FU1.SaveAs(folderPath + Path.GetFileName(FU1.FileName));
                FU1.SaveAs(serverFilePath);
                photoFileName = "photo/" + filename;
                //Display the Picture in Image control.
                imgPhoto.ImageUrl = photoFileName;
                //myComm.Parameters.AddWithValue("@tbSPhotoFileName", photoFileName);
                //myComm.ExecuteNonQuery(); 
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                // MessageBox.Show(this, ex.Message);
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {

            try
            {
                cnn = new SqlConnection(myConnectString);
                cnn.Open();

                myUploadFile();  // 要先執行此自訂方法, 檔案名稱才會正確. 

                string commString = "INSERT INTO Shop (tbShNO, tbShNam, tbShTel, tbShPhotoFileName, tbShTim, tbShNot) ";
                commString += " VALUES (@tbSNO, @tbSNam,  @tbSTel, @tbSPhotoFileName, @tbSTim, @tbSNot)";
                SqlCommand myComm = new SqlCommand(commString, cnn);
                //myComm.Parameters.Add("@staID", SqlDbType.NVarChar);
                //myComm.Parameters.Add("@depID", SqlDbType.NVarChar);
                //myComm.Parameters.Add("@staName", SqlDbType.NVarChar);
                //myComm.Parameters.Add("@staPhone", SqlDbType.NVarChar);

                myComm.Parameters.AddWithValue("@tbSNO", txttbShNO.Text);
                myComm.Parameters.AddWithValue("@tbSNam", txttbShNam.Text);
                myComm.Parameters.AddWithValue("@tbSTel", txttbShTel.Text);
                myComm.Parameters.AddWithValue("@tbSPhotoFileName", photoFileName);
                myComm.Parameters.AddWithValue("@tbSTim", txttbShTim.Text);
                myComm.Parameters.AddWithValue("@tbSNot", txttbShNot.Text);
                // myComm.Parameters.Add("@staSalary", SqlDbType.Int);
                // myComm.Parameters["@staSalary"].Value = int.Parse(txtSalary.Text);
                // 
                //Response.Write("<p>存檔前程式</p>");
                myComm.ExecuteNonQuery();
                cnn.Close();
                // 
                Response.Write("<p>存檔程式成功</p>");
                //Response.Write("<script> confirm('確定要新增嗎???'); </script>");  //跳視窗
                //Response.Write("<script language=javascript>window.location.href='ShopList.aspx' </script>");

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                // MessageBox.Show(this, ex.Message);
            }
        }
        protected void btncel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShopList.aspx");
        }
    }
}