<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="HeyOrder.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" Height="181px" Width="221px" 
                        BorderColor="#000001" />
<div id="newPreview"></div>
 
<asp:FileUpload ID="FileUpload1" runat="server" οnchange="previewPic()" />
            <br />
            <br />
            <br />
        </div>
        <asp:Image ID="Image2" runat="server" Height="209px" Width="300px" />
        <asp:FileUpload ID="FileUpload2" runat="server" onchange="previewPic()" />
        <br />
        <br />
        <br />
        <br />
        <div id="localImag">
<img id="preview" src="" width="150" height="180" style="display: block; width: 150px; height: 180px;">
</div>
<asp:FileUpload ID="fileImg" runat="server" CssClass="fileImg" onchange="javascript:setImagePreview();" />
    </form>
</body>
</html>
