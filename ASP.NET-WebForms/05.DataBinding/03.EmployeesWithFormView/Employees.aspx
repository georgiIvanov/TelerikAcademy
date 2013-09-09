<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_03.EmployeesWithFormView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="EmployeeID" DataSourceID="EmployeesSqlDataSource" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" />
                <asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="EmployeesSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City] FROM [Employees]"></asp:SqlDataSource>

        <asp:FormView ID="FormView1" runat="server" DataKeyNames="EmployeeID" DataSourceID="FormViewDataSource">
            <EditItemTemplate>
                EmployeeID:
                <asp:Label ID="EmployeeIDLabel1" runat="server" Text='<%# Eval("EmployeeID") %>' />
                <br />
                LastName:
                <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                <br />
                FirstName:
                <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                <br />
                Title:
                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                <br />
                TitleOfCourtesy:
                <asp:TextBox ID="TitleOfCourtesyTextBox" runat="server" Text='<%# Bind("TitleOfCourtesy") %>' />
                <br />
                BirthDate:
                <asp:TextBox ID="BirthDateTextBox" runat="server" Text='<%# Bind("BirthDate") %>' />
                <br />
                HireDate:
                <asp:TextBox ID="HireDateTextBox" runat="server" Text='<%# Bind("HireDate") %>' />
                <br />
                Address:
                <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                <br />
                City:
                <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
                <br />
                Region:
                <asp:TextBox ID="RegionTextBox" runat="server" Text='<%# Bind("Region") %>' />
                <br />
                PostalCode:
                <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# Bind("PostalCode") %>' />
                <br />
                Country:
                <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                <br />
                HomePhone:
                <asp:TextBox ID="HomePhoneTextBox" runat="server" Text='<%# Bind("HomePhone") %>' />
                <br />
                Extension:
                <asp:TextBox ID="ExtensionTextBox" runat="server" Text='<%# Bind("Extension") %>' />
                <br />
                Photo:
                <asp:TextBox ID="PhotoTextBox" runat="server" Text='<%# Bind("Photo") %>' />
                <br />
                Notes:
                <asp:TextBox ID="NotesTextBox" runat="server" Text='<%# Bind("Notes") %>' />
                <br />
                ReportsTo:
                <asp:TextBox ID="ReportsToTextBox" runat="server" Text='<%# Bind("ReportsTo") %>' />
                <br />
                PhotoPath:
                <asp:TextBox ID="PhotoPathTextBox" runat="server" Text='<%# Bind("PhotoPath") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                LastName:
                <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                <br />
                FirstName:
                <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                <br />
                Title:
                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                <br />
                TitleOfCourtesy:
                <asp:TextBox ID="TitleOfCourtesyTextBox" runat="server" Text='<%# Bind("TitleOfCourtesy") %>' />
                <br />
                BirthDate:
                <asp:TextBox ID="BirthDateTextBox" runat="server" Text='<%# Bind("BirthDate") %>' />
                <br />
                HireDate:
                <asp:TextBox ID="HireDateTextBox" runat="server" Text='<%# Bind("HireDate") %>' />
                <br />
                Address:
                <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                <br />
                City:
                <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
                <br />
                Region:
                <asp:TextBox ID="RegionTextBox" runat="server" Text='<%# Bind("Region") %>' />
                <br />
                PostalCode:
                <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# Bind("PostalCode") %>' />
                <br />
                Country:
                <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                <br />
                HomePhone:
                <asp:TextBox ID="HomePhoneTextBox" runat="server" Text='<%# Bind("HomePhone") %>' />
                <br />
                Extension:
                <asp:TextBox ID="ExtensionTextBox" runat="server" Text='<%# Bind("Extension") %>' />
                <br />
                Photo:
                <asp:TextBox ID="PhotoTextBox" runat="server" Text='<%# Bind("Photo") %>' />
                <br />
                Notes:
                <asp:TextBox ID="NotesTextBox" runat="server" Text='<%# Bind("Notes") %>' />
                <br />
                ReportsTo:
                <asp:TextBox ID="ReportsToTextBox" runat="server" Text='<%# Bind("ReportsTo") %>' />
                <br />
                PhotoPath:
                <asp:TextBox ID="PhotoPathTextBox" runat="server" Text='<%# Bind("PhotoPath") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                EmployeeID:
                <asp:Label ID="EmployeeIDLabel" runat="server" Text='<%# Eval("EmployeeID") %>' />
                <br />
                LastName:
                <asp:Label ID="LastNameLabel" runat="server" Text='<%# Bind("LastName") %>' />
                <br />
                FirstName:
                <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Bind("FirstName") %>' />
                <br />
                Title:
                <asp:Label ID="TitleLabel" runat="server" Text='<%# Bind("Title") %>' />
                <br />
                TitleOfCourtesy:
                <asp:Label ID="TitleOfCourtesyLabel" runat="server" Text='<%# Bind("TitleOfCourtesy") %>' />
                <br />
                BirthDate:
                <asp:Label ID="BirthDateLabel" runat="server" Text='<%# Bind("BirthDate") %>' />
                <br />
                HireDate:
                <asp:Label ID="HireDateLabel" runat="server" Text='<%# Bind("HireDate") %>' />
                <br />
                Address:
                <asp:Label ID="AddressLabel" runat="server" Text='<%# Bind("Address") %>' />
                <br />
                City:
                <asp:Label ID="CityLabel" runat="server" Text='<%# Bind("City") %>' />
                <br />
                Region:
                <asp:Label ID="RegionLabel" runat="server" Text='<%# Bind("Region") %>' />
                <br />
                PostalCode:
                <asp:Label ID="PostalCodeLabel" runat="server" Text='<%# Bind("PostalCode") %>' />
                <br />
                Country:
                <asp:Label ID="CountryLabel" runat="server" Text='<%# Bind("Country") %>' />
                <br />
                HomePhone:
                <asp:Label ID="HomePhoneLabel" runat="server" Text='<%# Bind("HomePhone") %>' />
                <br />
                Extension:
                <asp:Label ID="ExtensionLabel" runat="server" Text='<%# Bind("Extension") %>' />
                <br />
                Photo:
                <asp:Label ID="PhotoLabel" runat="server" Text='<%# Bind("Photo") %>' />
                <br />
                Notes:
                <asp:Label ID="NotesLabel" runat="server" Text='<%# Bind("Notes") %>' />
                <br />
                ReportsTo:
                <asp:Label ID="ReportsToLabel" runat="server" Text='<%# Bind("ReportsTo") %>' />
                <br />
                PhotoPath:
                <asp:Label ID="PhotoPathLabel" runat="server" Text='<%# Bind("PhotoPath") %>' />
                <br />

            </ItemTemplate>
        </asp:FormView>
        <asp:SqlDataSource ID="FormViewDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Employees] WHERE ([EmployeeID] = @EmployeeID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="EmployeeID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
