<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HeyOrder.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h1>Hey!Order</h1>
        </div>
        <asp:TreeView ID="TreeView1" runat="server" ImageSet="Simple" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" Height="113px" Width="119px">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <Nodes>
                <asp:TreeNode Text="Hey!Order" Value="Hey!Order">
                    <asp:TreeNode Text="店家" Value="店家" NavigateUrl="~/ShopList.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="會員" Value="會員" NavigateUrl="~/MbrList.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="餐點" Value="餐點" NavigateUrl="~/MeList.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="訂單" Value="訂單" NavigateUrl="~/OrList.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="管理員" Value="管理員" NavigateUrl="~/AdmList.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="明細" Value="明細" NavigateUrl="~/DeList.aspx"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
    </form>
</body>
</html>
