<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductsCatalogPage.aspx.cs" Inherits="WebProject.user.ProductsCatalogPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h1 align="center">קטלוג מוצרים</h1>
        <center>
            <div style="display: inline-grid; margin-bottom: 10px; direction: rtl; font-size: 1.2rem; column-gap: 50px; grid-template-columns: auto auto auto auto auto;">
                <div>
                    קטגוריה:<br />
                    <asp:DropDownList ID="Category" runat="server" OnSelectedIndexChanged="dataChanged" AutoPostBack="True">
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
                <div style="align-items: center; justify-content: center; display: flex;">
                    <asp:Button runat="server" Text="לחץ להחלת מסננים" OnClick="SetFilters" />
                </div>
            </div>
            <div class="col-lg-9 col-md-8">
                <div class="row pb-3">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <div class="col-lg-4 col-md-6 col-sm-6 pb-1">
                                <div class="product-item bg-light mb-4">
                                    <div class="product-img position-relative overflow-hidden">
                                        <a href='../products/showProductPage.aspx?pc=<%# Eval("productCode") %>'>
                                        <img class="img-fluid w-100" src='<%# Eval("ImageCode") %>' alt=""></a>
                                    </div>
                                    <div class="text-center py-4">
                                        <a class="h6 text-decoration-none text-truncate" href='../products/showProductPage.aspx?pc=<%# Eval("productCode") %>'><%# Eval("productName") %></a>
                                        <div class="d-flex align-items-center justify-content-center mt-2">
                                            <h5><%# Eval("Price") %> :מחיר</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <%--</asp:DataList>--%>
            <%--<asp:DataList ID="DataList2" RepeatColumns="5" EnableViewState="false"
                runat="server" OnItemCommand="DataList2_ItemCommand"
                DataKeyField="productCode">
                <ItemTemplate>
                    <div class="col-lg-4 col-md-6 col-sm-6 pb-1">
                        <div class="product-item bg-light mb-4">
                            <div class="product-img position-relative overflow-hidden">
                                <img class="img-fluid w-100" src="<%# Eval("ImageCode") %>" alt="">
                                <div class="product-action">
                                    <a class="btn btn-outline-dark btn-square" href=""><i class="fa fa-shopping-cart"></i></a>
                                    <a class="btn btn-outline-dark btn-square" href=""><i class="far fa-heart"></i></a>
                                    <a class="btn btn-outline-dark btn-square" href=""><i class="fa fa-sync-alt"></i></a>
                                    <a class="btn btn-outline-dark btn-square" href=""><i class="fa fa-search"></i></a>
                                </div>
                            </div>
                            <div class="text-center py-4">
                                <a class="h6 text-decoration-none text-truncate" href="../products/showProductPage.aspx?pc=<%# Eval("productCode")%>"><%# DataBinder.Eval(Container.DataItem,"productName")%></a>
                                <div class="d-flex align-items-center justify-content-center mt-2">
                                    <h5><%# DataBinder.Eval(Container.DataItem,"Price")%></h5>
                                    </h6>
                                </div>
                            </div>
                        </div>
                    </div>--%>
            <%--</ItemTemplate>--%>



            <%--                    <div style="border: 2px dashed black; height: 290px; width: 250px; margin: 5px; padding: 5px;">
                        <a href="../products/showProductPage.aspx?pc=<%# Eval("productCode")%>" style="all: unset; cursor: pointer;">
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


                    </div>--%>

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
        </center>
    </form>
</asp:Content>
