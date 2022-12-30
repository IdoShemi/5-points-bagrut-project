<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="WebProject.UpdateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span class="inputText">הכנס שם משתמש לעדכון:</span><asp:TextBox ID="InsertName" runat="server" Text=""></asp:TextBox>
            <asp:Button runat="server" Text="לחץ לטעינת משתמש" OnClick="UpdateValuesbutton" />


            <br /><br />


            <span class="inputText">הכנס שם פרטי:</span><asp:TextBox ID="InsertFirstName" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס שם משפחה:</span><asp:TextBox ID="InsertLastName" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס סיסמא:</span><asp:TextBox ID="InsertPass" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס מספר טלפון:</span><asp:TextBox ID="InsertPhone" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס כתובת מייל:</span><asp:TextBox ID="InsertMail" runat="server" Text=""></asp:TextBox><br />

            <span class="inputText">הכנס עיר מגורים:</span><asp:TextBox ID="InsertCity" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס כתובת מגורים:</span><asp:TextBox ID="InsertAddress" runat="server" Text=""></asp:TextBox><br />

            <div class="selectGender">
                <span class="inputText">מין:</span>
                <asp:RadioButton ID="RadioButton1" Text="male" runat="server" GroupName="gender" />
                <asp:RadioButton ID="RadioButton2" Text="female" runat="server" GroupName="gender" />
                <br />
            </div>


            <span class="inputText">תאריך לידה:</span>
            <asp:DropDownList ID="days" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="monthsDdl" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="years" runat="server"></asp:DropDownList>
            <br />
            <asp:Button runat="server" Text="לחץ לעדכון" OnClick="Updatebutton" />
        </div>
    </form>
</body>
</html>
