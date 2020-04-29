<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MeList.aspx.cs" Inherits="HeyOrder.MeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="Z9rYrnh.ico" type="image/x-icon" />
    <title>餐點資料管理</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" integrity="sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                 <div>
                     <div>
                         <h1>餐點資料管理</h1>
                     </div>
                     <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增資料" />
                     &nbsp;&nbsp;
        <asp:TextBox ID="txtQry" runat="server" Style="margin-bottom: 0px"></asp:TextBox>
                     &nbsp;&nbsp;
        <asp:Button ID="btnQry" runat="server" OnClick="btnQry_Click" Text="查詢" />
                     <br />
                     <br />
                     <asp:Label ID="Label1" runat="server" Text="預設資料數"></asp:Label>
                     &nbsp;:
        <asp:TextBox ID="txtNum" runat="server" Width="42px">20</asp:TextBox>
                     <br />
                     <br />
                     <div style="overflow: scroll; height: 60%;">

                         <asp:Repeater ID="Repeater1" runat="server">
                             <HeaderTemplate>
                                 <table border="1">
                                     <tr>
                                         <th>所屬店家代碼</th>
                                         <th>餐點編號</th>
                                         <th>餐點名稱</th>
                                         <th>餐點圖片</th>
                                         <th>餐點大類別</th>
                                         <th>餐點小類別</th>
                                         <th>餐點份量</th>
                                         <th>餐點數量</th>
                                         <th>餐點備註</th>
                                         <th>修改</th>
                                         <th>刪除</th>
                                     </tr>
                             </HeaderTemplate>
                             <ItemTemplate>
                                 <tr>
                                     <td><%#Eval("所屬店家代碼")%></td>
                                     <td><%#Eval("餐點編號")%></td>
                                     <td><%#Eval("餐點名稱")%></td>
                                     <td><%#Eval("餐點圖片")%></td>
                                     <td><%#Eval("餐點大類別")%></td>
                                     <td><%#Eval("餐點小類別")%></td>
                                     <td><%#Eval("餐點份量")%></td>
                                     <td><%#Eval("餐點數量")%></td>
                                     <td><%#Eval("餐點備註")%></td>
                                     <td>
                                         <asp:LinkButton ID="lnkB_Upd" runat="server" PostBackUrl='<%# Eval("餐點編號", "MeUpd.aspx?key={0}") %>'>修改</asp:LinkButton>
                                     </td>
                                     <td>
                                         <asp:HyperLink ID="hyl_Del" runat="server" NavigateUrl='<%# Eval("餐點編號", "MeDel.aspx?key={0}") %>'>刪除</asp:HyperLink>
                                     </td>
                                 </tr>

                             </ItemTemplate>
                             <FooterTemplate>
                                 </table>
                             </FooterTemplate>
                         </asp:Repeater>
                     </div>
                     <br />
                     <asp:Label ID="lbRecords" runat="server" Text="查詢的資料筆數"></asp:Label>
                     &nbsp;<asp:CheckBox ID="cbDelAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbDelAll_CheckedChanged" Text="全選刪除" />
                     &nbsp;<asp:Button ID="btnDelAll" runat="server" BackColor="#FF9966" OnClick="btnDelAll_Click" OnClientClick="return confirm('確定要刪除 &quot; + rowsCount + &quot;筆資料?')" Text="刪除全部xx筆資料" Visible="False" />
                     <br />
                     &nbsp;<br />
                     <asp:Button ID="btnhome" runat="server" OnClick="btnhome_Click" Text="回首頁" />
                 </div>
</asp:Content>