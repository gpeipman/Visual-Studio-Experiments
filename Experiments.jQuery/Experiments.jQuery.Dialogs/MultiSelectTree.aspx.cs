using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Experiments.jQuery.Dialogs
{
    public partial class MultiSelectTree : System.Web.UI.Page
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
            if (IsPostBack)
                return;

            SetSelectNodeUrls(TreeView1.Nodes);
        }

        private void SetSelectNodeUrls(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.NavigateUrl = "javascript:selectNode('" + node.Value + "','" + node.Text + "');";
                SetSelectNodeUrls(node.ChildNodes);
            }        
        }
    }
}