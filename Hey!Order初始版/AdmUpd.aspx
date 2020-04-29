<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdmUpd.aspx.cs" Inherits="HeyOrder.AdmUpd" %>

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
            <h1>更新管理員資料</h1>
            <p>
            <asp:Label ID="Label4" runat="server" Text="管理員編號"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbAdmNO" runat="server"></asp:TextBox>
            </p></div>
        <p />
            <asp:Label ID="Label1" runat="server" Text="管理員帳號"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbAdmUid" runat="server"></asp:TextBox>
        <p />
            <asp:Label ID="Label2" runat="server" Text="管理員密碼"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbAdmPwd" runat="server"></asp:TextBox>
        
        <p />
            <asp:Label ID="Label5" runat="server" Text="備註"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbAdmNot" runat="server"></asp:TextBox>
        
        <p />

        <asp:Button ID="btncel" runat="server" OnClick="btncel_Click" Text="取消" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="確定更新" />
        </div>
    </form>
</body>
</html>
