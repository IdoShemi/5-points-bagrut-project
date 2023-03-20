<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="WebProject.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-lg-2"></div>
            <div class="col-lg-4">
                <a href="SignInUserPage.aspx">
                    <button class="btn btn-block btn-primary font-weight-bold py-3">Sign In User</button>
                </a>
            </div>
            <div class="col-lg-4">
                <a href="SignInSellerPage.aspx">
                    <button class="btn btn-block btn-primary font-weight-bold py-3">Sign In Seller</button>
                </a>
            </div>
        </div>
    </div>

</asp:Content>
