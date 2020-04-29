<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MbrDel.aspx.cs" Inherits="HeyOrder.MbrDel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="Z9rYrnh.ico" type="image/x-icon" />
    <title>會員資料管理</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" integrity="sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <h1>刪除會員資料</h1>
        </div>
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
            </p>
        </div>
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
        <asp:Label ID="Label16" runat="server" Text="電話"></asp:Label>
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
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="確定刪除" />
    </p>
</asp:Content>
