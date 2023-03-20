<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InsertProductPage.aspx.cs" Inherits="WebProject.products.InsertProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">הוספת מוצר</h1>
    <form id="form1" runat="server">
        <div>

            <span class="inputText">הכנס שם מוצר:</span><asp:TextBox ID="InsertProductName" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס כמות במלאי:</span><asp:TextBox ID="InsertAmount" runat="server" Text=""></asp:TextBox><br />
            <span class="inputText">הכנס מחיר מוצר:</span><asp:TextBox ID="InsertPrice" runat="server" Text=""></asp:TextBox><br />
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
            <asp:Button runat="server" Text="לחץ להוספה" OnClick="Insertbutton" />
        </div>
    </form>
</asp:Content>
