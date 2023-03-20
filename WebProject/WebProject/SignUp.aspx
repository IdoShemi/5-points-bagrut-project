<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebProject.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-lg-2"></div>
            <div class="col-lg-4">
                <a href="/user/InsertUserPage.aspx">
                    <button class="btn btn-block btn-primary font-weight-bold py-3">Sign Up User</button>
                </a>
            </div>
            <div class="col-lg-4">
                <a href="/seller/InsertSeller.aspx">
                    <button class="btn btn-block btn-primary font-weight-bold py-3">Sign Up Seller</button>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
