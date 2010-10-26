<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Beer Index
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PageTitleContent" runat="server">
	Beer Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<ul data-role="listview" data-inset="true" data-theme="c" data-dividertheme="b">
	<li><%: Html.ActionLink("Heineken", "Heineken", "Home") %></li>
	<li><%: Html.ActionLink("Amstel", "Amstel", "Home")  %></li>
	</ul>
	
</asp:Content>