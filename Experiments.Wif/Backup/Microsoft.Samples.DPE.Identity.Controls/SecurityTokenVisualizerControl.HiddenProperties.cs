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
    using System.ComponentModel;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class SecurityTokenVisualizerControl
    {
        [Browsable(false)]
        public override bool EnableViewState
        {
            get
            {
                return base.EnableViewState;
            }

            set
            {
                base.EnableViewState = value;
            }
        }

        [Browsable(false)]
        public override bool Visible
        {
            get
            {
                return base.Visible;
            }

            set
            {
                base.Visible = value;
            }
        }

        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
            }
        }

        [Browsable(false)]
        public override Color BorderColor
        {
            get
            {
                return base.BorderColor;
            }

            set
            {
                base.BorderColor = value;
            }
        }

        [Browsable(false)]
        public override BorderStyle BorderStyle
        {
            get
            {
                return base.BorderStyle;
            }

            set
            {
                base.BorderStyle = value;
            }
        }

        [Browsable(false)]
        public override string AccessKey
        {
            get
            {
                return base.AccessKey;
            }

            set
            {
                base.AccessKey = value;
            }
        }

        [Browsable(false)]
        public override Unit BorderWidth
        {
            get
            {
                return base.BorderWidth;
            }

            set
            {
                base.BorderWidth = value;
            }
        }

        [Browsable(false)]
        public override ControlCollection Controls
        {
            get
            {
                return base.Controls;
            }
        }

        [Browsable(false)]
        public override string CssClass
        {
            get
            {
                return base.CssClass;
            }

            set
            {
                base.CssClass = value;
            }
        }

        [Browsable(false)]
        public override bool Enabled
        {
            get
            {
                return base.Enabled;
            }

            set
            {
                base.Enabled = value;
            }
        }

        [Browsable(false)]
        public override bool EnableTheming
        {
            get
            {
                return base.EnableTheming;
            }

            set
            {
                base.EnableTheming = value;
            }
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
            }
        }

        [Browsable(false)]
        public override Unit Height
        {
            get
            {
                return base.Height;
            }

            set
            {
                base.Height = value;
            }
        }

        [Browsable(false)]
        public override short TabIndex
        {
            get
            {
                return base.TabIndex;
            }

            set
            {
                base.TabIndex = value;
            }
        }

        [Browsable(false)]
        public override string ToolTip
        {
            get
            {
                return base.ToolTip;
            }

            set
            {
                base.ToolTip = value;
            }
        }

        [Browsable(false)]
        public override string SkinID
        {
            get
            {
                return base.SkinID;
            }

            set
            {
                base.SkinID = value;
            }
        }

        [Browsable(false)]
        public override Unit Width
        {
            get
            {
                return base.Width;
            }

            set
            {
                base.Width = value;
            }
        }
    }
}