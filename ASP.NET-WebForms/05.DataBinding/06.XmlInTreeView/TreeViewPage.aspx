<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeViewPage.aspx.cs" Inherits="_06.XmlInTreeView.TreeViewPage" %>

<%@ Import Namespace="System.Data" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="ControlPlaceHolder" runat="server"></asp:PlaceHolder>
        </div>
        <asp:XmlDataSource ID="BookXmlDataSource" runat="server" DataFile="~/App_Data/book.xml"></asp:XmlDataSource>
    </form>
</body>
</html>
