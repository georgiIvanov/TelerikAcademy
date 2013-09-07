<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_05.TicTacToe.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <button id="top_left" runat="server" onserverclick="top_left_Click">_</button>
        <button id="top_center" runat="server" onserverclick="top_center_Click">_</button>
        <button id="top_right" runat="server" onserverclick="top_right_Click">_</button>
        <br />
        <button id="middle_left" runat="server" onserverclick="middle_left_Click">_</button>
        <button id="middle_center" runat="server" onserverclick="middle_center_Click">_</button>
        <button id="middle_right" runat="server" onserverclick="middle_right_Click">_</button>
        <br />
        <button id="bottom_left" runat="server" onserverclick="bottom_left_Click">_</button>
        <button id="bottom_center" runat="server" onserverclick="bottom_center_Click">_</button>
        <button id="bottom_right" runat="server" onserverclick="bottom_right_Click">_</button>
    </form>

    <div id="score" runat="server">

    </div>
</body>
</html>
