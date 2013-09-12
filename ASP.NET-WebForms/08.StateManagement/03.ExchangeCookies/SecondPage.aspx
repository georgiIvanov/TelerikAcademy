<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondPage.aspx.cs" Inherits="_03.ExchangeCookies.SecondPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" ID="button" Text="Go Back" OnClick="button_Click"/>
        <br />
        <asp:Literal runat="server" ID="Literal"></asp:Literal>
    </div>
    </form>
</body>
</html>
