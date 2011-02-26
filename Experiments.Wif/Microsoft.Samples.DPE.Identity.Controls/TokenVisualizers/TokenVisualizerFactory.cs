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
    using System.IdentityModel.Tokens;
    using IdentityModel.Tokens.Saml2;

    public static class TokenVisualizerFactory
    {
        private static readonly ITokenVisualizerInternalFactory[] availableFactories = new ITokenVisualizerInternalFactory[] 
                                                                                           {
                                                                                               new SamlTokenVisualizerInternalFactory(),
                                                                                               new Saml2TokenVisualizerInternalFactory(),
                                                                                               new X509TokenVisualizerInternalFactory()
                                                                                           };

        private interface ITokenVisualizerInternalFactory
        {
            Type SupportedToken { get; }

            ITokenVisualizer GetTokenVisualizer(SecurityToken token);
        }

        public static ITokenVisualizer GetTokenVisualizer(SecurityToken token)
        {
            if (token == null)
                return null;

            foreach (var factory in availableFactories)
            {
                if (factory.SupportedToken == token.GetType())
                {
                    return factory.GetTokenVisualizer(token);
                }
            }

            return null;
        }

        private class SamlTokenVisualizerInternalFactory : ITokenVisualizerInternalFactory
        {
            public Type SupportedToken 
            {
                get
                {
                    return typeof(SamlSecurityToken);
                }
            }

            public ITokenVisualizer GetTokenVisualizer(SecurityToken token)
            {
                SamlSecurityToken samlSecurityToken = token as SamlSecurityToken;
                if (samlSecurityToken == null)
                {
                    throw new ArgumentException("Token is not a SamlSecurityToken.");
                }

                return new SamlTokenVisualizer(samlSecurityToken);
            }
        }

        private class Saml2TokenVisualizerInternalFactory : ITokenVisualizerInternalFactory
        {
            public Type SupportedToken
            {
                get
                {
                    return typeof(Saml2SecurityToken);
                }
            }

            public ITokenVisualizer GetTokenVisualizer(SecurityToken token)
            {
                Saml2SecurityToken saml2SecurityToken = token as Saml2SecurityToken;
                if (saml2SecurityToken == null)
                {
                    throw new ArgumentException("Token is not a SamlSecurityToken.");
                }

                return new Saml2TokenVisualizer(saml2SecurityToken);
            }
        }

        private class X509TokenVisualizerInternalFactory : ITokenVisualizerInternalFactory
        {
            public Type SupportedToken
            {
                get
                {
                    return typeof(X509SecurityToken);
                }
            }

            public ITokenVisualizer GetTokenVisualizer(SecurityToken token)
            {
                X509SecurityToken securityToken = token as X509SecurityToken;
                if (securityToken == null)
                {
                    throw new ArgumentException("Token is not a X509SecurityToken.");
                }

                return new X509TokenVisualizer(securityToken);
            }
        }
    }
}