<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_01.RndNumsWithHtmlControls.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #submit {
            height: 18px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <input type="number" runat="server" id="input_first_number" />
        <input type="number" runat="server" id="input_second_number" />

        <button runat="server" id="submit" onserverclick="submit_ServerClick" value="Submit" />
        <br />

        <label id="outputLabel" runat="server"></label>
    </form>
</body>
</html>
