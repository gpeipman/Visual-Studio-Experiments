<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Image: Cropped
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("ImagesMenu");%>
    
    <h2>Horizontal flip</h2>
    <p>Horizontal flip of image</p>

    <p><img src="/Image/GetHorizontalFlip" /></p>
</asp:Content>
