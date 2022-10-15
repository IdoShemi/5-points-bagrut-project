<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertUser.aspx.cs" Inherits="WebProject.InsertUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="InsertName" runat="server" Text="הכנס שם משתמש"></asp:TextBox><br />
            <asp:TextBox ID="InsertPass" runat="server" Text="הכנס סיסמא"></asp:TextBox><br />
            <asp:TextBox ID="InsertPhone" runat="server" Text="הכנס מספר טלפון"></asp:TextBox><br />
            <asp:TextBox ID="InsertMail" runat="server" Text="הכנס כתובת מייל"></asp:TextBox><br />


            <div class="selectGender">
                מין:
                <asp:RadioButton ID="RadioButton1" Text="male" runat="server" GroupName="gender" />
                <asp:RadioButton ID="RadioButton2" Text="female" runat="server" GroupName="gender" />
                <br />
            </div>


            תאריך לידה:
            <asp:TextBox ID="birthDay" runat="server" Width="55px" Text="day"></asp:TextBox>
            <asp:TextBox ID="birthMonth" runat="server" Width="47px" Text="month"> </asp:TextBox>
            <asp:TextBox ID="birthYear" runat="server" Width="89px" Text="year"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="לחץ להוספה" OnClick="Insertbutton" />
        </div>
    </form>
</body>
</html>
