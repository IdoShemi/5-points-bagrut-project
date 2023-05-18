<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="sellerReport.aspx.cs" Inherits="WebProject.seller.sellerReport" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Basic styling for the Repeater control */
        .product-list {
            list-style: none;
            margin: 20px 0;
            padding: 0;
        }

        .product-item {
            border: 1px solid black;
            margin: 5px 0;
            padding: 10px;
        }

        .product-name {
            font-weight: bold;
        }

        .product-quantity {
            margin-top: 5px;
        }

        #chartContainer {
            text-align: center;
        }
    </style>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header style="background-color: #3f51b5; color: #ffffff; padding: 20px; margin-bottom:20px">
  <h1 style="color: black; font-size: 48px; margin: 0;">Seller Reports</h1>
</header>
    <form id="form1" runat="server">
        <div style="max-width: 800px; margin: 0 auto;">
            <h1>Top 5 Best-Selling Products This Month</h1>
            <asp:Repeater ID="repeater" runat="server">
                <headertemplate>
                    <ul class="product-list">
                </headertemplate>
                <itemtemplate>
                    <li class="product-item">
                        <div class="product-name"><%# Eval("product_name") %></div>
                        <div class="product-quantity">Total Quantity Sold: <%# Eval("total_quantity") %></div>
                    </li>
                </itemtemplate>
                <footertemplate>
                    </ul>
                </footertemplate>
            </asp:Repeater>
        </div>
        <div style="max-width: 800px; margin: 0 auto;">
            <h1>Top 5 Best-Selling Products This Year</h1>
            <asp:Repeater ID="repeater2" runat="server">
                <headertemplate>
                    <ul class="product-list">
                </headertemplate>
                <itemtemplate>
                    <li class="product-item">
                        <div class="product-name"><%# Eval("product_name") %></div>
                        <div class="product-quantity">Total Quantity Sold: <%# Eval("total_quantity") %></div>
                    </li>
                </itemtemplate>
                <footertemplate>
                    </ul>
                </footertemplate>
            </asp:Repeater>
        </div>
    </form>
</asp:Content>
