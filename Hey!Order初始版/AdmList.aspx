<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdmList.aspx.cs" Inherits="HeyOrder.AdmList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
            </div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table border="1">
                        <table border="1">
                            <tr>
                                <th>管理員編號</th>
                                <th>管理員帳號</th>
                                <th>管理員密碼</th>
                                <th>備註</th>
                                <th>修改</th>
                                <th>刪除</th>
                            </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("管理員編號")%></td>
                        <td><%#Eval("管理員帳號")%></td>
                        <td><%#Eval("管理員密碼")%></td>
                        <td><%#Eval("備註")%></td>
                        <td>
                            <asp:LinkButton ID="lnkB_Upd" runat="server" PostBackUrl='<%# Eval("管理員編號", "AdmUpd.aspx?key={0}") %>'>修改</asp:LinkButton>

                        </td>
                        <td>
                            <asp:HyperLink ID="hyl_Del" runat="server" NavigateUrl='<%# Eval("管理員編號", "AdmDel.aspx?key={0}") %>'>刪除</asp:HyperLink>
                        </td>
                    </tr>

                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label ID="lbRecords" runat="server" Text="查詢的資料筆數"></asp:Label>
            &nbsp;<asp:CheckBox ID="cbDelAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbDelAll_CheckedChanged" Text="全選刪除" />
            &nbsp;<asp:Button ID="btnDelAll" runat="server" BackColor="#FF9966" OnClick="btnDelAll_Click" OnClientClick="return confirm('確定要刪除 &quot; + rowsCount + &quot;筆資料?')" Text="刪除全部xx筆資料" Visible="False" />
            <br />
            &nbsp;<br />
            <asp:Button ID="btnhome" runat="server" OnClick="btnhome_Click" Text="回首頁" />
        </div>
    </form>
</body>
</body>
</html>
