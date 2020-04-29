using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// cfg 的摘要描述
/// </summary>
public class cfg
{
    public cfg()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //

    }


    public string getcde(string preCDE)
    {
    //自動建立唯一代碼
        return preCDE + DateTime.Now.ToString("yyMMddHHmmssfffff");

    }


    public string getAppSetting(string NameT)
    {
        // web.Config AppSetting
        string Tmp = System.Configuration.ConfigurationManager.AppSettings[NameT].ToString();
        return Tmp;
    }

    public String[] FlgNmeArr = { "否", "是" };
    public String[] FlgValArr = { "0", "1" };
    public String getFlgNme(String Val)
    {
        return getTmpNme(Val, FlgNmeArr, FlgValArr);
    }

    public String[] SexNmeArr = { "不明", "男", "女" };
    public String[] SexValArr = { "0", "1", "2" };
    public String getSexNme(String Val)
    {
        return getTmpNme(Val, SexNmeArr, SexValArr);
    }


    //''' <summary>
    //''' 審核狀態預設值
    //''' </summary>
    //''' <remarks></remarks>
    public String[] StuNmeArr = { "尚未", "通過", "不通過" };
    //''' <summary>
    //''' 審核狀態預設值
    //''' </summary>
    //''' <remarks></remarks>
    public String[] StuValArr = { "0", "1", "2" };
    //''' <summary>
    //''' 顏色
    //''' </summary>
    //''' <remarks></remarks>
    public String[] StuColorArr = { "red", "blue", "green" };

    //''' <summary>
    //''' '取審核狀態名稱
    //''' </summary>
    //''' <param name="flg"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public string getStuNme(String flg)
    {
        return getTmpNme(flg, StuNmeArr, StuValArr);
    }

    public string getStuNmeColor(string flg)
    {
        flg = "" + flg;
        string tmp = "";

        for (int i = 0; i < StuValArr.Length; i++)
        {
            if (StuValArr[i] == flg)
            {
                tmp = "<font color=\"" + StuColorArr[i] + "\">" + StuNmeArr[i] + "</font>";
            }
        }

        return tmp;
    }

    //''' <summary>
    //''' 取排序最新一碼
    //''' </summary>
    //''' <param name="TableNme">Table 名稱</param>
    //''' <param name="SrtNme">排序欄位名稱</param>
    //''' <param name="Typ">A:全欄位,B:前幾碼,"":不選</param>
    //''' <param name="TypFdNme">篩選欄位</param>
    //''' <param name="TypFdVal">篩選資料</param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public Int32 getNextSrt(string TableNme, string SrtNme, string Typ = "", string TypFdNme = "", string TypFdVal = "")
    {
        int Tmp = 1;
        IzDataSource IzDataSource = new IzDataSource();
        if (Typ == "A")
        { //'全欄位
            IzDataSource.SelectString = "select top 1 " + SrtNme + " from " + TableNme + " where " + TypFdNme + "='" + TypFdVal + "' order by " + SrtNme + " desc";
        }
        else if (Typ == "B")
        { //'前幾碼
            int Num = TypFdVal.Length;
            IzDataSource.SelectString = "select top 1 " + SrtNme + " from " + TableNme + " where left(" + TypFdNme + "," + Num + ")='" + TypFdVal + "' order by " + SrtNme + " desc";
        }
        else
        {
            IzDataSource.SelectString = "select top 1 " + SrtNme + " from " + TableNme + " order by " + SrtNme + " desc";
        }

        System.Data.DataTable tb = IzDataSource.SelectDataTable();
        if (tb.Rows.Count > 0)
        {
            Tmp = Convert.ToInt32(tb.Rows[0][0]) + 10;
        }
        tb.Dispose();
        IzDataSource.Dispose();

        return Tmp;

    }




    // 取對照值
    public String getTmpNme(String flg, String[] Tnme, String[] Tval)
    {
        String[] flgS = flg.Split(new char[] { ',' });
        String tmp = "";
        for (int i = 0; i < flgS.Length; i++)
        {
            int indexA = Array.IndexOf(Tval, flgS[i]);
            if (indexA > -1)
            {
                if (tmp == "")
                {
                    tmp = Tnme[indexA];
                }
                else
                {
                    tmp += "," + Tnme[indexA];
                }
            }
        }
        return tmp;
    }


    //'''類別處理函數##############################################################

    //''' <summary>
    //''' 取類別清單
    //''' </summary>
    //''' <param name="TopCdeS">類別編號前三碼</param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public System.Data.DataTable getTypLst(String TopCdeS)
    {
        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.SelectString = "select * from tbTyp where tbTypFlg=1 and left(tbTypCde,3)=@TopCdeS order by tbTypSrt";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("TopCdeS", TopCdeS);
        System.Data.DataTable tb = IzDataSource.SelectDataTable();
        IzDataSource.Dispose();
        return tb;
    }

    public System.Data.DataTable getTypLstA(String TopCdeS)
    {
        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.SelectString = "select * from tbTyp where left(tbTypCde,3)=@TopCdeS order by tbTypSrt";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("TopCdeS", TopCdeS);
        System.Data.DataTable tb = IzDataSource.SelectDataTable();
        IzDataSource.Dispose();
        return tb;
    }

    //''' <summary>
    //''' 取備註非空值清單
    //''' </summary>
    //''' <param name="TopCdeS"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public System.Data.DataTable getTypLstByHasNot(String TopCdeS)
    {
        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.SelectString = "select * from tbTyp where left(tbTypCde,3)=@TopCdeS  and not(tbTypNot is null) and  not(tbTypNot like '')  order by tbTypSrt";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("TopCdeS", TopCdeS);
        System.Data.DataTable tb = IzDataSource.SelectDataTable();
        IzDataSource.Dispose();
        return tb;
    }

    //''' <summary>
    //''' 依Tid取得Typ單一欄位資料
    //''' </summary>
    //''' <param name="TopCdeS">前三碼</param>
    //''' <param name="TypTid">TID</param>
    //''' <param name="BackFieldNme">傳回的欄位值</param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public String getTypFeldByTid(String TopCdeS, String TypTid, String BackFieldNme)
    {
        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.SelectString = "select * from tbTyp where tbTypFlg=1 and left(tbTypCde,3)=@TopCdeS and tbTypTid=@tbTypTid";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("TopCdeS", TopCdeS);
        IzDataSource.ParametersAdd("tbTypTid", TypTid);
        System.Data.DataTable tb = IzDataSource.SelectDataTable();
        String StrTmp = "";
        if (tb.Rows.Count > 0)
        {
            StrTmp = tb.Rows[0][BackFieldNme].ToString();
        }
        tb.Dispose();
        IzDataSource.Dispose();
        return StrTmp;
    }


    //''' <summary>
    //''' 取得指定類別的類別名稱組(以逗號分開)
    //''' </summary>
    //''' <param name="TopCdeS">TYP(前置三碼)</param>
    //''' <param name="TypTidStr">T001,T002,T003(可複選)</param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public String getTypSub(String TopCdeS, String TypTidStr)
    {
        IZCls.WebFormBase WebFormBase = new IZCls.WebFormBase();
        IZCls.DataAccess DataAccess = new IZCls.DataAccess();
        TypTidStr = DataAccess.ClsSqlChr(TypTidStr);
        String TypTidSql = WebFormBase.DotToSqlStr(TypTidStr);

        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.SelectString = "select tbTypSub from tbTyp where tbTypFlg=1 and left(tbTypCde,3)=@TopCdeS and tbTypTid in (" + TypTidSql + ")";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("TopCdeS", TopCdeS);
        System.Data.DataTable tb = IzDataSource.SelectDataTable();
        String StrTmp = "";
        for (int i = 0; i < tb.Rows.Count; i++)
        {
            if (StrTmp == "")
            {
                StrTmp = tb.Rows[i]["tbTypSub"].ToString();
            }
            else
            {
                StrTmp += "," + tb.Rows[i]["tbTypSub"].ToString();
            }
        }
        tb.Dispose();
        IzDataSource.Dispose();
        return StrTmp;
    }

    //''' <summary>
    //'''  取得指定類別的類別名稱組(以逗號分開)忽略啟用
    //''' </summary>
    //''' <param name="TopCdeS">TYP(前置三碼)</param>
    //''' <param name="TypTidStr">T001,T002,T003(可複選)</param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public String getTypSubA(String TopCdeS, String TypTidStr)
    {
        IZCls.WebFormBase WebFormBase = new IZCls.WebFormBase();
        IZCls.DataAccess DataAccess = new IZCls.DataAccess();
        TypTidStr = DataAccess.ClsSqlChr(TypTidStr);
        String TypTidSql = WebFormBase.DotToSqlStr(TypTidStr);


        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.SelectString = "select tbTypSub from tbTyp where left(tbTypCde,3)=@TopCdeS and tbTypTid in (" + TypTidSql + ")";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("TopCdeS", TopCdeS);
        System.Data.DataTable tb = IzDataSource.SelectDataTable();
        String StrTmp = "";
        for (int i = 0; i < tb.Rows.Count; i++)
        {
            if (StrTmp == "")
            {
                StrTmp = tb.Rows[i]["tbTypSub"].ToString();
            }
            else
            {
                StrTmp += "," + tb.Rows[i]["tbTypSub"].ToString();
            }
        }
        tb.Dispose();
        IzDataSource.Dispose();
        return StrTmp;

    }

    //''' <summary>
    //''' 取上層類別名稱
    //''' </summary>
    //''' <param name="TopCde"></param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public String getTypTopNme(String TopCde)
    {
        String StrTmp = "";
        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.SelectString = "select tbTypTopSub from tbTypTop where tbTypTopFlg=1 and tbTypTopCde=@tbTypTopCde ";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("tbTypTopCde", TopCde);
        System.Data.DataTable tb = IzDataSource.SelectDataTable();
        if (tb.Rows.Count > 0)
        {
            StrTmp = tb.Rows[0]["tbTypTopSub"].ToString();
        }
        tb.Dispose();
        IzDataSource.Dispose();
        return StrTmp;
    }

    //''' <summary>
    //''' 產生下一位數類別編號
    //''' </summary>
    //''' <param name="Tid">前三碼</param>
    //''' <param name="TidNum">數字位數</param>
    //''' <returns></returns>
    //''' <remarks></remarks>
    public String getTypNexTid(String Tid, int TidNum)
    {
        IZCls.StringAccess StringAccess = new IZCls.StringAccess();
        String StrTmp = "";
        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.SelectString = "select top 1 tbTypTid from tbTyp where left(tbTypTid," + Tid.Length + ")=@tbTypTopCde order by tbTypTid desc";
        IzDataSource.ParametersClear();
        IzDataSource.ParametersAdd("tbTypTopCde", Tid);
        System.Data.DataTable tb = IzDataSource.SelectDataTable();
        if (tb.Rows.Count > 0)
        {
            //String TidTNum  =  Right("" & tb.Rows(0).Item("tbTypTid"), Len("" & tb.Rows(0).Item("tbTypTid")) - Len(Tid));
            String TidTNum = tb.Rows[0]["tbTypTid"].ToString().Substring(tb.Rows[0]["tbTypTid"].ToString().IndexOf(Tid) + Tid.Length);
            if (StringAccess.IsNum(TidTNum) == true)
            {
                StrTmp = Tid + StringAccess.addZeroBfStr(Convert.ToInt32(TidTNum) + 1, TidNum);
            }
            else
            {
                StrTmp = Tid + StringAccess.addZeroBfStr(1, TidNum);
            }
        }
        else
        {
            StrTmp = Tid + StringAccess.addZeroBfStr(1, TidNum);
        }
        tb.Dispose();
        IzDataSource.Dispose();
        return StrTmp;
    }


    // '############################################################################



    /// <summary>
    /// 取圖片
    /// </summary>
    /// <param name="GrpCde"></param>
    /// <returns></returns>
    public System.Data.DataTable selectFlePicByGrp(String GrpCde)
    {

        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.SelectString = "select tbFleCde,tbGrpCde,tbFleSub,tbFleCon,tbFleNot,tbFleNme,tbFleTpf,tbFleSiz,tbFleExt,tbFleUtp,tbFlePath,tbFleClk,tbFleFlg,tbFleCdt,tbFleMdt,tbFleCid,tbFleMid,tbFleCip,tbFleMip from tbFle where tbFleFlg=1 and tbGrpCde=@tbGrpCde and (tbFleExt='png' or tbFleExt='jpg' or tbFleExt='gif') order by tbFleCdt";
        IzDataSource.ParametersAdd("tbGrpCde", GrpCde);

        System.Data.DataTable tb = IzDataSource.SelectDataTable();

        tb.Dispose();
        IzDataSource.Dispose();

        return tb;

    }

    /// <summary>
    /// 取置頂圖片
    /// </summary>
    /// <param name="GrpCde"></param>
    /// <param name="isTop"></param>
    /// <returns></returns>
    public System.Data.DataTable selectFlePicByGrp(String GrpCde,Boolean isTop)
    {

        IzDataSource IzDataSource = new IzDataSource();
        IzDataSource.SelectString = "select tbFleCde,tbGrpCde,tbFleSub,tbFleCon,tbFleNot,tbFleNme,tbFleTpf,tbFleSiz,tbFleExt,tbFleUtp,tbFlePath,tbFleClk,tbFleFlg,tbFleCdt,tbFleMdt,tbFleCid,tbFleMid,tbFleCip,tbFleMip from tbFle where tbFleFlg=1 and tbFleTop=1 and tbGrpCde=@tbGrpCde and (tbFleExt='png' or tbFleExt='jpg' or tbFleExt='jpeg' or tbFleExt='gif') order by tbFleCdt";
        IzDataSource.ParametersAdd("tbGrpCde", GrpCde);

        System.Data.DataTable tb = IzDataSource.SelectDataTable();

        tb.Dispose();
        IzDataSource.Dispose();

        return tb;

    }

}