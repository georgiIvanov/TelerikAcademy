<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_04.DisplayingViaRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://localhost:1047/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>ID</th>
                            <th>FirstName</th>
                            <th>LastName</th>
                            <th>Title</th>
                            <th>TitleOfCourtesy</th>
                            <th>BirthDate</th>
                            <th>HireDate</th>
                            <th>Address</th>
                            <th>City</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "EmployeeID") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "FirstName") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "LastName") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Title") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "TitleOfCourtesy") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "BirthDate") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "HireDate") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Address") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "City") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

            <asp:ListView ID="ListView1" runat="server" DataKeyNames="EmployeeID" DataSourceID="SqlDataSource1">
                <AlternatingItemTemplate>
                    <tr style="background-color:#FFF8DC;">
                        <td>
                            <asp:Label ID="EmployeeIDLabel" runat="server" Text='<%# Eval("EmployeeID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TitleOfCourtesyLabel" runat="server" Text='<%# Eval("TitleOfCourtesy") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                        </td>
                        <td>
                            <asp:Label ID="BirthDateLabel" runat="server" Text='<%# Eval("BirthDate") %>' />
                        </td>
                        <td>
                            <asp:Label ID="HireDateLabel" runat="server" Text='<%# Eval("HireDate") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color:#008A8C;color: #FFFFFF;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:Label ID="EmployeeIDLabel1" runat="server" Text='<%# Eval("EmployeeID") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TitleOfCourtesyTextBox" runat="server" Text='<%# Bind("TitleOfCourtesy") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BirthDateTextBox" runat="server" Text='<%# Bind("BirthDate") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="HireDateTextBox" runat="server" Text='<%# Bind("HireDate") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TitleOfCourtesyTextBox" runat="server" Text='<%# Bind("TitleOfCourtesy") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="BirthDateTextBox" runat="server" Text='<%# Bind("BirthDate") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="HireDateTextBox" runat="server" Text='<%# Bind("HireDate") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color:#DCDCDC;color: #000000;">
                        <td>
                            <asp:Label ID="EmployeeIDLabel" runat="server" Text='<%# Eval("EmployeeID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TitleOfCourtesyLabel" runat="server" Text='<%# Eval("TitleOfCourtesy") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                        </td>
                        <td>
                            <asp:Label ID="BirthDateLabel" runat="server" Text='<%# Eval("BirthDate") %>' />
                        </td>
                        <td>
                            <asp:Label ID="HireDateLabel" runat="server" Text='<%# Eval("HireDate") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                        <th runat="server">EmployeeID</th>
                                        <th runat="server">LastName</th>
                                        <th runat="server">FirstName</th>
                                        <th runat="server">TitleOfCourtesy</th>
                                        <th runat="server">Title</th>
                                        <th runat="server">BirthDate</th>
                                        <th runat="server">HireDate</th>
                                        <th runat="server">Address</th>
                                        <th runat="server">City</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                <asp:DataPager ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                        <td>
                            <asp:Label ID="EmployeeIDLabel" runat="server" Text='<%# Eval("EmployeeID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TitleOfCourtesyLabel" runat="server" Text='<%# Eval("TitleOfCourtesy") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                        </td>
                        <td>
                            <asp:Label ID="BirthDateLabel" runat="server" Text='<%# Eval("BirthDate") %>' />
                        </td>
                        <td>
                            <asp:Label ID="HireDateLabel" runat="server" Text='<%# Eval("HireDate") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [TitleOfCourtesy], [Title], [BirthDate], [HireDate], [Address], [City] FROM [Employees]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
