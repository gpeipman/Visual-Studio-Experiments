<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelectTree.aspx.cs" Inherits="Experiments.jQuery.Dialogs.SelectTree" %>
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
		font-size:8pt;
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
		alert("You selected: " + value + " - " + text);
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

<div id="dialog-form" title="Select user">
	<asp:TreeView ID="TreeView1" runat="server" ShowLines="True" 
		 ClientIDMode="Static" HoverNodeStyle-CssClass="SelectedNode">
		<Nodes>
			<asp:TreeNode Text="Employees" Value="Employees" SelectAction="None">
				<asp:TreeNode Text="Berlin department" Value="Berlin" SelectAction="None">
					<asp:TreeNode Text="Hans Schmidt" Value="hschmidt@berlin" />
					<asp:TreeNode Text="Helga Kraft" Value="kraft@berlin" />
				</asp:TreeNode>
				<asp:TreeNode Text="London department" Value="London" SelectAction="None">
					<asp:TreeNode Text="Robert Brown" Value="brown@london" />
					<asp:TreeNode Text="Sally Smith" Value="sallys@london" />
				</asp:TreeNode>
			</asp:TreeNode>
		</Nodes>
	</asp:TreeView>
	&nbsp;
</div>

<button id="pick-node">Pick user</button>
</asp:Content>
