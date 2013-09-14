<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="_01.RegisterForm.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />

</head>
<body>
    <form id="RegistrationForm" runat="server">
        <asp:ScriptManager ID="sm1" runat="server">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
            </Scripts>
        </asp:ScriptManager>

        <div id="registrationWrapper">
            <div>
                <asp:Label runat="server" AssociatedControlID="tb_Username">Username:</asp:Label>
                <asp:TextBox ID="tb_Username" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ErrorMessage="Username is required." Text="*" ControlToValidate="tb_Username"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="tb_Password">Password:</asp:Label>
                <asp:TextBox ID="tb_Password" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password is required." Text="*" ControlToValidate="tb_Password"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="tb_ConfirmPassword">ConfirmPassword:</asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" runat="server" ErrorMessage="Confirm password is required." Text="*" ControlToValidate="tb_ConfirmPassword"></asp:RequiredFieldValidator>
                <asp:TextBox ID="tb_ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidatorPasswords" runat="server" ErrorMessage="Passwords don't match." ControlToCompare="tb_Password" Text="*" ControlToValidate="tb_ConfirmPassword" />
               
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="tb_FirstName">First Name:</asp:Label>
                <asp:TextBox ID="tb_FirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" ErrorMessage="First Name is required." Text="*" ControlToValidate="tb_FirstName"></asp:RequiredFieldValidator>

            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="tb_LastName">Last Name:</asp:Label>
                <asp:TextBox ID="tb_LastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ErrorMessage="Last Name is required." Text="*" ControlToValidate="tb_LastName"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="tb_Age">Age:</asp:Label>
                <asp:TextBox ID="tb_Age" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RangeValidator CssClass="validator" ID="RangeValidatorAge" runat="server" ErrorMessage="Age must be between 18 and 81" ControlToValidate="tb_Age" MaximumValue="81" MinimumValue="18" Text="*"></asp:RangeValidator>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" runat="server" ErrorMessage="Age is required." Text="*" ControlToValidate="tb_Age"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="tb_Email">Email:</asp:Label>
                <asp:TextBox ID="tb_Email" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Email is required." Text="*" ControlToValidate="tb_Email"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Not a valid email." Text="*" ValidationExpression="\b[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\b" ControlToValidate="tb_Email"></asp:RegularExpressionValidator>
                
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="tb_Address">Address:</asp:Label>
                <asp:TextBox ID="tb_Address" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ErrorMessage="Address is required." Text="*" ControlToValidate="tb_Address"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="tb_PhoneNumber">Phone number:</asp:Label>
                <asp:TextBox ID="tb_PhoneNumber" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" runat="server" ErrorMessage="Not a valid phone number." Text="*" ValidationExpression="^\+?\d+(-\d+)*$" ControlToValidate="tb_PhoneNumber"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" ErrorMessage="Phone is required." Text="*" ControlToValidate="tb_PhoneNumber"></asp:RequiredFieldValidator>
            </div>
            <asp:ValidationSummary ID="ValidationSummary" DisplayMode="BulletList" runat="server" />
            <asp:Button runat="server" ID="Submit" Text="Submit" OnClick="Submit_Click" />
        </div>
    </form>
</body>
</html>
