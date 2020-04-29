using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// mnuDA 的摘要描述
/// </summary>
public class mnuDA
{
    String WebRoot = "";
    String BaseUrl = "";
    String AdminDefPath = "";

    public mnuDA()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //

        WebRoot = System.Configuration.ConfigurationManager.AppSettings["WebRoot"].ToString();
        BaseUrl = System.Configuration.ConfigurationManager.AppSettings["BaseUrl"].ToString();
        AdminDefPath = System.Configuration.ConfigurationManager.AppSettings["AdminDefPath"].ToString();

    }

    //''' <summary>
    //''' 功能類別預設值
    //''' </summary>
    //''' <remarks></remarks>
    public String[] MnuTypNmeArr = { "無", "內部", "外部" };
    //''' <summary>
    //''' 功能類別預設值
    //''' </summary>
    //''' <remarks></remarks>
    public String[] MnuTypValArr = { "0", "1", "2" };

    //''' <summary>
    //''' '取功能類別名稱
    //''' </summary>
    //''' <param name="flg"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public String getMnuTypNme(String flg)
    {
        flg = "" + flg;
        String tmp = "";
        for (int i = 0; i < MnuTypValArr.Length; i++)
        {
            if (MnuTypValArr[i] == flg)
            {
                tmp = MnuTypNmeArr[i];
                break;
            }
        }
        return tmp;
    }


    // ''' <summary>
    //''' 取得選單清單
    //''' </summary>
    //''' <param name="TopCde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public System.Data.DataTable MnuSelect(String TopCde)
    {
        IzDataSource IzDataSource = new IzDataSource();
        if (TopCde == "")
        {
            IzDataSource.SelectString = "select * from tbMnu where tbMnuFlg=1 and (tbMnuTopCde is null or tbMnuTopCde='') order by tbMnuSrt";
            IzDataSource.ParametersClear();
        }
        else
        {
            IzDataSource.SelectString = "select * from tbMnu where tbMnuFlg=1 and tbMnuTopCde=@tbMnuTopCde order by tbMnuSrt";
            IzDataSource.ParametersClear();
            IzDataSource.ParametersAdd("tbMnuTopCde", TopCde);
        }
        System.Data.DataTable tb = IzDataSource.SelectDataTable();

        IzDataSource.Dispose();

        return tb;
    }

    //''' <summary>
    //''' 取有權限的選單
    //''' </summary>
    //''' <param name="TopCde"></param>
    //''' <param name="UsrCde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public System.Data.DataTable MnuSelectUsrGrp(String TopCde, String UsrCde)
    {
        IzDataSource IzDataSource = new IzDataSource();
        if (UsrCde == "USR00000000000000001")
        {
            if (TopCde == "")
            {
                IzDataSource.SelectString = "select * from tbMnu where tbMnuFlg=1 and (tbMnuTopCde is null or tbMnuTopCde='') order by tbMnuSrt";
                IzDataSource.ParametersClear();
            }
            else
            {
                IzDataSource.SelectString = "select * from tbMnu where tbMnuFlg=1 and tbMnuTopCde=@tbMnuTopCde  order by tbMnuSrt";
                IzDataSource.ParametersClear();
                IzDataSource.ParametersAdd("tbMnuTopCde", TopCde);
            }
            IzDataSource.ParametersAdd("tbUsrCde", UsrCde);
        }
        else
        {
            if (TopCde == "")
            {
                IzDataSource.SelectString = "select * from tbMnu where tbMnuFlg=1 and (tbMnuTopCde is null or tbMnuTopCde='') and tbMnuCde in (select tbMnuCde from rlGrpMnu where tbGrpCde in(select tbGrpCde from rlUsrGrp where tbUsrCde=@tbUsrCde)) order by tbMnuSrt";
                IzDataSource.ParametersClear();
            }
            else
            {
                IzDataSource.SelectString = "select * from tbMnu where tbMnuFlg=1 and tbMnuTopCde=@tbMnuTopCde and tbMnuCde in (select tbMnuCde from rlGrpMnu where tbGrpCde in(select tbGrpCde from rlUsrGrp where tbUsrCde=@tbUsrCde)) order by tbMnuSrt";
                IzDataSource.ParametersClear();
                IzDataSource.ParametersAdd("tbMnuTopCde", TopCde);
            }
            IzDataSource.ParametersAdd("tbUsrCde", UsrCde);
        }

        System.Data.DataTable tb = IzDataSource.SelectDataTable();

        IzDataSource.Dispose();

        return tb;
    }

    //''' <summary>
    //''' 取單筆資料(tbMnuCde,tbMnuTopCde)
    //''' </summary>
    //''' <param name="Cde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public System.Data.DataTable MnuSelectOneCde(String Cde)
    {
        IzDataSource IzDataSource = new IzDataSource();

        IzDataSource.SelectString = "select tbMnuCde,tbMnuTopCde from tbMnu where tbMnuFlg=1 and tbMnuCde=@tbMnuCde";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("tbMnuCde", Cde);

        System.Data.DataTable tb = IzDataSource.SelectDataTable();

        IzDataSource.Dispose();

        return tb;
    }

    //''' <summary>
    //''' 取單筆資料
    //''' </summary>
    //''' <param name="Cde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public System.Data.DataTable MnuSelectOne(String Cde)
    {
        IzDataSource IzDataSource = new IzDataSource();

        IzDataSource.SelectString = "select * from tbMnu where tbMnuFlg=1 and tbMnuCde=@tbMnuCde";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("tbMnuCde", Cde);

        System.Data.DataTable tb = IzDataSource.SelectDataTable();

        IzDataSource.Dispose();

        return tb;
    }

    //''' <summary>
    //'''  取單筆群組功能資料
    //''' </summary>
    //''' <param name="GrpCde"></param>
    //''' <param name="MnuCde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public System.Data.DataTable GrpMnuSelectOne(String GrpCde, String MnuCde)
    {
        IzDataSource IzDataSource = new IzDataSource();

        IzDataSource.SelectString = "select * from rlGrpMnu where tbGrpCde=@tbGrpCde and tbMnuCde=@tbMnuCde";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("tbGrpCde", GrpCde);
        IzDataSource.ParametersAdd("tbMnuCde", MnuCde);

        System.Data.DataTable tb = IzDataSource.SelectDataTable();

        IzDataSource.Dispose();

        return tb;
    }


    //''' <summary>
    //''' 取功能名稱
    //''' </summary>
    //''' <param name="Cde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public String getMnuSub(String Cde)
    {
        String Tmp = "";
        IzDataSource IzDataSource = new IzDataSource();

        IzDataSource.SelectString = "select tbMnuSub from tbMnu where tbMnuFlg=1 and tbMnuCde=@tbMnuCde";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("tbMnuCde", Cde);

        System.Data.DataTable tb = IzDataSource.SelectDataTable();
        if (tb.Rows.Count > 0)
        {
            Tmp = "" + tb.Rows[0]["tbMnuSub"].ToString();
        }
        tb.Dispose();
        IzDataSource.Dispose();

        return Tmp;
    }

    //''' <summary>
    //''' 取群組名稱
    //''' </summary>
    //''' <param name="Cde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public String getGrpSub(String Cde)
    {
        String Tmp = "";
        IzDataSource IzDataSource = new IzDataSource();

        IzDataSource.SelectString = "select tbGrpSub from tbGrp where tbGrpFlg=1 and tbGrpCde=@tbGrpCde";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("tbGrpCde", Cde);

        System.Data.DataTable tb = IzDataSource.SelectDataTable();
        if (tb.Rows.Count > 0)
        {
            Tmp = "" + tb.Rows[0]["tbGrpSub"].ToString();
        }
        tb.Dispose();
        IzDataSource.Dispose();

        return Tmp;
    }

    //''' <summary>
    //''' 取姓名
    //''' </summary>
    //''' <param name="Cde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public String getUsrNme(String Cde){
        String Tmp = "";
        IzDataSource IzDataSource = new IzDataSource();

        IzDataSource.SelectString = "select tbUsrNme from tbUsr where tbUsrFlg=1 and tbUsrCde=@tbUsrCde";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("tbUsrCde", Cde);

        System.Data.DataTable tb = IzDataSource.SelectDataTable();
        if (tb.Rows.Count > 0){
            Tmp = "" + tb.Rows[0]["tbUsrNme"].ToString();
        }
        tb.Dispose();
        IzDataSource.Dispose();

        return Tmp;
    }

    //''' <summary>
    //''' 取單筆使用者群組資料
    //''' </summary>
    //''' <param name="UsrCde"></param>
    //''' <param name="GrpCde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public System.Data.DataTable UsrGrpSelectOne(String UsrCde, String GrpCde)
    {
        IzDataSource IzDataSource = new IzDataSource();

        IzDataSource.SelectString = "select * from rlUsrGrp where tbGrpCde=@tbGrpCde and tbUsrCde=@tbUsrCde";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("tbGrpCde", GrpCde);
        IzDataSource.ParametersAdd("tbUsrCde", UsrCde);

        System.Data.DataTable tb = IzDataSource.SelectDataTable();

        IzDataSource.Dispose();

        return tb;
    }

    //''' <summary>
    //''' 取功能權限字串
    //''' </summary>
    //''' <param name="UsrCde"></param>
    //''' <param name="MnuCde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public String GetPow(String UsrCde, String MnuCde)
    {
        String tmp = "";
        if (UsrCde == "USR00000000000000001")
        {
            tmp = "BOW01,BOW02,BOW03,ADD,EDIT,DEL";
        }
        else
        {
            IzDataSource IzDataSource = new IzDataSource();

            IzDataSource.SelectString = "select * from rlGrpMnu where tbMnuCde=@tbMnuCde and tbGrpCde in (select tbGrpCde from rlUsrGrp where tbUsrCde=@tbUsrCde)";
            IzDataSource.ParametersClear();
            IzDataSource.ParametersAdd("tbMnuCde", MnuCde);
            IzDataSource.ParametersAdd("tbUsrCde", UsrCde);

            System.Data.DataTable tb = IzDataSource.SelectDataTable();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                tmp += "" + tb.Rows[i]["tbMnuPow"].ToString().Trim() + ",";
            }
            tb.Dispose();
            IzDataSource.Dispose();
        }


        return tmp;

    }

    //''' <summary>
    //''' 檢查是否有權限
    //''' </summary>
    //''' <param name="POW"></param>
    //''' <param name="FUN"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public Boolean ChkPow(String POW, String FUN)
    {

        if (POW == "")
        { //'權限字串沒有直接回應沒權限
            return false;
        }
        if (POW.IndexOf(FUN) > -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //''' <summary>
    //''' 取每頁Title
    //''' </summary>
    //''' <param name="MnuCde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public String GenPageTitle(String MnuCde)
    {

        String DefPath = BaseUrl + AdminDefPath;
        String MnuSub = "";
        String MnuUrl = "";

        System.Data.DataTable tbMnu = MnuSelectOne(MnuCde);
        if (tbMnu.Rows.Count > 0)
        {
            MnuSub = "" + tbMnu.Rows[0]["tbMnuSub"].ToString();
            switch (tbMnu.Rows[0]["tbMnuTyp"].ToString())
            {
                case "0": //'無
                    MnuUrl = "#";
                    break;
                case "1": //'內
                    MnuUrl = DefPath + tbMnu.Rows[0]["tbMnuUrl"].ToString();
                    if (MnuUrl.IndexOf("?") < 0)
                    {
                        MnuUrl = MnuUrl + "?f=" + MnuCde;
                    }
                    else
                    {
                        MnuUrl = MnuUrl + "&f=" + MnuCde;
                    }
                    break;
                case "2":
                    MnuUrl = "" + tbMnu.Rows[0]["tbMnuUrl"].ToString();
                    break;
            }

        }
        tbMnu.Dispose();

        return "<a href=\"" + DefPath + "\">首頁</a> / " + "<a href=\"" + MnuUrl + "\">" + MnuSub + "</a>";

    }

    //''' <summary>
    //''' 檢查帳號是否已存在
    //''' </summary>
    //''' <param name="Uid"></param>
    //''' <param name="CurrentCde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    Boolean ChkUsrUidExist(String Uid, String CurrentCde)
    {
        IzDataSource IzDataSource = new IzDataSource();
        Boolean Tmp = false;
        if (CurrentCde == "")
        {
            IzDataSource.SelectString = "select tbUsrCde from tbUsr where tbUsrUid=@tbUsrUid";
            IzDataSource.ParametersAdd("tbUsrUid", Uid);
            System.Data.DataTable tb = IzDataSource.SelectDataTable();
            if (tb.Rows.Count > 0)
            {
                Tmp = true;
            }
            tb.Dispose();
        }
        else
        {
            IzDataSource.SelectString = "select tbUsrCde from tbUsr where tbUsrUid=@tbUsrUid and tbUsrCde<>@tbUsrCde";
            IzDataSource.ParametersAdd("tbUsrUid", Uid);
            IzDataSource.ParametersAdd("tbUsrCde", CurrentCde);
            System.Data.DataTable tb = IzDataSource.SelectDataTable();
            if (tb.Rows.Count > 0)
            {
                Tmp = true;
            }
            tb.Dispose();
        }

        IzDataSource.Dispose();
        return Tmp;
    }





}