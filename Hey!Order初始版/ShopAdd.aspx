﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopAdd.aspx.cs" Inherits="HeyOrder.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>新增店家資料</h1>
            <p>
            <asp:Label ID="Label4" runat="server" Text="店家編號"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbShNO" runat="server"></asp:TextBox>
            </p></div>
        <p />
            <asp:Label ID="Label1" runat="server" Text="店家名稱"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbShNam" runat="server"></asp:TextBox>
        <p />
            <asp:Label ID="Label2" runat="server" Text="聯絡電話"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbShTel" runat="server"></asp:TextBox>
        <p />
            <asp:Label ID="Label6" runat="server" Text="店家圖片"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbShPic" runat="server"></asp:TextBox>
        <p />
        <asp:Label ID="Label3" runat="server" Text="營業時間"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbShTim" runat="server"></asp:TextBox>

        <p />
            <asp:Label ID="Label5" runat="server" Text="店家簡介"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbShNot" runat="server"></asp:TextBox>
        
        <p />

        <asp:Button ID="btncel" runat="server" OnClick="btncel_Click" Text="取消" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="確定新增" />
    </form>
</body>
</html>
