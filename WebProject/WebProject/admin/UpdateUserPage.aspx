﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UpdateUserPage.aspx.cs" Inherits="WebProject.user.UpdateUserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">עדכון משתמש לאדמין</h1>
    <form id="form1" runat="server">
        <div>
            <span class="inputText">שם משתמש לעדכון:</span><asp:TextBox ID="InsertName" runat="server" Text=""></asp:TextBox>



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
</asp:Content>
