<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Image Workshop
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <script type="text/javascript">
        function updateImage() {
            var req = '/ImageWorkshop/GetImage?';
            var query = '';

            if ($('#HorizontalFlip').is(':checked'))
                query += '&horizontalFlip=1';

            req += query.substr(1);

            $('#image').attr("src", req);
        }
    </script>

    <h2>Image Workshop</h2>

    <% using(Html.BeginForm()) { %>
        <table border="0" cellpadding="0" cellspacing="5">
        <tr>
        <td valign="top" rowspan="10">
            <img src="/ImageWorkshop/GetImage"  id="image" alt="" />
        </td>
        <td valign="middle"><input type="checkbox" id="HorizontalFlip" value="1" />  Flip horizontally</td>
        </tr>
        <tr>
        <td valign="middle"><input type="checkbox" id="VerticalFlip" value="true" />  Flip vertically</td>
        </tr>
        <tr>
        <td><input type="button" value="Preview" onclick="updateImage()" /></td>
        </tr>
        </table>
    <% } %>
</asp:Content>
