<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="_02.DisplayFromDb.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Return</asp:LinkButton>
    <div>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataKeyNames="EmployeeID" DataSourceID="GetDetailsForEmployee">
            <Fields>
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeID" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" />
                <asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="ReportsTo" HeaderText="ReportsTo" SortExpression="ReportsTo" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                <asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension" />
                <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                <asp:BoundField DataField="PhotoPath" HeaderText="PhotoPath" SortExpression="PhotoPath" />
            </Fields>

        </asp:DetailsView>

        <asp:SqlDataSource ID="GetDetailsForEmployee" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [EmployeeID], [LastName], [TitleOfCourtesy], [FirstName], [Title], [BirthDate], [HireDate], [Address], [ReportsTo], [Notes], [Photo], [Extension], [HomePhone], [Country], [PostalCode], [City], [Region], [PhotoPath] FROM [Employees] WHERE ([EmployeeID] = @EmployeeID)">
            <SelectParameters>
                <asp:QueryStringParameter Name="EmployeeID" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
