<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Image: Text watermark
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("ImagesMenu");%>
    
    <h2>Text watermark</h2>
    <p>Image with text watermark.</p>

    <p><img src="/Image/GetTextWatermark" /></p>
</asp:Content>
