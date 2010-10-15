<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Image: Resized
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("ImagesMenu");%>
    
    <h2>Resized image</h2>
    <p>Image resized to 200x200 px</p>

    <p><img src="/Image/GetResized" /></p>
</asp:Content>
