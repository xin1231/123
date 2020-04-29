<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdmList.aspx.cs" Inherits="HeyOrder.AdmList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="Z9rYrnh.ico" type="image/x-icon" />
    <title>管理員資料管理</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" integrity="sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>管理員資料管理</h1>
        <p>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增資料" />
            &nbsp;
                    <asp:TextBox ID="txtQry" runat="server"></asp:TextBox>
            <asp:Button ID="btnQry" runat="server" OnClick="btnQry_Click" Text="查詢" />
            &nbsp;
        </p>
        <p>
            預設資料數 :
                    <asp:TextBox ID="txtNum" runat="server" Width="28px">20</asp:TextBox>
        </p>
        <div>
&nbsp;<asp:HyperLink ID="lnSelAll" runat="server" BackColor="#99CCFF" ToolTip="全部選取">全部選取</asp:HyperLink>
&nbsp;<asp:HyperLink ID="lnNoSelAll" runat="server" BackColor="#99CCFF" ToolTip="取消選取">取消選取</asp:HyperLink>
&nbsp;<br />
    <asp:Label ID="lbRecords" runat="server" Text="查詢的資料筆數"></asp:Label>
    &nbsp;<asp:CheckBox ID="cbDelAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbDelAll_CheckedChanged" Text="全選刪除" />
    &nbsp;<asp:Button ID="btnDelAll" runat="server" BackColor="#FF9966" OnClick="btnDelAll_Click" OnClientClick="return confirm('確定要刪除 &quot; + rowsCount + &quot;筆資料?')" Text="刪除全部xx筆資料" Visible="False" />
        </div>
    </div>
    <div style="overflow: scroll; height: 60%;">

        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <table border="1">

                        <tr>
                            <th>管理員編號</th>
                            <th>管理員帳號</th>
                            <th>管理員密碼</th>
                            <th>備註</th>
                            <th>啟用</th>
                            <th>建檔時間</th>
                            <th>修改</th>
                            <th>刪除</th>
                            <th>瀏覽</th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("管理員編號")%></td>
                    <td><%#Eval("管理員帳號")%></td>
                    <td><%#Eval("管理員密碼")%></td>
                    <td><%#Eval("備註")%></td>
                    <td><%#Eval("啟用")%></td>
                    <td><%#Eval("建檔時間")%></td>                 
                    <td>
                        <asp:LinkButton ID="lnkB_Upd" runat="server" PostBackUrl='<%# Eval("管理員編號", "AdmUpd.aspx?key={0}") %>'>修改</asp:LinkButton>
                    </td>
                    <td>
                        <asp:HyperLink ID="hyl_Del" runat="server" NavigateUrl='<%# Eval("管理員編號", "AdmDel.aspx?key={0}") %>'>刪除</asp:HyperLink>
                    </td>
                    <td>
                        <asp:LinkButton ID="Ink_Bro" runat="server" PostBackUrl='<%# Eval("管理員編號", "AdmBro.aspx?key={0}") %>'>瀏覽</asp:LinkButton>
                    </td>
                </tr>

            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

     <table width="100%" border="0" cellspacing="0" cellpadding="0" class="page_count_table">
            <tr>
              <td height="40" width="33%"><table width="100%" border="0" cellpadding="0" cellspacing="0" >
                  <tr>
                    <td width="50%">目前頁數：<asp:DropDownList ID="lbDataPage" runat="server">
                        </asp:DropDownList>
                        /<asp:Label ID="lbDataTotPage" runat="server" Text="0"></asp:Label>
                    </td>
                    <td width="50%">總筆數：<asp:Label ID="lbDataCount" runat="server" Text="0"></asp:Label></td>
                  </tr>
              </table></td>
              <td class="page_select">
              
                           <asp:DataList ID="DataListPage" runat="server" RepeatDirection="Horizontal"  HorizontalAlign="Center" CellPadding="4" ForeColor="#333333">
                               <AlternatingItemStyle BackColor="White" />
                               <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                               <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                               <ItemStyle BackColor="#EFF3FB" />
                            <ItemTemplate>
                               <div id="PageBox" class=""><%#DataBinder.Eval(Container.DataItem,"PageName")%>  </div>
                            </ItemTemplate>
                               <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          </asp:DataList>
              
              </td>
              <td align="right" class="page_select" width="120">每頁<asp:TextBox ID="txtPageSize" runat="server" MaxLength="5" Width="50px"></asp:TextBox>
                筆 
              </td>
              <td width="90" >
              &nbsp;<asp:HyperLink ID="lnReFrash" runat="server" ToolTip="重新整理" CssClass="form-control">重新整理</asp:HyperLink>
              </td>
            </tr>
          </table>
     
                    </div>
                    <!-- /.table-responsive -->



                </div>
                <!-- /.panel-body -->
    &nbsp;<br />
    <asp:Button ID="btnhome" runat="server" OnClick="btnhome_Click" Text="回首頁" />
</asp:Content>
