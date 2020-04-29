<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>黃老師的網頁資料庫範例</h1>
        </div>
        <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <Nodes>
                <asp:TreeNode Text="我的專案" Value="我的專案" NavigateUrl="~/">
                    <asp:TreeNode Text="部門基本資料維護" Value="部門基本資料維護" NavigateUrl="~/DepartLst.aspx"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="~/departLstR.aspx" Text="部門維護使用Repeater" Value="部門維護使用Repeater"></asp:TreeNode>
                    <asp:TreeNode Text="會員基本資料維護" Value="會員基本資料維護"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
    </form>
</body>
</html>
