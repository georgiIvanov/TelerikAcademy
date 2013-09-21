<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_04.StudentsForm.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="txt_firstName">First Name:</label>
            <asp:TextBox ID="txt_firstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_firstName" ErrorMessage="Please enter first name." ValidationGroup="student"></asp:RequiredFieldValidator>
            <br />
            <label for="txt_lastName">Last Name:</label>
            <asp:TextBox ID="txt_lastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_lastName" ErrorMessage="Please enter last name." ValidationGroup="student"></asp:RequiredFieldValidator>
            <br />
            <label for="num_facultyNumber">Faculty Number:</label>
            <asp:TextBox ID="num_facultyNumber" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="num_facultyNumber" ErrorMessage="Please enter faculty number." ValidationGroup="student"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="num_facultyNumber" ErrorMessage="Please enter a valid faculty number." Operator="DataTypeCheck" Type="Integer" ValidationGroup="student"></asp:CompareValidator>
            <br />

            <label for="dropList_Universities">Choose University:</label>
            <asp:DropDownList ID="dropList_Universities" runat="server">
                <asp:ListItem Text="Select University" Value="" Selected="True" />
                <asp:ListItem Text="СУ" Value="СУ" />
                <asp:ListItem Text="ТУ - София" Value="ТУ - София" />
                <asp:ListItem Text="ТУ - Пловдив" Value="ТУ - Пловдив" />
                <asp:ListItem Text="Нов Български" Value="Нов Български" />
            </asp:DropDownList>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select university." ControlToValidate="dropList_Universities" ValidationGroup="student"></asp:RequiredFieldValidator>

            <br />
            
            <label for="dropList_Specialties">Choose Specialty:</label>
            <asp:DropDownList ID="dropList_Specialties" runat="server">
                <asp:ListItem Text="Select Specialty" Value="" Selected="True" />
                <asp:ListItem Text="Тракторизъм" Value="Тракторизъм" />
                <asp:ListItem Text="Сектантство" Value="Сектантство" />
                <asp:ListItem Text="Сатанизъм" Value="Сатанизъм" />
                <asp:ListItem Text="Комунизъм" Value="Комунизъм" />
            </asp:DropDownList>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please select specialty." ControlToValidate="dropList_Specialties" ValidationGroup="student"></asp:RequiredFieldValidator>

            <br />
            <asp:Button ID="btn_submitForm" runat="server" Text="Submit" OnClick="btn_submitForm_Click" ValidateRequestMode="Enabled" ValidationGroup="student" />

            <br />
            <asp:PlaceHolder ID="studentHolder" runat="server" />


        </div>
    </form>
</body>
</html>
