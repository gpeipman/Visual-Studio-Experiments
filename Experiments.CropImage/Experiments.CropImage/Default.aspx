<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Experiments.CropImage.Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="Stylesheet" type="text/css" href="Styles/jquery.Jcrop.css" />
    <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.Jcrop.js"></script>

    <script type="text/javascript">
        var editorID = '<%= _imageEditor.ClientID %>';
        jQuery(function () {
            jQuery('#' + editorID).Jcrop({
                onChange: showCoords,
                onSelect: showCoords
            });
        });

        function showCoords(c) {
            var tdX = document.getElementById('tdX');
            var tdY = document.getElementById('tdY');
            var tdWidth = document.getElementById('tdWidth');
            var tdHeight = document.getElementById('tdHeight');

            tdX.innerHTML = c.x;
            tdY.innerHTML = c.y;
            tdWidth.innerHTML = c.w;
            tdHeight.innerHTML = c.h;

            var xField = document.getElementById('<%= _xField.ClientID %>');
            var yField = document.getElementById('<%= _yField.ClientID %>');
            var widthField = document.getElementById('<%= _widthField.ClientID %>');
            var heightField = document.getElementById('<%= _heightField.ClientID %>');

            xField.value = c.x;
            yField.value = c.y;
            widthField.value = c.w;
            heightField.value = c.h;
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Crop image example</h2>
    <p style="border:1px solid darkgray; padding:10px; width:620px;">
        This dog (and many others) were sleeping around Akropolis under the sun. Seems like 
        Zeus was at home and he likes dogs.
    </p>
    
    <div>
    <asp:Image runat="server" ID="_imageEditor" ImageUrl="Images/akropolis-doggie.jpg" />
    </div>
    <table border="0" cellpadding="2" cellspacing="0">
    <tr>
    <td>x:</td>
    <td id="tdX">-</td>
    <td>y:</td>
    <td id="tdY">-</td>
    <td>width:</td>
    <td id="tdWidth">-</td>
    <td>height:</td>
    <td id="tdHeight">-</td>
    <td><asp:Button runat="server" ID="_cropCommand" onclick="CropCommandClick" Text="Crop" /></td>
    </tr>
    </table>
 
    <input type="hidden" runat="server" id="_xField" />
    <input type="hidden" runat="server" id="_yField" />
    <input type="hidden" runat="server" id="_widthField" />
    <input type="hidden" runat="server" id="_heightField" />
</asp:Content>
