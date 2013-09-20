<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl.ascx.cs" Inherits="PageAndControlCaching.UserControl" %>
<%@ OutputCache Duration="3" VaryByParam="none" Shared="true" %>

<h2><%= DateTime.Now.ToLongTimeString() %></h2>
<h3>This is a cached control!</h3>