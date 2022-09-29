using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace DecisionEngine.Api.Handlers
{
    public class TransUnionHttpClientHandler : HttpClientHandler
    {
        private readonly Services.Certificate _certificate;
        private readonly ILogger<TransUnionHttpClientHandler> _logger;

        public TransUnionHttpClientHandler(IOptions<Services.Certificate> certificate, ILogger<TransUnionHttpClientHandler> logger)
        {
            _certificate = certificate.Value;
            _logger = logger;

            var rootDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "");
            _certificate.CertificatePath = Path.Combine(rootDir, _certificate.CertificatePath);
            _certificate.KeyPath = Path.Combine(rootDir, _certificate.KeyPath);

            _logger.LogInformation($"Cert Path: { Path.Combine(rootDir, _certificate.CertificatePath)}");
            _logger.LogInformation($"Cert:{_certificate.CertificatePath}; key:{_certificate.KeyPath}; pwd:{_certificate.Password}");


            var cert = new X509Certificate2(_certificate.CertificatePath, _certificate.Password, X509KeyStorageFlags.EphemeralKeySet);

            //Private Key
            var key = RSA.Create();
            key.ImportEncryptedPkcs8PrivateKey(_certificate.Password, ReadPrivateKey(_certificate.KeyPath), out _);
            var certWithKey = cert.CopyWithPrivateKey(key);

            //Public and Private keys combined final certificate
            X509Certificate2 finalCert = new X509Certificate2(certWithKey.Export(X509ContentType.Pkcs12));

            base.ClientCertificates.Add(finalCert);
        }

        private static byte[] ReadPrivateKey(string keyPath)
        {
            string pemKeyString = File.ReadAllText(keyPath);

            string header = "-----BEGIN ENCRYPTED PRIVATE KEY-----";
            string footer = "-----END ENCRYPTED PRIVATE KEY-----";

            int start = pemKeyString.IndexOf(header) + header.Length;
            int end = pemKeyString.IndexOf(footer, start) - start;
            return Convert.FromBase64String(pemKeyString.Substring(start, end));
        }
    }
}
