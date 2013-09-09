<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarSearch.aspx.cs" Inherits="_01.SearchControls.CarSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:DropDownList runat="server" ID="producersList" DataTextField="Name" OnSelectedIndexChanged="producersList_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="true">
                <asp:ListItem>Select Item</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="modelsList">
            </asp:DropDownList>

            <asp:CheckBoxList ID="ExtrasCheckBoxList" runat="server" DataTextField ="Name">

            </asp:CheckBoxList>

            <asp:RadioButtonList ID="EngineTypesRadioList" runat="server"></asp:RadioButtonList>

            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
        </div>
        
    </form>

    <asp:Literal runat="server" ID="ShowSubmitted">

    </asp:Literal>

</body>
</html>
