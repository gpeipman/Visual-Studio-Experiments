<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Image: Cropped
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("ImagesMenu");%>
    
    <h2>Cropped image</h2>
    <p>This version of image is cropped by 50px from all directions.</p>

    <p><img src="/Image/GetCropped" /></p>
</asp:Content>
