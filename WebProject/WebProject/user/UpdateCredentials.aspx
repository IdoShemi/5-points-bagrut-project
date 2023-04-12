<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UpdateCredentials.aspx.cs" Inherits="WebProject.user.UpdateCredentials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">עדכון משתמש</h1>
    <form id="form1" runat="server">
        <div>
            <span class="inputText">שם משתמש לעדכון:</span><asp:TextBox ID="InsertName" Enabled="false" runat="server" Text=""></asp:TextBox>
                        <asp:Button runat="server" Text="מחק משתמש" ID="deleteBtn" OnClick="Delbutton" OnClientClick="return confirm('are you sure?')"/>



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
            <br />

        </div>
    </form>
</asp:Content>
