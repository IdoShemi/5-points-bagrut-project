<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddCategoryPage.aspx.cs" Inherits="WebProject.categories.AddCategoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">הוספת קטגוריה/ תת קטגוריה</h1>

    <form id="form1" runat="server">
        <div>
            בחר מה אתה רוצה להכניס:<br />
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
</asp:Content>
