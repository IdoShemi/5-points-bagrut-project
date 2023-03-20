<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="showProductPage.aspx.cs" Inherits="WebProject.products.showProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div style="font-size: 1.8rem; display: flex; justify-content: center; align-items: center; height: 95vh; border: 3px solid green; direction: rtl;">
            <div style="display: inline">
                שם המוצר:
                <asp:Label ID="InsertProductName" runat="server" Text=""></asp:Label>
                <br />
                שם המוכר:
                <asp:Label ID="InsertSeller" runat="server" Text=""></asp:Label>
                <br />
                קטגוריה:
                <asp:Label ID="Category" runat="server" Text=""></asp:Label>
                <br />
                תת קטגוריה:
                <asp:Label ID="subcategory" runat="server" Text=""></asp:Label>
                <br />
                כמות במלאי:
                <asp:Label ID="InsertAmount" runat="server" Text=""></asp:Label>
                <br />
                מחיר:
                <asp:Label ID="InsertPrice" runat="server" Text=""></asp:Label>
                ₪
            </div>
            <asp:Image ID="Image1" runat="server" Style="width: 25%; height: auto; margin-right: 5px;" />
        </div>

    </form>
</asp:Content>
