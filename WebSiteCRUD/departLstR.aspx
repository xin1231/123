<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="departLstR.aspx.cs" Inherits="WebForm1.departLstR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <asp:Literal ID="ltTitle" runat="server" Text="部門資料維護作業"></asp:Literal>
        </div>
        <asp:Button ID="btnAdd" runat="server" Text="新增資料" OnClick="btnAdd_Click" />
        &nbsp;
        <asp:TextBox ID="txtQry" runat="server"></asp:TextBox>
        <asp:Button ID="btnQry" runat="server" Text="查詢" OnClick="btnQry_Click" />
        &nbsp; 
        <br />
        預設資料數:<asp:TextBox ID="txtNum" runat="server" Width="28px">20</asp:TextBox>
        <br />
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <th>部門編號</th>
                        <th>名稱</th>
                        <th>備註</th>
                        <th>修改</th>
                        <th>刪除</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("部門號")%></td>
                    <td><%#Eval("名稱")%></td>
                    <td><%#Eval("備註")%></td>
                    <td>
                        <asp:LinkButton ID="lnkB_Upt" runat="server" PostBackUrl='<%# Eval("部門號", "departUpt.aspx?key={0}") %>'>修改</asp:LinkButton>

                    </td>
                    <td>
                        <asp:HyperLink ID="hyl_Del" runat="server" NavigateUrl='<%# Eval("部門號", "departDel.aspx?key={0}") %>'>刪除</asp:HyperLink>
                    </td>
                </tr>

            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lbRecords" runat="server" Text="查詢的資料筆數"></asp:Label>
        &nbsp;<asp:CheckBox ID="cbDelAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbDelAll_CheckedChanged" Text="全選刪除" />
        &nbsp;<asp:Button ID="btnDelAll" runat="server" OnClick="btnDelAll_Click" OnClientClick="return confirm('確定要刪除 &quot; + rowsCount + &quot;筆資料?')" Text="刪除全部xx筆資料" Visible="False" BackColor="#FF9966" />
        <br />
    </form>
</body>
</html>
