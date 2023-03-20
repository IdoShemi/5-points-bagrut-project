<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignInSellerPage.aspx.cs" Inherits="WebProject.SignInSellerPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form id="form1" runat="server">
        <div>
            <span class="inputText">הכנס שם משתמש:</span><asp:TextBox ID="InputUserName" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס סיסמה</span><asp:TextBox ID="InputPassWord" runat="server" Text=""></asp:TextBox><br />
            <asp:Label ID="Label1" runat="server" Text="" style="color:red;"></asp:Label><br />
            <asp:Button runat="server" Text="התחבר" OnClick="SignInFunc" style="height: 26px" />
        </div>
    </form>
</asp:Content>
