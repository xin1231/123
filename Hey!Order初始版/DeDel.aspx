<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeDel.aspx.cs" Inherits="HeyOrder.DeDel" %>

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
                <h1>刪除明細資料</h1>
            </div>
            <div>
                <p>
                    <asp:Label ID="Label4" runat="server" Text="訂單編號"></asp:Label>
                    &nbsp;:
            <asp:TextBox ID="txttbDeNO" runat="server"></asp:TextBox>
                </p>
            </div>
            <p />
            <asp:Label ID="Label1" runat="server" Text="店家名稱"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbShNam" runat="server"></asp:TextBox>
            <p />
            <asp:Label ID="Label8" runat="server" Text="餐點名稱"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMeNam" runat="server"></asp:TextBox>
            <p />
            <asp:Label ID="Label2" runat="server" Text="訂購數量"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbDeNum" runat="server"></asp:TextBox>
            <p />
            <asp:Label ID="Label6" runat="server" Text="備註"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbDeNot" runat="server"></asp:TextBox>
            <p />
            <asp:Label ID="Label3" runat="server" Text="優惠碼"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbDeDct" runat="server"></asp:TextBox>

            <p />
            <asp:Label ID="Label9" runat="server" Text="訂單金額"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbDeSum" runat="server"></asp:TextBox>

            <p />
            <asp:Label ID="Label10" runat="server" Text="付款方式"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbDePay" runat="server"></asp:TextBox>

            <p />

            <asp:Button ID="btncel" runat="server" OnClick="btncel_Click" Text="取消" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="確定刪除" />
        </div>
    </form>
</body>
</html>
