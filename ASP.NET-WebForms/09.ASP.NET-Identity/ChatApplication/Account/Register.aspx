<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebFormsTemplate.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>       
    <//hgroup>
    <p class="text-error">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <fieldset class="form-horizontal">
        <legend>Create a new account.</legend>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="control-label">User name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="UserName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-error" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-error" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="control-label">Confirm password</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="tb_FirstName" CssClass="control-label">First Name:</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="tb_FirstName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tb_FirstName"
                    CssClass="text-error" ErrorMessage="The first name field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="tb_LastName" CssClass="control-label">Last Name:</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="tb_LastName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tb_FirstName"
                    CssClass="text-error" ErrorMessage="The last name field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="tb_Email" CssClass="control-label">Email:</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="tb_Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tb_Email"
                    CssClass="text-error" ErrorMessage="The Email field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="dl_Roles" CssClass="control-label">Role:</asp:Label>
            <div class="controls">
                <asp:DropDownList ID="dl_Roles" runat="server">
                    <asp:ListItem Selected="True" Text="User" Value="User" />
                    <asp:ListItem  Text="Moderator" Value="Moderator" />
                    <asp:ListItem  Text="Admin" Value="Admin" />
                </asp:DropDownList>
            </div>
        </div>
        
        <div class="form-actions no-color">
            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn" />
        </div>
    </fieldset>

</asp:Content>
