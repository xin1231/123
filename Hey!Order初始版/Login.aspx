<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HeyOrder.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <div class="login-panel panel panel-default">
                <div class="panel-heading" style="text-align:center;">
                    <h2>
                        <asp:Literal ID="lbTitle" runat="server"></asp:Literal>
                    </h2>
                    <h3 style="orphans: 3; widows: 3; page-break-after: avoid; font-family: inherit; font-weight: 500; line-height: 1.1; color: inherit; font-size: 24px; margin-top: 20px; margin-bottom: 10px;">
                        <asp:Literal ID="lbSubTitle" runat="server"></asp:Literal>
                    </h3>
                </div>
                <div class="panel-body">
                    <fieldset>
                        <div class="form-group">
                            <asp:TextBox ID="txtUID" runat="server" CssClass="form-control" MaxLength="20" placeholder="請輸入帳號" ToolTip="帳號"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtPWD" runat="server" CssClass="form-control" MaxLength="20" placeholder="請輸入密碼" TextMode="Password" ToolTip="密碼"></asp:TextBox>
                        </div>
                        <asp:Button ID="bntSend" runat="server" CssClass="btn btn-lg btn-success btn-block" OnClick="bntSend_Click" Text="確定" />
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
