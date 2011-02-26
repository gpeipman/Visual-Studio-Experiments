// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace Microsoft.Samples.DPE.Identity.Controls
{
    using System.Web.UI.Design;

    public class SecurityTokenVisualizerControlDesigner : ControlDesigner
    {
        public override bool AllowResize
        {
            get
            {
                return false;
            }
        }

        public override string GetDesignTimeHtml()
        {
            this.ViewControl = new System.Web.UI.WebControls.Image()
                                   {
                                       ImageUrl = this.ViewControl.Page.ClientScript.GetWebResourceUrl(typeof(SecurityTokenVisualizerControl), "Microsoft.Samples.DPE.Identity.Controls.Content.images.icon.png")
                                   };

            return base.GetDesignTimeHtml();
        }
    }
}