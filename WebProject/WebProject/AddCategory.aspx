﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="WebProject.AddCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>בחר מה אתה רוצה להכניס:<br />
        </div>
        הכנס תת קטגוריה:
        <asp:DropDownList ID="showcategories" runat="server">
        </asp:DropDownList>
        <asp:TextBox ID="subCatText" runat="server"></asp:TextBox>
        <asp:Button ID="SubCatbtn" runat="server" OnClick="InsertSubCategorybutton" Text="הכנס תת קטגוריה" />
        <p>
            הכנס קטגוריה:
            <asp:TextBox ID="CatText" runat="server"></asp:TextBox>
            <asp:Button ID="Catbtn" runat="server" OnClick="InsertCategorybutton" Text="הכנס קטגוריה" />
        </p>
    </form>
</body>
</html>