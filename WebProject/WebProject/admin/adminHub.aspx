<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminHub.aspx.cs" Inherits="WebProject.admin.adminHub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style>
		body {
			background-color: #111;
			color: #fff;
			font-family: Arial, sans-serif;
			text-align: center;
			margin: 0;
			padding: 0;
		}
		h1 {
			font-size: 5rem;
			margin-top: 5rem;
			text-shadow: 0 0 15px #fff, 0 0 20px #fff, 0 0 30px #fff, 0 0 40px #0ff, 0 0 50px #0ff, 0 0 60px #0ff, 0 0 70px #0ff;
		}
		p {
			font-size: 2rem;
			margin-top: 3rem;
		}

		.btn2 {
			background-color: #0ff;
			border: none;
			border-radius: 10px;
			color: #111;
			cursor: pointer;
			font-size: 1.5rem;
			font-weight: bold;
			margin-top: 3rem;
			padding: 1rem 3rem;
			text-shadow: 0 0 10px #fff, 0 0 15px #fff, 0 0 20px #fff, 0 0 25px #0ff, 0 0 30px #0ff, 0 0 35px #0ff, 0 0 40px #0ff;
			transition: all 0.3s ease;

		}
		.btn2:hover {
			background-color: #fff;
			color: #0ff;
			text-shadow: 0 0 10px #111, 0 0 15px #111, 0 0 20px #111, 0 0 25px #0ff, 0 0 30px #0ff, 0 0 35px #0ff, 0 0 40px #0ff;
		}

	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h1>Welcome to the Admin Hub</h1>
	<p>We are the admins. We are the managers. We have the highest privileges!</p>
	
	<div class="container-fluid">
        <div class="row d-flex justify-content-center">
            <div class="col-lg-2">
                <a href="ShowUsersPage.aspx">
                    <button class="btn2 btn-block btn-primary font-weight-bold py-3">Control <br />Users</button>
                </a>
            </div>


            <div class="col-lg-2">
                <a href="SignInSellerPage.aspx">
                    <button class="btn2 btn-block btn-primary font-weight-bold py-3">Control <br />Sellers</button>
                </a>
            </div>

			<div class="col-lg-2">
                <a href="SignInSellerPage.aspx">
                    <button class="btn2 btn-block btn-primary font-weight-bold py-3">Control <br />Requests</button>
                </a>
            </div>

			<div class="col-lg-2">
                <a href="SignInSellerPage.aspx">
                    <button class="btn2 btn-block btn-primary font-weight-bold py-3">Control <br />Products</button>
                </a>
            </div>

			<div class="col-lg-2">
                <a href="SignInSellerPage.aspx">
                    <button class="btn2 btn-block btn-primary font-weight-bold py-3">View <br />Reports</button>
                </a>
            </div>

        </div>
    </div>
</asp:Content>
