<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsCatalog.aspx.cs" Inherits="WebProject.user.ProductsCatalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 align="center">קטלוג מוצרים</h1>
        <center>
            <div style="display: inline-grid; margin-bottom:10px; direction: rtl; font-size: 1.2rem;column-gap: 50px; grid-template-columns: auto auto auto auto auto;">
                <div>
                    קטגוריה:<br />
                    <asp:DropDownList ID="Category" runat="server"  OnSelectedIndexChanged="dataChanged"  AutoPostBack="True">
                    </asp:DropDownList>
                </div>

                <div>
                    תת קטגוריה:<br />
                    <asp:DropDownList ID="SubCat" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>

                <div>
                    מחיר מקסימאלי:<br />
                    <asp:TextBox ID="MaxPrice" runat="server" Text=""></asp:TextBox>
                </div>
                <div>
                    מחיר מינימאלי:<br />
                    <asp:TextBox ID="MinPrice" runat="server" Text=""></asp:TextBox>
                </div>
                <div style="align-items:center; justify-content:center; display:flex;">
                    <asp:Button runat="server" Text="לחץ להחלת מסננים" OnClick="SetFilters" />
                </div>
            </div>
            <asp:DataList ID="DataList2" RepeatColumns="5" EnableViewState="false"
                runat="server" OnItemCommand="DataList2_ItemCommand"
                DataKeyField="productCode">
                <ItemTemplate>

                    <div style="border: 2px dashed black; height: 290px; width: 250px; margin: 5px; padding: 5px;">
                        <a href="../products/showProduct.aspx?pc=<%# Eval("productCode")%>" style="all: unset; cursor: pointer;">
                            <div style="text-align: center; padding-bottom: 5px; font-size: 1.5rem; direction: rtl;">
                                <asp:Label ID="Label2" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem,"productName")%>' ForeColor="Blue"></asp:Label><br />
                                <div style="font-size: 1.3rem;">
                                    מחיר:
                                    <asp:Label ID="Label1" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem,"Price")%>' ForeColor="black"></asp:Label>₪
                                    <br />
                                    מוכר:
                                    <asp:Label ID="Label3" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem,"productSeller")%>' ForeColor="black"></asp:Label>
                                </div>
                            </div>


                            <div style="width: fit-content; margin: 0 auto; margin-bottom: 5px; display: block;">
                                <asp:Image ImageAlign="Middle" ID="Image1" runat="server" Width="180" Height="180"
                                    ImageUrl='<%# Eval("ImageCode") %>' />
                            </div>
                        </a>


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
</body>
</html>
