<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errorPage.aspx.cs" Inherits="WebProject.errorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:50%; margin:auto; padding:10px; height:60%; text-align:center;">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
            <img style="width:auto; height:50vh; margin-top:10px;" src="images/website/sad.png" /><br />
            <asp:Button runat="server" Text="עבור להתחברות" OnClick="moveToSignIn" style="height: 20%" />
        </div>
    </form>
</body>
</html>
