<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MeAdd.aspx.cs" Inherits="HeyOrder.MeAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="Z9rYrnh.ico" type="image/x-icon"/>
    <title>餐點資料管理</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" integrity="sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
</asp:Content>
