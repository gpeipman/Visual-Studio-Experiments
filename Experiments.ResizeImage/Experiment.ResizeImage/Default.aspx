<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Experiments.ResizeImage.Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Resize image, scale factor = 0.1
    </h2>
    <asp:Label runat="server" ID="ErrorLabel"></asp:Label>
    <p>
        <asp:Button runat="server" ID="CreateThumbnailButton" Text="Create thumbnail" OnClick="CreateThumbnailButtonClick" />
    </p>    
</asp:Content>
