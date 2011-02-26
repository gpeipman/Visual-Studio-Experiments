<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Token.aspx.cs" Inherits="WIFControlsApp.About" %>

<%@ Register assembly="SecurityTokenVisualizerControl" namespace="Microsoft.Samples.DPE.Identity.Controls" tagprefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About
    </h2>
    <p>
        <cc1:SecurityTokenVisualizerControl ID="SecurityTokenVisualizerControl1" 
            runat="server" />
    </p>
</asp:Content>
