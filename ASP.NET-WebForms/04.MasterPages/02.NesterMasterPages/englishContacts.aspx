<%@ Page Title="" Language="C#" MasterPageFile="~/EnglishMaster.master" AutoEventWireup="true" CodeBehind="englishContacts.aspx.cs" Inherits="_02.NestedMasterPages.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="englishWrapper" runat="server">

    <p>
        you can't contact us, we contact you.
    </p>

    <div runat="server">
        <asp:TextBox runat="server"></asp:TextBox> <asp:Button runat="server" Text="Submit"/>
    </div>

</asp:Content>
