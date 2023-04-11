<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="WebProject.seller.orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .order {
            border: 1px solid #ddd;
            padding: 10px;
            margin-bottom: 10px;
        }

            .order h3 {
                margin-top: 0;
                margin-bottom: 5px;
            }

            .order p {
                margin-top: 0;
                margin-bottom: 5px;
            }


        .checkbox-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: auto;
        }

        input[type=checkbox] {
            position: relative;
            display: inline-block;
            width: 20px;
            height: 20px;
            margin: 0 10px;
            cursor: pointer;
        }

            input[type=checkbox]:before {
                content: '';
                display: block;
                position: absolute;
                top: 0;
                left: 0;
                width: 20px;
                height: 20px;
                background: white;
                border-radius: 4px;
                border: 2px solid #777;
            }

            input[type=checkbox]:checked:before {
                background: #4CAF50;
                border-color: #4CAF50;
            }

            input[type=checkbox]:after {
                content: '';
                display: block;
                position: absolute;
                top: 4px;
                left: 8px;
                width: 4px;
                height: 8px;
                border: solid white;
                border-width: 0 2px 2px 0;
                transform: rotate(45deg);
                visibility: hidden;
            }

            input[type=checkbox]:checked:after {
                visibility: visible;
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <h1 align="center">View Orders</h1>
        <div class="checkbox-container">

            <asp:CheckBox ID="myCheckBox" runat="server" Text="Only Non-Delivered orders" OnCheckedChanged="myCheckBox_CheckedChanged" AutoPostBack="true" />
        </div>
        <div>
            <div class="btn33Container">
                <asp:Literal ID="l1" runat="server"></asp:Literal>
                <asp:Repeater ID="usersRepeater" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <headertemplate>
                        <table align='center'>
                            <tr style='background: #ddd; color: black;'>
                                <td>Order ID</td>
                                <td>User Name</td>
                                <td>address</td>
                                <td>Order Date</td>
                                <td>Product Name</td>
                                <td>Product Quantity</td>
                                <td>Order Status</td>
                                <td>Change Status</td>
                            </tr>
                    </headertemplate>
                    <itemtemplate>
                        <tr>
                            <td><%# Eval("order_id") %></td>
                            <td><%# Eval("user_name") %></td>
                            <td><%# Eval("address") %>, <%# Eval("city") %></td>
                            <td><%# Eval("order_date") %></td>
                            <td><%# Eval("product_name") %></td>
                            <td><%# Eval("product_quantity") %></td>
                            <td><%# Eval("order_status") %></td>
                            <td>
                                <asp:Button ID="orderDelivered" runat="server" Text="Set Delivered" CommandName="Delivered" CommandArgument='<%# Eval("product_name") + "," + Eval("order_id") %>' />
                            </td>
                        </tr>
                    </itemtemplate>
                    <footertemplate>
                        </table>
                    </footertemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</asp:Content>
