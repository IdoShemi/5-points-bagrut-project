<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="ManageProducts.aspx.cs" Inherits="WebProject.products.ManageProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DataList ID="DataList2" RepeatColumns="3" EnableViewState="false"
            runat="server" OnItemCommand="DataList2_ItemCommand"
            DataKeyField="productCode">
            <ItemTemplate>

                <div style="border:2px dashed black;height: 160px; width:200px; margin: 5px; padding: 5px;">
                    <div style="text-align:center; padding-bottom: 5px;"><asp:Label ID="Label2" runat="server"
                        Text='<%# DataBinder.Eval(Container.DataItem,"productName")%>' ForeColor="Blue"></asp:Label></div>


                    <div style="width:200px;"><asp:Image ImageAlign="Middle" ID="Image1" runat="server" Width="150" Height="120"
                        ImageUrl='<%# Eval("ImageCode") %>' /></div>

                    <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("productCode") + "," +
                            Eval("productName") %>' CommandName="EditProduct" Text="Edit Product" />

                    <asp:Button ID="Button3" runat="server"
                        Text="Show Product" CommandName="ShowProduct" />
                    <br />
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
    </form>
</body>
</html>
