﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MbrUpd.aspx.cs" Inherits="HeyOrder.MbrUpd" %>

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
        <div>
            <h1>更新會員資料</h1></div>
        <div>
            <p>
            <asp:Label ID="Label1" runat="server" Text="自動編號"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMbrCde" runat="server"></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="Label2" runat="server" Text="會員編號"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMbrNO" runat="server"></asp:TextBox>
            </p></div>
        <p />
            <asp:Label ID="Label3" runat="server" Text="會員姓名"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMbrNam" runat="server"></asp:TextBox>
        <p />
            <asp:Label ID="Label4" runat="server" Text="會員帳號"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMbrUid" runat="server"></asp:TextBox>
        <p />
        <asp:Label ID="Label5" runat="server" Text="會員密碼"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMbrPwd" runat="server"></asp:TextBox>

        <p />
            <asp:Label ID="Label6" runat="server" Text="電話"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMbrTel" runat="server"></asp:TextBox>
            <p />
            <asp:Label ID="Label7" runat="server" Text="信箱"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMbrEM" runat="server"></asp:TextBox>
            <p />
            <asp:Label ID="Label8" runat="server" Text="備註"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMbrNot" runat="server"></asp:TextBox>
        
        </div>
        <p>

        <asp:Button ID="btncel" runat="server" OnClick="btncel_Click" Text="取消" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="確定更新" />
        </p>
        </div>
    </form>
</body>
</html>
