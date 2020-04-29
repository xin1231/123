﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeList.aspx.cs" Inherits="HeyOrder.DeList" %>

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
                <h1>明細資料管理</h1>
            </div>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增資料" />
            &nbsp;&nbsp;
        <asp:TextBox ID="txtQry" runat="server" Style="margin-bottom: 0px"></asp:TextBox>
            &nbsp;&nbsp;
        <asp:Button ID="btnQry" runat="server" OnClick="btnQry_Click" Text="查詢" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="預設資料數"></asp:Label>
            &nbsp;:
        <asp:TextBox ID="txtNum" runat="server" Width="33px">20</asp:TextBox>
            <br />
            <br />
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table border="1">
                        <tr>
                            <th>訂單編號</th>
                            <th>店家名稱</th>
                            <th>餐點名稱</th>
                            <th>訂購數量</th>
                            <th>優惠碼</th>
                            <th>備註</th>
                            <th>訂單金額</th>
                            <th>付款方式</th>
                            <th>修改</th>
                            <th>刪除</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("訂單編號")%></td>
                        <td><%#Eval("店家名稱")%></td>
                        <td><%#Eval("餐點名稱")%></td>
                        <td><%#Eval("訂購數量")%></td>
                        <td><%#Eval("優惠碼")%></td>
                        <td><%#Eval("備註")%></td>
                        <td><%#Eval("訂單金額")%></td>
                        <td><%#Eval("付款方式")%></td>
                        <td>
                            <asp:LinkButton ID="lnkB_Upd" runat="server" PostBackUrl='<%# Eval("訂單編號", "DeUpd.aspx?key={0}") %>'>修改</asp:LinkButton>
                        </td>
                        <td>
                            <asp:HyperLink ID="hyl_Del" runat="server" NavigateUrl='<%# Eval("訂單編號", "DeDel.aspx?key={0}") %>'>刪除</asp:HyperLink>
                        </td>
                    </tr>

                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
            <asp:Label ID="lbRecords" runat="server" Text="查詢的資料筆數"></asp:Label>
            &nbsp;<asp:CheckBox ID="cbDelAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbDelAll_CheckedChanged" Text="全選刪除" />
            &nbsp;<asp:Button ID="btnDelAll" runat="server" BackColor="#FF9966" OnClick="btnDelAll_Click" OnClientClick="return confirm('確定要刪除 &quot; + rowsCount + &quot;筆資料?')" Text="刪除全部xx筆資料" Visible="False" />
            <br />
            &nbsp;<br />
            <asp:Button ID="btnhome" runat="server" OnClick="btnhome_Click" Text="回首頁" />
        </div>
    </form>
</body>
</html>
