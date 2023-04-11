<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="showProductPage.aspx.cs" Inherits="WebProject.products.showProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .add-to-basket {
            display: inline-block;
            padding: 10px 20px;
            font-size: 18px;
            font-weight: bold;
            text-transform: uppercase;
            color: #fff;
            background-color: #007bff;
            border: none;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.3);
            cursor: pointer;
            transition: background-color 0.2s, box-shadow 0.2s;
        }

        .popup {
            display: none;
            position: fixed;
            top: 85px;
            right: 20px;
            width: 300px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 5px 15px rgba(0, 0, 0, 0.3);
            overflow: hidden;
        }

        .popup-content {
            padding: 20px;
        }

        .popup-message {
            font-size: 24px;
            font-weight: bold;
            text-align: center;
            color: #007bff;
            text-shadow: 1px 1px #fff;
        }

        .add-to-basket:hover,
        .add-to-basket:focus {
            background-color: #0062cc;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div style="font-size: 1.8rem; display: flex; justify-content: center; align-items: center; height: 80vh; direction: rtl;">
            <div style="display: inline;">
                <div style="text-align: right;">
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
                    ₪<br />
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:Button class="add-to-basket" runat="server" Text="Add To Basket" OnClick="UpdateBasket" />
                </div>
            </div>
            <asp:Image ID="Image1" runat="server" Style="width: 25%; height: auto; margin-right: 25px;" />
        </div>

        <div id="popup" runat="server" class="popup">
            <div class="popup-content">
                <div class="popup-message">Product added to basket!</div>
            </div>
        </div>
    </form>
</asp:Content>
