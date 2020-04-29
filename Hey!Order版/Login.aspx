<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HeyOrder.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            帳號：<asp:TextBox ID="txtUid" runat="server"></asp:TextBox>
        </div>
        <p>
            密碼：<asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
        </p>
        <div style="margin-left: 160px">
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="登入" />
        </div>
        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"></asp:Label>
    </form>
</body>
</html>
