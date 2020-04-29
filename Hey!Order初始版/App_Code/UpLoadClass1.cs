using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Configuration;

/// <summary>
/// UpLoadClass1 的摘要描述
/// </summary>
public class UpLoadClass1
{
    cfg cfg = new cfg();
    public UpLoadClass1()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }
    public string myUploadFile(string filename)
    {
        try
        {
            string  path = cfg.getAppSetting("AdminULPath");

            string folderPath = System.Web.HttpContext.Current.Server.MapPath(path);
            // Response.Write(folderPath);
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
            // string filename = FU1.FileName;
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
            // FU1.SaveAs(serverFilePath);
            return  "Uploads/" + filename;
        }
        catch (Exception ex)
        {
            // Response.Write(ex.Message);
            // MessageBox.Show(this, ex.Message);
            return "error_UploadFIle " + ex.Message;
        }

    }

}