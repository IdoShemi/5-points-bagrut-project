<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="orderSent.aspx.cs" Inherits="WebProject.user.orderSent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
      body {
        font-family: Arial, sans-serif;
        background-color: #f5f5f5;
      }
      #container {
        width: 80%;
        margin: auto;
        background-color: #ffffff;
        padding: 20px;
        border-radius: 10px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
      }
      h1 {
        text-align: center;
        margin-top: 0;
      }
      p {
        text-align: center;
        margin-bottom: 20px;
      }
      button {
        display: block;
        margin: auto;
        background-color: #007bff;
        color: #ffffff;
        padding: 10px 20px;
        border-radius: 5px;
        border: none;
        font-size: 16px;
        cursor: pointer;
      }
      button:hover {
        background-color: #0069d9;
      }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="container">
      <h1>Order Sent!</h1>
      <p>Your order with order number: <strong><asp:Literal runat="server" ID="l1"></asp:Literal></strong> has been successfully sent to sellers.</p>
      <button onclick="location.href='/HomePage.aspx'">Continue Shopping</button>
    </div>
</asp:Content>
