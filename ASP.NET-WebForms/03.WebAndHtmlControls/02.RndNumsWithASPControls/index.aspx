<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_02.RndNumsWithASPControls.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txt_firstNumber" runat="server"></asp:TextBox>
        <asp:TextBox ID="txt_secondNumber" runat="server"></asp:TextBox>
        <asp:Button ID="btn_input" runat="server" Text="Button" OnClick="btn_input_Click" />
        <br />
        <asp:Label ID="lbl_output" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
