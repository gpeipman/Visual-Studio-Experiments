<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Image: Image watermark
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("ImagesMenu");%>
    
    <h2>Image watermark</h2>
    <p>Image with image watermark</p>

    <p><img src="/Image/GetImageWatermark" /></p>
</asp:Content>
