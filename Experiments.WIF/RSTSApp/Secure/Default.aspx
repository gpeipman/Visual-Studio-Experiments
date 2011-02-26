<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RSTSApp.Secure.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <tr>
        <td></td>
        <td><%# Eval("ClaimType") %></td>
        </tr>
        <tr>
        <td></td>
        <td><%# Eval("Value") %></td>
        </tr>
        <tr>
        <td></td>
        <td><%# Eval("Issuer") %></td>
        </tr>
        <tr>
        <td></td>
        <td><%# Eval("OriginalIssuer") %></td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>

</asp:Content>
