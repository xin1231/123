<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdmUpd.aspx.cs" Inherits="HeyOrder.AdmUpd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="Z9rYrnh.ico" type="image/x-icon" />
    <title>管理員資料管理</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" integrity="sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div>
            <h1>更新管理員資料</h1>
            <p>
                <asp:Label ID="Label4" runat="server" Text="管理員編號"></asp:Label>
                &nbsp;:
            <asp:TextBox ID="txttbAdmNO" runat="server"></asp:TextBox>
            </p>
        </div>
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
</asp:Content>
