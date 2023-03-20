<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UpdateProductPage.aspx.cs" Inherits="WebProject.products.UpdateProductPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">עדכון מוצר</h1>
        <form id="form1" runat="server">
        <div>
            <span class="inputText">שם מוצר:</span><asp:TextBox ID="InsertProductName" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">שם מוכר:</span><asp:TextBox ID="InsertSeller" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">כמות במלאי:</span><asp:TextBox ID="InsertAmount" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">קטגוריה</span>
            <asp:DropDownList ID="category" runat="server" OnSelectedIndexChanged="dataChanged" AutoPostBack="True"></asp:DropDownList>
            <br />


            <span class="inputText">תת קטגוריה</span>
            <asp:DropDownList ID="subcategory" runat="server" AutoPostBack="True"></asp:DropDownList>
            <br />

            <span class="inputText">מספר סידורי</span><asp:TextBox ID="InsertSerialNum" runat="server" Text=""></asp:TextBox><br />

            <span class="inputText">תמונה</span>
            <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" />
            <br />
            <asp:Image ID="Image1" runat="server" Width="150" />
            <br />
            <asp:Button runat="server" Text="לחץ לעדכון" OnClick="Updatebutton" />
        </div>
    </form>
</asp:Content>
