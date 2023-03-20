<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AskCategory.aspx.cs" Inherits="WebProject.categories.AskCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1 align="center">בקש להוספת קטגוריה/ תת קטגוריה</h1>

    <form id="form1" runat="server">
        <div>
            בחר מה אתה רוצה להוסיף:<br />
        </div>
        בקשה להוספת תת קטגוריה:
        <asp:DropDownList ID="showcategories" runat="server">
        </asp:DropDownList>
        <asp:TextBox ID="subCatText" runat="server"></asp:TextBox>
        <asp:Button ID="SubCatbtn" runat="server" OnClick="InsertSubCategorybutton" Text="בקש" />
        <p>
            בקשה להוספת קטגוריה:
            <asp:TextBox ID="CatText" runat="server"></asp:TextBox>
            <asp:Button ID="Catbtn" runat="server" OnClick="InsertCategorybutton" Text="בקש" />
        </p>
        <asp:Literal ID="l1" runat="server"></asp:Literal>
    </form>
</asp:Content>
