<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="WebProject.user.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700&display=swap" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">

    <!-- Libraries Stylesheet -->
    <link href="lib/animate/animate.min.css" rel="stylesheet">
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">

    <!-- Customized Bootstrap Stylesheet -->
    <link href="css/style.css" rel="stylesheet">
    <style>
        .shopping-cart {
            background-color: #f1f1f1;
            border: 2px solid #333;
            border-radius: 10px;
            padding: 10px;
            margin: 10px;
        }

        .shopping-cart-header {
            font-size: 24px;
            font-weight: bold;
            text-align: center;
            margin-bottom: 10px;
        }

        .shopping-cart-total {
            font-size: 18px;
            font-weight: bold;
            margin-top: 10px;
        }

        .shopping-cart-item {
            display: flex;
            justify-content: space-between;
            margin-bottom: 5px;
            padding: 5px;
            background-color: #fff;
            border: 1px solid #ddd;
            border-radius: 5px;
        }

        .shopping-cart-item-name {
            font-size: 16px;
            font-weight: bold;
        }

        .shopping-cart-item-price {
            font-size: 16px;
            font-weight: bold;
        }
    </style>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div class="shopping-cart">
        <div class="shopping-cart-header">Shopping Cart</div>
        <div class="container-fluid">
            <div class="row px-xl-5">
                <div class="col-lg-8 table-responsive mb-5">
                    
                        <asp:Repeater ID="myRepeater" runat="server">
                            <HeaderTemplate>
                                <table class="table table-light table-borderless table-hover text-center mb-0">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th>Name</th>
                                            <th>Seller</th>
                                            <th>Price</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody class="align-middle">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    </td>

                        <td class="align-middle">
                            <img src="<%# Eval("ImageCode") %>" alt="" style="width: 50px;">
                            <%# Eval("productName") %></td>
                                    <td class="align-middle"><%# Eval("productSeller") %></td>
                                    <td class="align-middle"><%# Eval("Price", "{0:C}") %> ₪</td>
                                    <td class="align-middle">
                                        <%--<asp:LinkButton runat="server" ID="btnDelete" CssClass="btn btn-sm btn-danger">
                                            <i class="fa fa-times" OnClick="btnRemove_Click"></i>
                                        </asp:LinkButton>--%>
                                        <asp:ImageButton CommandArgument='<%# Eval("productName")+"," + Eval("productSeller") %>' runat="server" ImageUrl="~/user/delete.png" OnClick="btnRemove_Click" Style="margin: 0; padding: 0; height: 30px" CssClass="btn btn-sm btn-danger" />

                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                    </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    


                </div>



                <div class="col-lg-4">
                    <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Cart Summary</span></h5>
                    <div class="bg-light p-30 mb-5">


                        <div class="d-flex justify-content-between mt-2">
                            <h5>Total</h5>
                            <h5>
                                <asp:Label ID="Total" runat="server" Text="0"></asp:Label> ₪
                            </h5>
                        </div>
                        <asp:Button CssClass="btn btn-block btn-primary font-weight-bold my-3 py-3" runat="server" Text="Proceed To Checkout" OnClick="Checkout" />

<%--                        <button class="btn btn-block btn-primary font-weight-bold my-3 py-3">Proceed To Checkout</button>--%>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
