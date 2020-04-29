<%@ Page Language="C#"  MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OrUpd.aspx.cs" Inherits="HeyOrder.OrUpd" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="Z9rYrnh.ico" type="image/x-icon" />
    <title>訂單資料管理</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" integrity="sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
        <div>
            <h1>更新訂單資料</h1>
            <p>
            <asp:Label ID="Label4" runat="server" Text="訂單編號"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbOrNO" runat="server"></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="Label7" runat="server" Text="會員編號"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbMbrNO" runat="server"></asp:TextBox>
            </p></div>
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
            <asp:TextBox ID="txttbOrNum" runat="server"></asp:TextBox>
        <p />
            <asp:Label ID="Label6" runat="server" Text="備註"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbOrNot" runat="server"></asp:TextBox>
        <p />
        <asp:Label ID="Label3" runat="server" Text="優惠碼"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbOrDct" runat="server"></asp:TextBox>

            <p />
            <asp:Label ID="Label9" runat="server" Text="訂單金額"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbOrSum" runat="server"></asp:TextBox>

            <p />
            <asp:Label ID="Label10" runat="server" Text="付款方式"></asp:Label>
            &nbsp;:
            <asp:TextBox ID="txttbOrPay" runat="server"></asp:TextBox>

            <p />

        <asp:Button ID="btncel" runat="server" OnClick="btncel_Click" Text="取消" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="確定更新" />
        </div>
</asp:Content>