<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteUser.aspx.cs" Inherits="WebProject.DeleteUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" Text="מחק" OnClick="Delbutton" OnClientClick="return confirm('are you sure?')"/>
            <asp:TextBox ID="Delbox" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
