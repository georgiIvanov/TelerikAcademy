<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsTemplate._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
    <asp:ListView ID="ChatView" runat="server" DataSourceID="MessagesRepository" OnItemDataBound="ChatView_ItemDataBound" DataKeyNames="Id">
       
        <AlternatingItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="TextLabel" runat="server" Text='<%# Eval("Text") %>' />
                </td>
                <td>
                    <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
       
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextTextBox" runat="server" Text='<%# Bind("Text") %>' />
                </td>
                <td>
                    <asp:TextBox ID="AuthorTextBox" runat="server" Text='<%# Bind("Author") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextTextBox" runat="server" Text='<%# Bind("Text") %>' />
                </td>
                <td>
                    <asp:TextBox ID="AuthorTextBox" runat="server" Text='<%# Bind("Author") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="TextLabel" runat="server" Text='<%# Eval("Text") %>' />
                </td>
                <td>
                    <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server"></th>
                                <th runat="server">Id</th>
                                <th runat="server">Text</th>
                                <th runat="server">Author</th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style=""></td>
                </tr>
            </table>
        </LayoutTemplate>
       
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="TextLabel" runat="server" Text='<%# Eval("Text") %>' />
                </td>
                <td>
                    <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
       
    </asp:ListView>
    <asp:ObjectDataSource ID="MessagesRepository" runat="server" SelectMethod="Select" TypeName="WebFormsTemplate.MessagesRepository" UpdateMethod="Edit" DeleteMethod="Delete">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="Text" Type="String" />
            <asp:Parameter Name="Author" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="Text" Type="String" />
            <asp:Parameter Name="Author" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <asp:PlaceHolder ID="InsertHolder" runat="server"></asp:PlaceHolder>
</asp:Content>
