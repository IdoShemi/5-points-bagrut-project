<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UpdateSellerCred.aspx.cs" Inherits="WebProject.seller.UpdateSellerCred" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1 align="center">עדכון עסק</h1>
    <form id="form1" runat="server">
        <div>
            <span class="inputText">הכנס שם משתמש:</span><asp:TextBox ID="UserName" runat="server" Text=""></asp:TextBox><br />

            <span class="inputText">הכנס שם עסק לעדכון:</span><asp:TextBox ID="SellerName" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס סיסמא:</span><asp:TextBox ID="InsPass" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס מספר טלפון:</span><asp:TextBox ID="Phone" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס כתובת מייל:</span><asp:TextBox ID="Mymail" runat="server" Text=""></asp:TextBox><br />

            <span class="inputText">הכנס מספר חשבון בנק:</span><asp:TextBox ID="BankAccount" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס זמן משלוח ממוצע (בימים):</span><asp:TextBox ID="avgDelivery" runat="server" Text=""></asp:TextBox><br />


            <span class="inputText">הכנס עיר עסק:</span><asp:TextBox ID="InsertCity" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס כתובת עסק:</span><asp:TextBox ID="InsertAddress" runat="server" Text=""></asp:TextBox><br />


            <asp:Button runat="server" Text="לחץ לעדכון פרטים" OnClick="Updatebutton" />

            <br /><br />

            <asp:Button runat="server" Text="מחק עסק" ID="deleteBtn" Visible="true" OnClick="Delbutton" OnClientClick="return confirm('are you sure?')"/>
        </div>
    </form>
</asp:Content>
