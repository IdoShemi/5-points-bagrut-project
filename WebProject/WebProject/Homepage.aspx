<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="WebProject.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
  margin: 0;
  padding: 0;
  font-family: Arial, sans-serif;
  font-size: 16px;
}

header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem;
  background-color: #333;
  color: #fff;
}

.logo img {
  height: 50px;
}

.cart-icon img {
  height: 30px;
}

main {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: calc(100vh - 100px);
}

h1 {
  font-size: 3rem;
  margin-bottom: 2rem;
  text-align: center;
}

.buttons {
  display: flex;
  justify-content: center;
  align-items: center;
}

.login-btn, .signup-btn {
  padding: 0.5rem 1rem;
  margin: 0 1rem;
  border: none;
  background-color: #333;
  color: #fff;
  font-size: 1rem;
  cursor: pointer;
}

.login-btn:hover, .signup-btn:hover {
  background-color: #555;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <main>
    <h1>Welcome to My Shopping Website</h1>
    <div class="buttons" id="mydiv" runat="server">
      <a href="SignIn.aspx"><button class="login-btn">Sign In</button>
      <a href="SignUp.aspx"><button class="signup-btn">Sign Up</button></a>
    </div>
  </main>
</asp:Content>
