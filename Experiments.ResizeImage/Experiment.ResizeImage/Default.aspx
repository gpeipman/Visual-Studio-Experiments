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
        <asp:Button runat="server" ID="CreateScaleThumbnailButton" Text="Create thumbnail" OnClick="CreateScaleThumbnailButtonClick" />
    </p>
    <h2>
        Resize image, square a = 100px
    </h2>
    <p>
        <asp:Button runat="server" ID="CreateSquareThumbnailButton" Text="Create thumbnail" OnClick="CreateSquareThumbnailButtonClick" />
    </p>
</asp:Content>
