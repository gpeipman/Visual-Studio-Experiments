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
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Web;
    using System.Xml;
    using IdentityModel.Configuration;
    using IdentityModel.Tokens;
    using IdentityModel.Tokens.Saml2;

    public class Saml2TokenVisualizer : ITokenVisualizer
    {
        public Saml2TokenVisualizer(Saml2SecurityToken token)
        {
            this.Token = token;
        }

        public Saml2SecurityToken Token { get; private set; }

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

            result["Saml2SecurityToken.Id"] = this.Token.Id;
            result["Saml2SecurityToken.ValidFrom"] = this.Token.ValidFrom.ToString(CultureInfo.CurrentUICulture);

            TimeSpan validity = this.Token.ValidTo.Subtract(this.Token.ValidFrom);
            string formattedValidity = (validity.Ticks > TimeSpan.TicksPerHour) ? validity.TotalHours.ToString(CultureInfo.CurrentUICulture) + " hours" : validity.TotalMinutes.ToString(CultureInfo.CurrentUICulture) + " minutes";

            result["Saml2SecurityToken.ValidTo"] = string.Format(CultureInfo.CurrentUICulture, "{0} ({1})", this.Token.ValidTo.ToString(CultureInfo.CurrentUICulture), formattedValidity);
            result["Saml2SecurityToken.Assertion.Issuer"] = this.Token.Assertion.Issuer.Value;
            result["Saml2SecurityToken.Assertion.IssueInstant"] = this.Token.Assertion.IssueInstant.ToString(CultureInfo.CurrentUICulture);

            IEnumerable<Saml2AudienceRestriction> samlAudienceConditions = this.Token.Assertion.Conditions.AudienceRestrictions;
            string audiencesFormatString = samlAudienceConditions.Count() > 1 ? "{0}{1}<br/>" : "{0}{1}";
            foreach (Saml2AudienceRestriction samlCondition in samlAudienceConditions)
            {
                result["Intended Audience"] = samlCondition.Audiences.Aggregate(string.Empty, (acum, current) => string.Format(CultureInfo.CurrentUICulture, audiencesFormatString, acum, current.ToString()));
            }

            result["Saml2SecurityToken.Assertion.Version"] = this.Token.Assertion.Version;

            this.AddSigningCertificate(result);
            AddEncryptingCertificate(result);

            return result;
        }

        public X509Certificate2 RetrieveIssuerCertificate()
        {
            return ((X509SecurityToken)this.Token.IssuerToken).Certificate;
        }

        private static void AddEncryptingCertificate(Dictionary<string, string> result)
        {
            foreach (ServiceElement config in MicrosoftIdentityModelSection.Current.ServiceElements)
            {
                if (config.ServiceCertificate != null && config.ServiceCertificate.CertificateReference != null)
                {
                    var certificateInfo = config.ServiceCertificate.CertificateReference;
                    X509Certificate2 certificate = CertificateUtility.GetCertificate(
                        certificateInfo.StoreName,
                        certificateInfo.StoreLocation,
                        certificateInfo.X509FindType,
                        certificateInfo.FindValue);

                    if (certificate != null)
                    {
                        StringBuilder rowHeader = new StringBuilder();
                        rowHeader.Append("Encrypting Certificate (from configuration)");
                        StringBuilder sb = new StringBuilder();
                        sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Subject] {0}<br/>", certificate.Subject));
                        sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Issuer] {0}<br/>", certificate.Issuer));
                        sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Serial Number] {0}<br/>", certificate.SerialNumber));
                        sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Not Before] {0}<br/>", certificate.NotBefore));
                        sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Not After] {0}<br/>", certificate.NotAfter));
                        sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Thumbprint] {0}<br/>", certificate.Thumbprint));

                        result[rowHeader.ToString()] = sb.ToString();
                    }
                }
            }
        }

        private void AddSigningCertificate(Dictionary<string, string> result)
        {
            if (this.Token.Assertion.SigningCredentials != null)
            {
                result["Signature Algorithm"] = this.Token.Assertion.SigningCredentials.SignatureAlgorithm;

                X509Certificate2 certificate = ((X509SecurityToken)this.Token.IssuerToken).Certificate;
                StringBuilder sb = new StringBuilder();
                StringBuilder rowHeader = new StringBuilder();
                rowHeader.Append(string.Format(CultureInfo.CurrentUICulture, "Signing Certificate<br /><a href={0}>Download Certificate</a><br/>", HttpContext.Current.Request.RawUrl + (HttpContext.Current.Request.QueryString.Count == 0 ? "?" : "&") + "___stvc___=signcert"));
                sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Subject] {0}<br/>", certificate.Subject));
                sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Issuer] {0}<br/>", certificate.Issuer));
                sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Serial Number] {0}<br/>", certificate.SerialNumber));
                sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Not Before] {0}<br/>", certificate.NotBefore));
                sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Not After] {0}<br/>", certificate.NotAfter));
                sb.Append(string.Format(CultureInfo.CurrentUICulture, "[Thumbprint] {0}<br/>", certificate.Thumbprint));

                result[rowHeader.ToString()] = sb.ToString();
            }
        }
    }
}