<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShowUsersPage.aspx.cs" Inherits="WebProject.user.ShowUsersPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">תצוגת משתמשים</h1>
    <form id="form1" runat="server">
        <div>
            <div class="btn33Container">
                <asp:Button class="button-33" ID="Button1" runat="server" Text="לחץ להצגת משתמשים" OnClick="Selectbutton" />
                
                <asp:DropDownList ID="showUsersList" runat="server">
                </asp:DropDownList><br /><br />
                <asp:Literal ID="l1" runat="server"></asp:Literal>
                
            </div>
        </div>
    </form>
</asp:Content>
