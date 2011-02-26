<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WIFControlsApp._Default" %>

<%@ Register assembly="Microsoft.IdentityModel, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="Microsoft.IdentityModel.Web.Controls" tagprefix="wif" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
        <wif:FederatedPassiveSignIn ID="FederatedPassiveSignIn1" runat="server" RequireHttps="False" 
            VisibleWhenSignedIn="False" 
            UseFederationPropertiesFromConfiguration="True" 
            DestinationPageUrl="~/Secure/" ErrorAction="RedirectToLoginPage">
        </wif:FederatedPassiveSignIn>
    </p>
</asp:Content>
