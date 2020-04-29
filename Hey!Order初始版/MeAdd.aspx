<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeAdd.aspx.cs" Inherits="HeyOrder.MeAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h1>新增餐點資料</h1>
                <p>
                    <asp:Label ID="Label6" runat="server" Text="所屬店家代碼"></asp:Label>
                    &nbsp;:
            <asp:TextBox ID="txttbShNO" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label7" runat="server" Text="餐點編號"></asp:Label>
                    &nbsp;:
            <asp:TextBox ID="txttbMeNO" runat="server"></asp:TextBox>
                </p>
            </div>
            <p />
            <asp:Label ID="Label1" runat="server" Text="餐點名稱"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMeNam" runat="server"></asp:TextBox>
            <p />
            <asp:Label ID="Label8" runat="server" Text="餐點圖片"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMePic" runat="server"></asp:TextBox>
            <p />
            <asp:Label ID="Label2" runat="server" Text="餐點大類別"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMeCate" runat="server"></asp:TextBox>
            <p />
            <asp:Label ID="Label9" runat="server" Text="餐點小類別"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMeTpe" runat="server"></asp:TextBox>
            <p />
            <asp:Label ID="Label3" runat="server" Text="餐點份量"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMeSiz" runat="server"></asp:TextBox>

            <p />
            <asp:Label ID="Label4" runat="server" Text="餐點數量"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMeNum" runat="server"></asp:TextBox>

            <p />
            <asp:Label ID="Label5" runat="server" Text="餐點備註"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMeNot" runat="server"></asp:TextBox>

            <p />

            <asp:Button ID="btncel" runat="server" OnClick="btncel_Click" Text="取消" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="確定新增" />
        </div>
    </form>
</body>
</html>
