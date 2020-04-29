<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartLst.aspx.cs" Inherits="WebForm1.WebDepartLst" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal ID="ltTitle" runat="server" Text="部門資料維護作業"></asp:Literal>
        </div>
        <asp:Button ID="btnAdd" runat="server" Text="新增資料" OnClick="btnAdd_Click" />
&nbsp;<asp:TextBox ID="txtQry" runat="server"></asp:TextBox>
        <asp:Button ID="btnQry" runat="server" Text="查詢" OnClick="btnQry_Click" />
&nbsp; 預設資料數:<asp:TextBox ID="txtNum" runat="server" Width="28px">20</asp:TextBox>
        <br />
        <asp:Label ID="lbRecords" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:Label ID="lbRowKey" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
