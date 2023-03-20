<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageCategoryRequests.aspx.cs" Inherits="WebProject.categories.ManageCategoryRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">ניהול בקשות להוספת קטגוריה</h1>
    <form id="form1" runat="server">
        <center>
            <asp:DataList ID="DataList2" RepeatColumns="5" EnableViewState="false"
                runat="server" OnItemCommand="DataList2_ItemCommand"
                DataKeyField="Id">
                <itemtemplate>

                    <div style="border: 2px dashed black; height: 290px; width: 250px; margin: 5px; padding: 5px;">
                        <div style="text-align: center; padding-bottom: 5px; font-size: 1.5rem; direction: rtl;">
                            <asp:Label ID="Label2" runat="server"
                                Text='<%# DataBinder.Eval(Container.DataItem,"categoryName")%>' ForeColor="Blue"></asp:Label>
                            <br />
                            <div style="font-size: 1.3rem;">
                                תת קטגוריה (אם לא כתוב הבקשה היא לקטגוריה חדשה):
                                <asp:Label ID="Label1" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem,"subCategoryName")%>' ForeColor="black"></asp:Label>
                            </div>
                        </div>

                        <div style="display: flex; flex-wrap: wrap; justify-content: center; height: fit-content; align-items: center; width: fit-content; margin: 0 auto;">
                            <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("sellerName")+ "," + Eval("categoryName") + "," +Eval("subCategoryName")+ "," +Eval("Id") %>'
                                CommandName="AcceptRequest" Text="Accept Request" Style="margin-right: 5px;" />
                            <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("sellerName")+ "," + Eval("categoryName") + "," +Eval("subCategoryName")+ "," +Eval("Id") %>'
                                Text="Delete Request" CommandName="DeleteRequest" />
                        </div>

                    </div>
                </itemtemplate>

            </asp:DataList>
        </center>
    </form>
</asp:Content>
