<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MangeProductsPage.aspx.cs" Inherits="WebProject.products.MangeProductsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">ניהול מוצרים</h1>
    <form id="form1" runat="server">
        <center>
            <asp:DataList ID="DataList2" RepeatColumns="5" EnableViewState="false"
                runat="server" OnItemCommand="DataList2_ItemCommand"
                DataKeyField="productCode">
                <ItemTemplate>

                    <div style="border: 2px dashed black; height: 290px; width: 250px; margin: 5px; padding: 5px;">
                        <div style="text-align: center; padding-bottom: 5px; font-size: 1.5rem; direction: rtl;">
                            <asp:Label ID="Label2" runat="server"
                                Text='<%# DataBinder.Eval(Container.DataItem,"productName")%>' ForeColor="Blue"></asp:Label><br />
                            <div style="font-size: 1.3rem;">
                                מחיר:
                                <asp:Label ID="Label1" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem,"Price")%>' ForeColor="black"></asp:Label>₪
                            </div>
                        </div>


                        <div style="width: fit-content; margin: 0 auto; margin-bottom: 5px; display: block;">
                            <asp:Image ImageAlign="Middle" ID="Image1" runat="server" Width="180" Height="180"
                                ImageUrl='<%# Eval("ImageCode") %>' />
                        </div>
                        <div style="display: flex; flex-wrap: wrap; justify-content: center; height: fit-content; align-items: center; width: fit-content; margin: 0 auto;">
                            <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("productCode") + "," + Eval("productName") %>'
                                CommandName="EditProduct" Text="Edit Product" Style="margin-right: 5px;" />
                            <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("productCode") + "," + Eval("productName") %>'
                                Text="Show Product" CommandName="ShowProduct" />
                            <asp:Button ID="Button1" OnClientClick="return confirm('are you sure?')" runat="server" CommandArgument='<%# Eval("productCode") + "," + Eval("productName") %>'
                                Text="Delete Product" CommandName="DeleteProduct" Style="margin-top: 5px; justify-self: center;" />
                        </div>

                    </div>
                </ItemTemplate>
                <%--<AlternatingItemTemplate>
         <table border="1">
        <tr>
        <td style="color:blue;text-align:center">
            <asp:Button ID="Button2" runat="server" 
            Text="Add to Basket" CommandName="AddtoBasket" />
        </td>
        <td style="color:blue;text-align:center">
            <asp:Label ID="Label2" runat="server" 
            Text='<%# DataBinder.Eval(Container.DataItem,"productName")%>' ForeColor="BlueViolet"></asp:Label>
        </td>
        
        
        </tr>
        
        
        
        </table>
            <asp:Button ID="Button3" runat="server"  
            Text="Show Details" CommandName="ShowDetails" />
        
        </AlternatingItemTemplate>--%>
            </asp:DataList>
        </center>
    </form>
</asp:Content>
