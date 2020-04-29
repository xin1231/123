<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ShOrder.aspx.cs" Inherits="MainNew.ShOrder" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/pancake1.jfif" />
    </div>
        &nbsp;<br />
    <asp:Label ID="Label5" runat="server" Text="巧克力鬆餅"></asp:Label>
        &nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="價格$"></asp:Label>
    <asp:Label ID="Label7" runat="server" Text="55"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="份量選擇"></asp:Label>
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>小</asp:ListItem>
        <asp:ListItem>大</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="特殊指示"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox2" runat="server" Height="150px" Width="500px"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="-" Height="25px" Width="25px" OnClick="Button1_Click" />
        &nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="50px" ></asp:TextBox>
        &nbsp;
        <asp:Button ID="Button2" runat="server" Text="+" Height="25px" Width="25px" OnClick="Button2_Click" />
        &nbsp;
        <asp:Button ID="Button3" runat="server" BackColor="#FF6666" Text="加入購物車" Height="32px" />
</asp:Content>
