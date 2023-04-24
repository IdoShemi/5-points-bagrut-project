<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="WebProject.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .product-list {
        list-style: none;
        margin: 0;
        padding: 0;
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
    }
    .product-item {
        margin: 20px;
        padding: 20px;
        border: 1px solid #ddd;
        border-radius: 5px;
        width: 300px;
        text-align: center;
    }
    .product-image img {
        max-width: 100%;
        height: auto;
    }
    .product-name {
        font-size: 24px;
        font-weight: bold;
        margin-top: 10px;
    }
    .product-seller {
        margin-top: 10px;
    }
    .product-quantity {
        margin-top: 10px;
        font-weight: bold;
    }

    .header {
      background-color: #fff;
      padding: 20px;
      box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
    }

    .header__welcome {
      text-align: center;
    }

    .header__welcome-text {
      margin: 0;
      font-size: 36px;
      font-weight: 700;
      color: #333;
      text-transform: uppercase;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class="header">
  <div class="header__welcome">
    <h1 class="header__welcome-text">Welcome to AllBuy</h1>
  </div>
</header><br />

    <div style="max-width: 800px; margin: 0 auto;">
    <h1>Top 5 Best-Selling Products This Month</h1>
    <asp:Repeater ID="repeater2" runat="server">
        <headertemplate>
            <ul class="product-list">
        </headertemplate>
        <itemtemplate>
            <a style="all:unset; cursor:pointer" title="show product" href="/products/showProductPage.aspx?pc=<%# Eval("productCode") %>">
            <li class="product-item">
                <div class="product-image">
                    <img src='<%# "/images" + Eval("ImageCode") %>' alt='<%# Eval("product_name") %>'>
                </div>
                <div class="product-name"><%# Eval("product_name") %></div>
                <div class="product-seller">Seller: <%# Eval("seller") %></div>
                <div class="product-quantity">Total Quantity Sold: <%# Eval("total_quantity") %></div>
            </li>
                </a>
        </itemtemplate>
        <footertemplate>
            </ul>
        </footertemplate>
    </asp:Repeater>
</div>


</asp:Content>
