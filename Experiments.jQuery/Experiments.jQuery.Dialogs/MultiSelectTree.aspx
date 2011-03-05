<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiSelectTree.aspx.cs" Inherits="Experiments.jQuery.Dialogs.MultiSelectTree" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    #dialog-form
    {
        overflow: hidden;
    }
    #TreeView1
    {
        border: 1px solid lightgrey;
        height: 80%;
        overflow: scroll;
        overflow-x: hidden;
    }
    .SelectedNode
    {
        border: 1px solid darkgray;
        background-color: whitesmoke;
    }
</style>
<script type="text/javascript">

    function selectNode(value, text) {
        $("#dialog-form").dialog("close");
        alert(value);
        return undefined;
    }

    $(function () {

        $("#dialog-form").dialog({
            autoOpen: false,
            modal: true
        });

        $("#pick-node")
			.button()
			.click(function () {
			    $("#dialog-form").dialog("open");
			    return false;
			});

    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="dialog-form" title="Create new user">

        <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" ClientIDMode="Static" HoverNodeStyle-CssClass="SelectedNode">
        <Nodes>
            <asp:TreeNode Text="Root" 
                Value="Root">
                <asp:TreeNode Text="Child1" Value="Child1"></asp:TreeNode>
                <asp:TreeNode Text="Child2" Value="Child2"></asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>
    &nbsp;
</div>

<button id="pick-node">Pick node</button>
</asp:Content>
