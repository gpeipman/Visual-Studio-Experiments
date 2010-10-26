<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Amstel
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageTitleContent" runat="server">
    Amstel
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p><img src="<%= Url.Content("~/img/amstel-small.png") %>" alt="Heineken" style="float:left; margin-right:5px; margin-bottom:5px;" />
    Heineken offers several beers under the Amstel brand.[1] Amstel Lager uses predominantly light pilsner malt, 
    although some dark malt is also used. It is sold in 75 countries. Amstel Light is a 3.5% abv pale lager. 
    Amstel 1870 is a slightly dark 5% abv lager.
    </p>
</asp:Content>