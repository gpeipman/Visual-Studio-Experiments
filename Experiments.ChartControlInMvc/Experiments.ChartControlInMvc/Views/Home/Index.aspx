<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Enterprise dashboard</h2>
    <p>
        <img 
            src="<%= Url.Action("GetChart")%>" 
            alt="Enquiries during last three months"  
            title="Enquiries during last three months" 
        />
    </p>
</asp:Content>
