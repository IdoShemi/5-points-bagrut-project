<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertSeller2.aspx.cs" Inherits="WebProject.InsertSeller2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span class="inputText">הכנס שם משתמש:</span><asp:TextBox ID="UserName" runat="server" Text=""></asp:TextBox><br />

            <span class="inputText">הכנס שם עסק:</span><asp:TextBox ID="SellerName" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס סיסמא:</span><asp:TextBox ID="InsPass" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס מספר טלפון:</span><asp:TextBox ID="Phone" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס כתובת מייל:</span><asp:TextBox ID="Mymail" runat="server" Text=""></asp:TextBox><br />

            <span class="inputText">הכנס מספר חשבון בנק:</span><asp:TextBox ID="BankAccount" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס זמן משלוח ממוצע (בימים):</span><asp:TextBox ID="avgDelivery" runat="server" Text=""></asp:TextBox><br />


            <span class="inputText">הכנס עיר מגורים:</span><asp:TextBox ID="InsertCity" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס כתובת מגורים:</span><asp:TextBox ID="InsertAddress" runat="server" Text=""></asp:TextBox><br />


            <asp:Button runat="server" Text="לחץ להוספה" OnClick="Insertbutton" />
        </div>
    </form>
</body>
</html>
