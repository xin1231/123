<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ShMeun.aspx.cs" Inherits="MainNew.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;
            <h1>&nbsp;店家清單</h1>
        </div>
        <p>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Button ID="Button1" runat="server" Text="查詢店家" Height="32px" />
        </p>
        <p>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/RPqxlEM.jpg" align="center" class="container" Height="500px" ImageAlign="Middle" Width="700px" OnClick="ImageButton1_Click" />
        </p>
            <asp:LinkButton ID="LinkButton1" runat="server" Height="25px" Width="100px" OnClick="LinkButton1_Click">咕咕鬆餅屋</asp:LinkButton>
&nbsp;&nbsp; 
</asp:Content>
