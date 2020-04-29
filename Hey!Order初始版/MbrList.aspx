﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MbrList.aspx.cs" Inherits="HeyOrder.MbrList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>會員資料管理</h1>
        </div>
        <br />
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增資料" />
&nbsp;&nbsp;
        <asp:TextBox ID="txtQry" runat="server" style="margin-bottom: 0px"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="btnQry" runat="server" OnClick="btnQry_Click" Text="查詢" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="預設資料數"></asp:Label>
&nbsp;:
        <asp:TextBox ID="txtNum" runat="server" Width="42px">20</asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbRecord" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Repeater ID="Repeater1" runat="server" >
        <HeaderTemplate>
<table border="1">
<tr>
<th>自動編號</th>
<th>會員編號</th>
<th>會員姓名</th>
<th>會員帳號</th>
<th>會員密碼</th>
<th>電話</th>
<th>是否驗證</th>
<th>信箱</th>
<th>是否驗證</th>
<th>備註</th>
<th>修改</th>
<th>刪除</th>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td><%#Eval("自動編號")%></td>
<td><%#Eval("會員編號")%></td>
<td><%#Eval("會員姓名")%></td>
<td><%#Eval("會員帳號")%></td>
<td><%#Eval("會員密碼")%></td>
<td><%#Eval("電話")%></td>
<td><%#Eval("是否驗證")%></td>
<td><%#Eval("信箱")%></td>
<td><%#Eval("是否驗證")%></td>
<td><%#Eval("備註")%></td>
<td>
    <asp:LinkButton ID="lnkB_Upd" runat="server" PostBackUrl='<%# Eval("會員編號", "MbrUpd.aspx?key={0}") %>'>修改</asp:LinkButton>
</td>
<td>
    <asp:HyperLink ID="hyl_Del" runat="server" NavigateUrl='<%# Eval("會員編號", "MbrDel.aspx?key={0}") %>'>刪除</asp:HyperLink>
</td>
</tr>

</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
        </asp:Repeater>
        <p>
            <asp:Label ID="lbRecords" runat="server" Text="查詢的資料筆數"></asp:Label>
            &nbsp;<asp:CheckBox ID="cbDelAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbDelAll_CheckedChanged" Text="全選刪除" />
            &nbsp;<asp:Button ID="btnDelAll" runat="server" BackColor="#FF9966" OnClick="btnDelAll_Click" OnClientClick="return confirm('確定要刪除 &quot; + rowsCount + &quot;筆資料?')" Text="刪除全部xx筆資料" Visible="False" />
        </p>
        <p>
            <asp:Button ID="btnhome" runat="server" OnClick="btnhome_Click" Text="回首頁" />
        </p>
    </form>
</body>
</html>
