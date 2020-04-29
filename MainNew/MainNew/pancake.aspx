<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pancake.aspx.cs" Inherits="MainNew.pancake" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        *, ::after, ::before {
            text-shadow: none !important;
            box-shadow: none !important
        }

        *, ::after, ::before {
            box-sizing: border-box
        }

        a {
            color: #007bff;
            text-decoration: none;
            background-color: transparent
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    &nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Black">鬆餅區</asp:LinkButton>
&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Black">瓦芙區</asp:LinkButton>
&nbsp;
    <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="Black">飲料區</asp:LinkButton>
            <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
            <asp:Panel ID="Panel1" runat="server">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/pancake1.jfif" Height="225px" Width="225px" />
                <asp:LinkButton ID="LB1" runat="server" ForeColor="Black">巧克力鬆餅</asp:LinkButton>
                <br />
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/pancake2.jfif" Height="225px" Width="225px" />
                <asp:LinkButton ID="LB2" runat="server" ForeColor="Black">草莓鬆餅</asp:LinkButton>
                <br />
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/pancake3.jfif" Height="225px" Width="225px" />
                <asp:LinkButton ID="LB3" runat="server" ForeColor="Black">抹茶奶霜鬆餅</asp:LinkButton>
                <br />
                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/pancake4.jfif" Height="225px" Width="225px" />
                <asp:LinkButton ID="LB4" runat="server" ForeColor="Black">蜜糖鬆餅</asp:LinkButton>
        </asp:Panel>

    </form>

</body>
</html>
