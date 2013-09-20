<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PageAndControlCaching.About" %>
<%@ OutputCache CacheProfile="Short" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%= DateTime.Now.ToLongTimeString() %></h1>

    </header>

</asp:Content>
