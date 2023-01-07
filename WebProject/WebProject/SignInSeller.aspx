<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignInSeller.aspx.cs" Inherits="WebProject.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span class="inputText">הכנס שם משתמש:</span><asp:TextBox ID="InputUserName" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס סיסמה</span><asp:TextBox ID="InputPassWord" runat="server" Text=""></asp:TextBox><br />
            <asp:Label ID="Label1" runat="server" Text="" style="color:red;"></asp:Label><br />
            <asp:Button runat="server" Text="התחבר" OnClick="SignInFunc" style="height: 26px" />
        </div>
    </form>
</body>
</html>
