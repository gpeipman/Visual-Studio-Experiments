<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Heineken
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTitleContent" runat="server">
    Heineken
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p><img src="<%= Url.Content("~/img/heineken-small.png") %>" alt="Heineken" style="float:left; margin-right:5px; margin-bottom:5px;" />
        Heineken is a 5% abv pale lager, made by Heineken International since 1873. 
        It is available in a 4.3% alcohol by volume, in countries such as Ireland. 
        It is the flagship product of the company and is made of purified water, 
        malted barley, hops, and yeast.
    </p>

</asp:Content>