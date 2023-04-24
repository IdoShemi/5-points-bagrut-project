<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShowUsersPage.aspx.cs" Inherits="WebProject.user.ShowUsersPage" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">Users Control</h1>
    <form id="form1" runat="server">
        <div>
            <div class="btn33Container">
                <asp:Button class="button-33" ID="Button1" runat="server" Text="לחץ להצגת משתמשים" OnClick="Selectbutton" />
                <asp:TextBox Style="margin-left: 20px;" ID="InsertMail" runat="server" PlaceHolder="Mail" Text=""></asp:TextBox>
                <asp:TextBox Style="margin-left: 20px;" ID="Insertphonenumber" runat="server" PlaceHolder="phone number" Text=""></asp:TextBox>
                <br />
                <br />
                <asp:Literal ID="l1" runat="server"></asp:Literal>
                <asp:Repeater ID="usersRepeater" runat="server" Visible="false" OnItemCommand="Repeater1_ItemCommand">
                    <HeaderTemplate>
                        <table align='center'>
                            <tr style='background: #ddd; color: black;'>
                                <td>username</td>
                                <td>email</td>
                                <td>gender</td>
                                <td>phonenumber</td>
                                <td>firstname</td>
                                <td>lastname</td>
                                <td>city</td>
                                <td>address</td>
                                <td>birthday</td>
                                <td>Delete</td>
                                <td>Edit</td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("myusername") %></td>
                            <td><%# Eval("myemail") %></td>
                            <td><%# Eval("mygender") %></td>
                            <td><%# Eval("myphonenumber") %></td>
                            <td><%# Eval("myname") %></td>
                            <td><%# Eval("mylastname") %></td>
                            <td><%# Eval("mycity") %></td>
                            <td><%# Eval("myaddress") %></td>
                            <td><%# Eval("mybirthdate").ToString().Substring(0, 10) %></td>
                            <td>
                                <asp:Button OnClientClick="return confirm('are you sure?')" ID="deleteButton" runat="server" Text="Delete" CommandName="DeleteUser" CommandArgument='<%# Eval("myusername") %>' />
                            </td>
                            <td>
                                <a href="/admin/UpdateUserPage.aspx?un=<%# Eval("myusername") %>">
                                    <input type="button" value="Edit" />
                                </a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</asp:Content>
