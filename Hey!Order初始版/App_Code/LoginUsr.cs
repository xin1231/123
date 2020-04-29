using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// LoginUsr 的摘要描述
/// </summary>
public class LoginUsr
{

    IZCls.WebFormBase WebFormBase = new IZCls.WebFormBase();
    IZCls.DataAccess DataAccess = new IZCls.DataAccess();
    cfg cfg = new cfg();
    IZCls.Cookie CookieVar = new IZCls.Cookie();

    String WebRoot = "";
    String BaseUrl = "";
    String AdminDefPath = "";

    public String UsrCde = "";
    public String UsrNme = "";
    public String UsrUid = "";
    public String UsrEml = "";


    public String CookieName = "";



    private System.Web.HttpContext context;

    public void initNow()
    {

        WebRoot = System.Configuration.ConfigurationManager.AppSettings["WebRoot"].ToString();
        BaseUrl = System.Configuration.ConfigurationManager.AppSettings["BaseUrl"].ToString();
        AdminDefPath = System.Configuration.ConfigurationManager.AppSettings["AdminDefPath"].ToString();

        CookieName = System.Configuration.ConfigurationManager.AppSettings["LoginUsrCookieNme"].ToString();

    }

    public LoginUsr()
    {
        initNow();

    }

    public LoginUsr(System.Web.HttpContext context2)
    {
        initNow();
        context = context2;

        if (context.Session["UsrCde"] == null || context.Session["UsrCde"].ToString() == "")
        { //'Session沒有

            //'檢查是否有Cookie
            String TmrcTmp = CookieVar.GetAndSetCookieValueWithHour(context, "", CookieName, 5);
            CookieVar.SetValue(TmrcTmp);
            String[,] MbrArr = CookieVar.GetValueArr();
            if (CookieVar.GetArrValue(MbrArr, "UsrCde") != "")
            { //'有

                //'取Cookie
                context.Session["UsrCde"] = CookieVar.GetArrValue(MbrArr, "UsrCde");
                context.Session["UsrNme"] = CookieVar.GetArrValue(MbrArr, "UsrNme");
                context.Session["UsrUid"] = CookieVar.GetArrValue(MbrArr, "UsrUid");
                context.Session["UsrEml"] = CookieVar.GetArrValue(MbrArr, "UsrEml");


                UsrCde = context.Session["UsrCde"].ToString();
                UsrNme = context.Session["UsrNme"].ToString();
                UsrUid = context.Session["UsrUid"].ToString();
                UsrEml = context.Session["UsrEml"].ToString();

            }
            else
            { //'沒有

                //'不用做事 回應空白

            }
        }
        else
        { //'有session

            UsrCde = context.Session["UsrCde"].ToString();
            UsrNme = context.Session["UsrNme"].ToString();
            UsrUid = context.Session["UsrUid"].ToString();
            UsrEml = context.Session["UsrEml"].ToString();
        }
    }

    /// <summary>
    /// 檢查是否登入(回到登入頁)
    /// </summary>
    /// <param name="Stu"></param>
    public void chkLogin(int Stu = 1)
    {
        if (UsrCde == "")
        {
            if (Stu == 1)
            {
                WebFormBase.ShowJavaScriptMsgBack(context.Response, "請先登入", BaseUrl + AdminDefPath + "Login.aspx");
            }
            else
            {
                context.Response.Redirect(BaseUrl + AdminDefPath + "Login.aspx");
            }
        }

    }


    // ''' <summary>
    //''' 檢查帳號密碼
    //''' </summary>
    //''' <param name="UID"></param>
    //''' <param name="PWD"></param>
    //''' <remarks></remarks>

    public void chkUidPwd(String UIDt, String PWDt)
    {
        if (UIDt == "")
        {
            WebFormBase.ShowJavaScriptMsgBack(context.Response, "請填帳號", "");
        }
        if (PWDt == "")
        {
            WebFormBase.ShowJavaScriptMsgBack(context.Response, "請填密碼", "");
        }
        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.SelectString = "select * from tbUsr where tbUsrFlg=1 and tbUsrStu=1 and tbUsrUid=@tbUsrUid and tbUsrPwd=@tbUsrPwd";
        IzDataSource.ParametersAdd("tbUsrUid", UIDt);
        IzDataSource.ParametersAdd("tbUsrPwd", PWDt);
        System.Data.DataTable tbUsr = IzDataSource.SelectDataTable();
        if (tbUsr.Rows.Count > 0)
        {

            //'加到session及cookie
            context.Session["UsrCde"] = tbUsr.Rows[0]["tbUsrCde"].ToString();
            context.Session["UsrNme"] = tbUsr.Rows[0]["tbUsrNme"].ToString();
            context.Session["UsrUid"] = tbUsr.Rows[0]["tbUsrUid"].ToString();
            context.Session["UsrEml"] = tbUsr.Rows[0]["tbUsrEml"].ToString();

            IZCls.Cookie CookieVar = new IZCls.Cookie();
            CookieVar.AddValue("UsrCde", context.Session["UsrCde"].ToString());
            CookieVar.AddValue("UsrNme", context.Session["UsrNme"].ToString());
            CookieVar.AddValue("UsrUid", context.Session["UsrUid"].ToString());
            CookieVar.AddValue("UsrEml", context.Session["UsrEml"].ToString());

            CookieVar.SetCookieValue(context.Response, CookieName, CookieVar.GetStr(), 3); //'寫入cookie



            //'寫入登入紀錄
            //IzDataSource.ExecuteSQLNoneQuery("insert into tbLog(tbUsrCde,tbLogLdt,tbLogLip) values('" & context.Session("UsrCde") & "',getdate(),'" & context.Request.UserHostAddress & "')")

            //Dim tbUsrLcn As System.Data.DataTable = IzDataSource.GenDataTable("select count(*) from tbLog where tbUsrCde='" & context.Session("UsrCde") & "'")
            //IzDataSource.ExecuteSQLNoneQuery("update tbUsr set tbUsrLcn=" & tbUsrLcn.Rows(0).Item(0) & " where tbUsrCde='" & context.Session("UsrCde") & "'")
            //tbUsrLcn.Dispose()


        }
        else
        {

            WebFormBase.ShowJavaScriptMsgBack(context.Response, "帳號密碼錯誤!", "");

        }
        tbUsr.Dispose();
        IzDataSource.Dispose();

    }


    //''' 登出

    public void LogOut()
    {

        //'加到session及cookie
        context.Session["UsrCde"] = "";
        context.Session["UsrNme"] = "";
        context.Session["UsrUid"] = "";
        context.Session["UsrEml"] = "";



        IZCls.Cookie CookieVar = new IZCls.Cookie();
        CookieVar.AddValue("UsrCde", "");
        CookieVar.AddValue("UsrNme", "");
        CookieVar.AddValue("UsrUid", "");
        CookieVar.AddValue("UsrEml", "");


        CookieVar.SetCookieValue(context.Response, CookieName, CookieVar.GetStr(), 1); //'寫入cookie


        context.Session.Abandon();

        WebFormBase.SetCookieValue(context.Response, CookieName, "", -1);

        WebFormBase.ShowJavaScriptMsgBack(context.Response, "謝謝您的光臨", "../" + AdminDefPath + "Login.aspx");

    }


    /// <summary>
    /// 檢查密碼是否正確
    /// </summary>
    /// <param name="Pwd"></param>
    /// <returns></returns>
    public Boolean ChkPwd(String Pwd)
    {
        if (UsrCde == "") return false;
        Boolean ChkTmp = false;
        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.SelectString = "select * from tbUsr where tbUsrFlg=1 and tbUsrStu=1 and tbUsrCde=@tbUsrCde and tbUsrPwd=@tbUsrPwd";
        IzDataSource.ParametersAdd("tbUsrCde", UsrCde);
        IzDataSource.ParametersAdd("tbUsrPwd", Pwd);
        System.Data.DataTable tbUsr = IzDataSource.SelectDataTable();
        if (tbUsr.Rows.Count > 0)
        {
            ChkTmp = true;
        }
        return ChkTmp;
    }

    /// <summary>
    /// 修改密碼
    /// </summary>
    /// <param name="Pwd"></param>
    public void UpdatePwd(String Pwd)
    {
        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.UpdateCommand = "update tbUsr set tbUsrPwd=@tbUsrPwd where tbUsrCde=@tbUsrCde";
        IzDataSource.UpdateParameters.Add("tbUsrPwd", Pwd);
        IzDataSource.UpdateParameters.Add("tbUsrCde", UsrCde);
        IzDataSource.Update();
        IzDataSource.Dispose();
    }

}