<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="WebProject.ProductPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="file">Select an image:</label>
            <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" />
            <asp:Button runat="server" Text="Upload" OnClick="uploadImage" />
        </div>
        
    </form>
</body>
</html>
