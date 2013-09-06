<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_01.PrintInput.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="btn_Submit" runat="server" OnClick="Button1_Click" Text="Button" />

        </div>
        <div>
            <asp:Label ID="hello_label" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
