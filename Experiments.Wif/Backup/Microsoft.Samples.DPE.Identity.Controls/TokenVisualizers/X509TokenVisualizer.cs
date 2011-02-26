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

namespace Microsoft.Samples.DPE.Identity.Controls.TokenVisualizers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IdentityModel.Tokens;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Web;
    using System.Xml;
    using IdentityModel.Tokens;

    public class X509TokenVisualizer : ITokenVisualizer
    {
        public X509TokenVisualizer(X509SecurityToken token)
        {
            if (token == null) throw new ArgumentNullException("token");
            this.Token = token;
        }

        public X509SecurityToken Token { get; private set; }

        public string SecurityTokenString
        {
            get
            {
                var handlers = SecurityTokenHandlerCollection.CreateDefaultSecurityTokenHandlerCollection();
                var handler = handlers[this.Token.GetType()];
                StringBuilder sb = new StringBuilder();
                var settings = new XmlWriterSettings { Indent = true };
                using (XmlWriter xw = XmlWriter.Create(sb, settings))
                {
                    handler.WriteToken(xw, this.Token);
                }

                return sb.ToString();
            }
        }

        public IDictionary<string, string> RetrieveTokenProperties()
        {
            var result = new Dictionary<string, string>();

            result["X509SecurityToken.Id"] = this.Token.Id;
            result["X509SecurityToken.ValidFrom"] = this.Token.ValidFrom.ToString(CultureInfo.CurrentUICulture);

            TimeSpan validity = this.Token.ValidTo.Subtract(this.Token.ValidFrom);
            string formattedValidity = (validity.Ticks > TimeSpan.TicksPerHour) ? validity.TotalHours.ToString(CultureInfo.CurrentUICulture) + " hours" : validity.TotalMinutes.ToString(CultureInfo.CurrentUICulture) + " minutes";

            result["X509SecurityToken.ValidTo"] = string.Format(CultureInfo.CurrentUICulture, "{0} ({1})", this.Token.ValidTo.ToString(CultureInfo.CurrentUICulture), formattedValidity);

            if (this.Token.Certificate != null)
            {
                X509Certificate2 certificate = this.Token.Certificate;
                StringBuilder sb = new StringBuilder();
                StringBuilder rowHeader = new StringBuilder();
                rowHeader.Append(string.Format(CultureInfo.CurrentUICulture, "Certificate<br /><a href={0}>Download Certificate</a><br/>", HttpContext.Current.Request.RawUrl + (HttpContext.Current.Request.QueryString.Count == 0 ? "?" : "&") + "___stvc___=signcert"));
                sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Subject] {0}<br/>", certificate.Subject));
                sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Issuer] {0}<br/>", certificate.Issuer));
                sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Serial Number] {0}<br/>", certificate.SerialNumber));
                sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Not Before] {0}<br/>", certificate.NotBefore));
                sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Not After] {0}<br/>", certificate.NotAfter));
                sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Thumbprint] {0}<br/>", certificate.Thumbprint));

                result[rowHeader.ToString()] = sb.ToString();
            }

            return result;
        }

        public X509Certificate2 RetrieveIssuerCertificate()
        {
            return this.Token.Certificate;
        }
    }
}