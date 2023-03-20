<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DeleteUserPage.aspx.cs" Inherits="WebProject.user.DeleteUserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">מחיקת משתמש לאדמין</h1>
        <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" Text="מחק" OnClick="Delbutton" OnClientClick="return confirm('are you sure?')"/>
            <asp:TextBox ID="Delbox" runat="server"></asp:TextBox>
        </div>
    </form>
</asp:Content>
