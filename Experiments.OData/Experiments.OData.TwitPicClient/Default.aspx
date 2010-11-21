<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Experiments.OData.TwitPicClient.Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to my twitpic client
    </h2>
    <hr />

    <div class="left-menu">
        <asp:TextBox runat="server" ID="filterField" />
        <asp:Button runat="server" ID="filterButton" Text="Go" /><br />
        <a href="?user=gpeipman">gpeipman</a><br />
        <a href="?user=tbronzin">tbronzin</a><br />
        <a href="?user=mssinergija">mssinergija</a>
    </div>

    <div class="images-block">
    <div class="user-pics-label">Pics by: <asp:Label runat="server" ID="picsByLabel"></asp:Label></div>
    <asp:Repeater runat="server" ID="imagesRepeater">
        <ItemTemplate>
            <div class="twitpic-image">
                <a href="<%# Eval("Url") %>"><img src="http://twitpic.com/show/thumb/<%# Eval("ShortId") %>.<%# Eval("Type") %>" width="75" style="float:left" /></a>
                <%# Eval("Message") %>
            </div><br />
        </ItemTemplate>
    </asp:Repeater>
    </div>
</asp:Content>
