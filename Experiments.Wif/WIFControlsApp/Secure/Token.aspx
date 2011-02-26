<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Token.aspx.cs" Inherits="WIFControlsApp.About" %>

<%@ Register assembly="SecurityTokenVisualizerControl" namespace="Microsoft.Samples.DPE.Identity.Controls" tagprefix="cc1" %>

<%@ Register assembly="Microsoft.IdentityModel, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="Microsoft.IdentityModel.Web.Controls" tagprefix="wif" %>

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
