<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkMenu.ascx.cs" Inherits="MenuLinks.LinkMenu" %>



<ul class="aspLinkMenu">

    <asp:DataList ID="MenuList" runat="server">
        <ItemTemplate>
            <a class="aspLinkMenuOption" href='<%# Eval("Url") %>' style='color:<%# Eval("FontColor")  %>'>
                <%# Eval("Name") %>
            </a>
        </ItemTemplate>
    </asp:DataList>
</ul>
