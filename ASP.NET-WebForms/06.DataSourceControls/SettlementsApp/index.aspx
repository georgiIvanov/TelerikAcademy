<%@  Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SettlementsApp.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="ContinentsList" runat="server" DataSourceID="ContinentsRepo" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ContinentsList_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
            <asp:ObjectDataSource ID="ContinentsRepo" runat="server" SelectMethod="GetContinents" TypeName="SettlementsApp.ContinentsRepository"></asp:ObjectDataSource>
            <asp:GridView ID="CountriesGrid" runat="server" AutoGenerateColumns="False" DataSourceID="CountriesRepo" AllowPaging="True" AllowSorting="True" DataKeyNames="Id" ShowFooter="true">
                <Columns>
                    <asp:TemplateField FooterStyle-CssClass="GridFooter">
                        
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Button   CommandName="Insert" ID="ButtonAdd" runat="server"
                                Text="Insert Row" OnClick="ButtonAdd_Click" />
                            
                            <asp:TextBox CssClass="grid_input" ID="tbgridName" runat="server" Columns="3" AutoPostBack="true" OnPreRender="tbgridName_PreRender"></asp:TextBox>
                            <asp:TextBox CssClass="grid_input" ID="tb_grid_Language" runat="server" AutoPostBack="true" Columns="3" OnPreRender="tb_grid_Language_PreRender"></asp:TextBox>
                            <asp:TextBox CssClass="grid_input" ID="tb_grid_Population" runat="server" AutoPostBack="true" Columns="3" OnPreRender="tb_grid_Population_PreRender"></asp:TextBox>
                             <asp:TextBox CssClass="grid_input" ID="tb_grid_ContentId" runat="server" AutoPostBack="true" Columns="3" OnPreRender="tb_grid_ContentId_PreRender" ></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" ShowEditButton="true" />
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"  />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                    <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                    

                </Columns>


            </asp:GridView>
            <asp:ObjectDataSource ID="CountriesRepo" runat="server" SelectMethod="GetCountriesInContinent" TypeName="SettlementsApp.CountriesRepository" SortParameterName="sortColumnBy" InsertMethod="Insert" UpdateMethod="Update">
                <InsertParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Language" Type="String" />
                    <asp:Parameter Name="Population" Type="Int32" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="ContinentsList" Name="selectedContinentId" PropertyName="SelectedValue" Type="Int32" DefaultValue="" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Language" Type="String" />
                    <asp:Parameter Name="Population" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>


            <asp:ListView ID="TownsView" runat="server" DataSourceID="TownRepo" InsertItemPosition="LastItem" DataKeyNames="Id">
                <AlternatingItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
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
                        <td>
                            <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                    <tr runat="server" style="">
                                        <th runat="server"></th>
                                        <th runat="server">Id</th>
                                        <th runat="server">Name</th>
                                        <th runat="server">Population</th>
                                        <th runat="server">Country</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="TownRepo" runat="server" SelectMethod="GetTowns" TypeName="SettlementsApp.TownsRepository" InsertMethod="Insert" UpdateMethod="Update">
                <InsertParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="population" Type="Int32" />
                    <asp:Parameter Name="country" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="CountriesGrid" Name="selectedCountryId" PropertyName="SelectedValue" Type="Int32" DefaultValue="" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Population" Type="Int32" />
                    <asp:Parameter Name="Country" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
