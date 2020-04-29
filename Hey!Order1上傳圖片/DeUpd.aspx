<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DeUpd.aspx.cs" Inherits="HeyOrder.DeUpd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="Z9rYrnh.ico" type="image/x-icon" />
    <title>明細資料管理</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" integrity="sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <div>
                <h1>更新明細資料</h1>
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
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="確定更新" />
        </div>
</asp:Content>