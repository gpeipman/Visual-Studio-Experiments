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
    using System.Security.Cryptography.X509Certificates;

    public static class CertificateUtility
    {
        public static X509Certificate2 GetCertificate(StoreName name, StoreLocation location, X509FindType findType, string value)
        {
            X509Store store = new X509Store(name, location);
            X509Certificate2Collection certificates = null;
            store.Open(OpenFlags.ReadOnly);

            try
            {
                certificates = store.Certificates.Find(findType, value, true);

                if (certificates.Count > 0)
                {
                    return new X509Certificate2(certificates[0]);
                }
                else
                {
                    throw new ApplicationException("No certificate was found");
                }
            }
            catch (ApplicationException)
            {
                return null;
            }
            finally
            {
                if (certificates != null)
                {
                    for (int i = 0; i < certificates.Count; i++)
                    {
                        X509Certificate2 cert = certificates[i];
                        cert.Reset();
                    }
                }

                store.Close();
            }
        }
    }
}