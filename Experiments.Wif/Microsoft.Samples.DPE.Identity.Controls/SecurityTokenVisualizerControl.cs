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
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using Microsoft.IdentityModel.Claims;
    using Microsoft.Samples.DPE.Identity.Controls.Properties;
    using TokenVisualizers;

    [NonVisualControl, Bindable(false)]
    [ToolboxData("<{0}:SecurityTokenVisualizerControl runat=server></{0}:SecurityTokenVisualizerControl>")]
    [ToolboxBitmap(typeof(Microsoft.Samples.DPE.Identity.Controls.SecurityTokenVisualizerControl), "icon.bmp")]
    [Designer(typeof(SecurityTokenVisualizerControlDesigner))]
    public partial class SecurityTokenVisualizerControl : WebControl
    {
        private const int TableColumnsQuantity = 4;

        protected override void OnPreRender(System.EventArgs e)
        {
            this.RegisterCssLink();

            base.OnPreRender(e);

            this.Page.ClientScript.RegisterClientScriptResource(typeof(SecurityTokenVisualizerControl), "Microsoft.Samples.DPE.Identity.Controls.Content.scripts.SecurityTokenVisualizer.js");
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (this.DesignMode)
            {
                return;
            }

            if (this.ProcessCertificateDownloadRequest())
            {
                return;
            }

            string divId = string.Format(CultureInfo.InvariantCulture, "{0}_div", this.ID);

            HtmlGenericControl container = new HtmlGenericControl("div") { ID = divId };
            
            ClientScriptManager clientScriptManager = this.Page.ClientScript;
            HtmlImage controlImage = new HtmlImage
            {
                ID = string.Format(CultureInfo.CurrentUICulture, "STVC{0}", Guid.NewGuid()),
                Src = clientScriptManager.GetWebResourceUrl(typeof(SecurityTokenVisualizerControl), "Microsoft.Samples.DPE.Identity.Controls.Content.images.icon.png"),
                Alt = Resources.SecurityTokenVisualizer,
            };
            
            controlImage.Attributes["title"] = Resources.SecurityTokenVisualizer;

            HtmlControl tokenVisualizerHeader = this.CreateCollapsableHeader(controlImage, container, false /* Expanded as Default */);

            if (this.Font == null || string.IsNullOrEmpty(this.Font.Name))
            {
                container.Style["font-family"] = "Arial, Consolas, Segoe UI";
                tokenVisualizerHeader.Style["font-family"] = "Arial, Consolas, Segoe UI";
            }
            if (this.Font == null || this.Font.Size.IsEmpty)
            {
                container.Style["font-size"] = "small";
                tokenVisualizerHeader.Style["font-size"] = "small";
            }

            var containerRounded = this.AddContainerRounded(container);

            if (Thread.CurrentPrincipal.Identity.IsAuthenticated && Thread.CurrentPrincipal.Identity is IClaimsIdentity)
            {   
                AddClaimsTable(containerRounded);
                containerRounded.Controls.Add(new HtmlGenericControl() { InnerHtml = "&nbsp;" });
                this.AddSamlTokenTable(containerRounded);
            }
            else
            {
                AddNotAuthenticatedUserTable(containerRounded);
            }

            tokenVisualizerHeader.RenderControl(writer);

            container.RenderControl(writer);

            base.RenderContents(writer);
        }

        private static HtmlTable CreateTable(HtmlControl container)
        {
            HtmlTable table = new HtmlTable();
            table.Attributes["class"] = "TokenVisualizerTable";
            container.Controls.Add(table);

            return table;
        }

        private static void AddNotAuthenticatedUserTable(HtmlControl container)
        {
            HtmlTable table = CreateTable(container);

            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell() { InnerText = Resources.NotAuthenticatedUser });
            row.Attributes["class"] = "NotAuthenticatedUser";
            table.Rows.Add(row);
        }

        private static void AddClaimsTable(HtmlControl container)
        {
            HtmlTable table = CreateTable(container);

            HtmlTableRow row;

            AddTableSectionHeader(table, Resources.IssuedIdentity, "((IClaimsPrincipal)Thread.CurrentPrincipal).Identities[0].Claims");
            AddColumnHeadersToTable(table, new[] { Resources.ClaimTypeColumnHeader, Resources.ClaimValueColumnHeader, Resources.ClaimIssuerColumnHeader, Resources.ClaimOriginalIssuerColumnHeader });

            IClaimsPrincipal principal = (IClaimsPrincipal)Thread.CurrentPrincipal;
            foreach (Claim claim in principal.Identities[0].Claims)
            {
                row = new HtmlTableRow();

                row.Cells.Add(new HtmlTableCell { InnerText = claim.ClaimType });
                row.Cells.Add(new HtmlTableCell { InnerText = claim.Value });
                row.Cells.Add(new HtmlTableCell { InnerText = claim.Issuer });
                row.Cells.Add(new HtmlTableCell { InnerText = claim.OriginalIssuer });

                table.Rows.Add(row);
            }
            
            //if (principal.Identities[0].Delegate != null)
            //{
            //    AddTableSectionHeader(table, Resources.DelegatedIdentity, "((IClaimsPrincipal)Thread.CurrentPrincipal).Identities[0].Delegate.Claims");
            //    AddColumnHeadersToTable(table, new[] { Resources.ClaimTypeColumnHeader, Resources.ClaimValueColumnHeader, Resources.ClaimIssuerColumnHeader, Resources.ClaimOriginalIssuerColumnHeader });

            //    foreach (Claim delegatedClaim in principal.Identities[0].Delegate.Claims)
            //    {
            //        row = new HtmlTableRow();

            //        row.Cells.Add(new HtmlTableCell { InnerText = delegatedClaim.ClaimType });
            //        row.Cells.Add(new HtmlTableCell { InnerText = delegatedClaim.Value });
            //        row.Cells.Add(new HtmlTableCell { InnerText = delegatedClaim.Issuer });
            //        row.Cells.Add(new HtmlTableCell { InnerText = delegatedClaim.OriginalIssuer });

            //        table.Rows.Add(row);
            //    }
            //}
        }

        private static void AddColumnHeadersToTable(HtmlTable table, IEnumerable<string> headersText)
        {
            HtmlTableRow row = new HtmlTableRow();

            foreach (string headerText in headersText)
            {
                HtmlTableCell columnHeaderCell = new HtmlTableCell { InnerText = headerText };
                columnHeaderCell.Attributes["class"] = "TokenVisualizerColumnHeader";
                if (headersText.Count() < TableColumnsQuantity && headersText.Last() == headerText)
                {
                    columnHeaderCell.ColSpan = 1 + (TableColumnsQuantity - headersText.Count());
                }

                row.Cells.Add(columnHeaderCell);
            }

            table.Rows.Add(row);
        }

        private static void AddTableSectionHeader(HtmlTable table, string text, string tooltip)
        {
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell sectionTitleCell = new HtmlTableCell { ColSpan = TableColumnsQuantity, InnerText = text };
            sectionTitleCell.Attributes["class"] = "ClaimsSectionTitle";
            if (!string.IsNullOrEmpty(tooltip))
            {
                sectionTitleCell.Attributes["title"] = tooltip;
            }

            row.Cells.Add(sectionTitleCell);
            table.Rows.Add(row);
        }

        private static void AddTokenProperty(HtmlTable table, string propertyName, string propertyValue)
        {
            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell() { InnerHtml = propertyName });
            row.Cells.Add(new HtmlTableCell() { InnerHtml = propertyValue, ColSpan = TableColumnsQuantity - 1 });
            table.Rows.Add(row);
        }

        private HtmlControl AddContainerRounded(HtmlGenericControl container)
        {
            HtmlGenericControl tokenVisualizerTableContainerRounded = new HtmlGenericControl("div");
            WebControl cornerTopLeft = new WebControl(HtmlTextWriterTag.Div);
            WebControl cornerTopRight = new WebControl(HtmlTextWriterTag.Div);

            HtmlGenericControl lateralBorders = new HtmlGenericControl("div");
            HtmlGenericControl containerControl = new HtmlGenericControl("div");

            WebControl cornerBottomLeft = new WebControl(HtmlTextWriterTag.Div);
            WebControl cornerBottomRight = new WebControl(HtmlTextWriterTag.Div);
            
            tokenVisualizerTableContainerRounded.Attributes["class"] = "TokenVisualizerTableContainerRounded";
            cornerTopLeft.CssClass = "corner-top-left";
            cornerTopRight.CssClass = "corner-top-right";
            lateralBorders.Attributes["class"] = "lateralBorders";
            containerControl.Attributes["class"] = "containerControl";
            cornerBottomLeft.CssClass = "corner-bottom-left";
            cornerBottomRight.CssClass = "corner-bottom-right";

            cornerTopLeft.Style.Add(HtmlTextWriterStyle.BackgroundImage, this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Microsoft.Samples.DPE.Identity.Controls.Content.images.cornerroundedtransp.gif"));
            cornerTopRight.Style.Add(HtmlTextWriterStyle.BackgroundImage, this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Microsoft.Samples.DPE.Identity.Controls.Content.images.cornerroundedtransp.gif"));
            cornerBottomLeft.Style.Add(HtmlTextWriterStyle.BackgroundImage, this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Microsoft.Samples.DPE.Identity.Controls.Content.images.cornerroundedtransp.gif"));
            cornerBottomRight.Style.Add(HtmlTextWriterStyle.BackgroundImage, this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Microsoft.Samples.DPE.Identity.Controls.Content.images.cornerroundedtransp.gif"));
            
            tokenVisualizerTableContainerRounded.Controls.Add(cornerTopLeft);
            tokenVisualizerTableContainerRounded.Controls.Add(cornerTopRight);
            tokenVisualizerTableContainerRounded.Controls.Add(lateralBorders);
            lateralBorders.Controls.Add(containerControl);
            tokenVisualizerTableContainerRounded.Controls.Add(cornerBottomLeft);
            tokenVisualizerTableContainerRounded.Controls.Add(cornerBottomRight);

            container.Controls.Add(tokenVisualizerTableContainerRounded);

            return containerControl;
        }

        private bool ProcessCertificateDownloadRequest()
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated && Thread.CurrentPrincipal.Identity is IClaimsIdentity)
            {
                if (!string.IsNullOrEmpty(this.Page.Request.QueryString["___stvc___"]))
                {
                    if (this.Page.Request.QueryString["___stvc___"] == "signcert")
                    {
                        var tokenVisualizer = TokenVisualizerFactory.GetTokenVisualizer(((IClaimsIdentity)Thread.CurrentPrincipal.Identity).BootstrapToken);
                        var certificate = tokenVisualizer.RetrieveIssuerCertificate();

                        if (certificate != null)
                        {
                            this.RespondCertificate(certificate);
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void RespondCertificate(X509Certificate2 certificate)
        {
            this.Page.Response.Clear();
            byte[] certInBytes = certificate.Export(X509ContentType.Cert);
            this.Page.Response.BinaryWrite(certInBytes);
            this.Page.Response.ContentType = "application/x-x509-user-cert";
            this.Page.Response.AddHeader("content-disposition", "attachment; filename=" + certificate.Issuer + ".cer");
            this.Page.Response.End();
        }

        private HtmlControl CreateCollapsableHeader(string collapsableTitle, HtmlControl collapsableElement, bool expandedAsDefault)
        {
            return this.CreateCollapsableHeader(
                new HtmlGenericControl("span") { InnerText = collapsableTitle },
                collapsableElement,
                expandedAsDefault);
        }

        private HtmlControl CreateCollapsableHeader(Control title, HtmlControl collapsableElement, bool expandedAsDefault)
        {
            ClientScriptManager clientScriptManager = this.Page.ClientScript;
            Type tokenVisualizerControlType = this.GetType();

            string iconImageId = string.Format(CultureInfo.InvariantCulture, "{0}_image", collapsableElement.ID);

            string onClickJavascriptHandler = string.Format(
                CultureInfo.InvariantCulture,
                "toggleVisualizerVisibility('{0}','{1}','{2}','{3}')",
                collapsableElement.ID,
                iconImageId,
                clientScriptManager.GetWebResourceUrl(tokenVisualizerControlType, "Microsoft.Samples.DPE.Identity.Controls.Content.images.CollapseIcon.bmp"),
                clientScriptManager.GetWebResourceUrl(tokenVisualizerControlType, "Microsoft.Samples.DPE.Identity.Controls.Content.images.ExpandIcon.bmp"));

            HtmlImage iconImage = new HtmlImage()
                                      {
                                          ID = iconImageId,
                                      };
            if (expandedAsDefault)
            {
                iconImage.Src = clientScriptManager.GetWebResourceUrl(tokenVisualizerControlType, "Microsoft.Samples.DPE.Identity.Controls.Content.images.CollapseIcon.bmp");
                collapsableElement.Style["display"] = "block";
            }
            else
            {
                iconImage.Src = clientScriptManager.GetWebResourceUrl(tokenVisualizerControlType, "Microsoft.Samples.DPE.Identity.Controls.Content.images.ExpandIcon.bmp");
                collapsableElement.Style["display"] = "none";
            }

            iconImage.Attributes["class"] = "TokenVisualizerImage";

            HtmlGenericControl collapsableDiv = new HtmlGenericControl("div");
            collapsableDiv.Controls.Add(iconImage);
            collapsableDiv.Controls.Add(title);

            collapsableDiv.Attributes["onclick"] = onClickJavascriptHandler;
            collapsableDiv.Attributes["class"] = "TokenVisualizerTitle";

            return collapsableDiv;
        }

        private void RegisterCssLink()
        {
            HtmlLink link = new HtmlLink()
            {
                Href = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Microsoft.Samples.DPE.Identity.Controls.Content.styles.SecurityTokenVisualizerControl.css")
            };
            link.Attributes["rel"] = "stylesheet";
            link.Attributes["type"] = "text/css";
            
            this.Page.Header.Controls.Add(link);
        }

        private void AddSamlTokenTable(HtmlControl container)
        {
            HtmlTable table = CreateTable(container);
            var tokenVisualizer = TokenVisualizerFactory.GetTokenVisualizer(((IClaimsIdentity)Thread.CurrentPrincipal.Identity).BootstrapToken);

            AddTableSectionHeader(table, Resources.SamlToken, string.Empty);

            string tokenTextAreaId = string.Format(CultureInfo.InvariantCulture, "{0}_samlToken", this.ID);

            HtmlTextArea tokenTextArea = new HtmlTextArea() 
            { 
                ID = tokenTextAreaId
                //,InnerText = tokenVisualizer.SecurityTokenString 
            };
            tokenTextArea.Attributes["class"] = "SAMLToken";
            tokenTextArea.Attributes["readonly"] = "true";

            HtmlControl samlTokenHeader = this.CreateCollapsableHeader(Resources.RawSamlToken, tokenTextArea, false /* Expanded as Default */);

            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell tokenCell = new HtmlTableCell { ColSpan = TableColumnsQuantity };
            tokenCell.Controls.Add(samlTokenHeader);
            tokenCell.Controls.Add(tokenTextArea);
            row.Cells.Add(tokenCell);
            table.Rows.Add(row);

            AddColumnHeadersToTable(table, new[] { Resources.TokenPropertyName, Resources.TokenPropertyValue });

            //foreach (var entry in tokenVisualizer.RetrieveTokenProperties())
            //{
            //    AddTokenProperty(table, entry.Key, entry.Value);
            //}
        }
    }
}