<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_03.HtmlEscaping.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txt_inputTextbox" runat="server"></asp:TextBox>
        <asp:Button ID="btn_submit" runat="server" Text="Button" OnClick="btn_submit_Click" />
        <br />
        <asp:TextBox ID="txt_outputTextbox" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_outputLabel" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
