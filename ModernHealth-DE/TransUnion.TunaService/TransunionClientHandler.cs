namespace DecisionEngine.TunaService
{

    /* public static class TransunionClientHandler
     {
         public static HttpClientHandler GetHandler(CertificateInfo settings)
         {
             var cert = new X509Certificate2(settings.CertificatePath, settings.Password, X509KeyStorageFlags.EphemeralKeySet);

             //Private Key
             var key = RSA.Create();
             key.ImportEncryptedPkcs8PrivateKey(settings.Password, ReadPrivateKey(settings.KeyPath), out _);
             var certWithKey = cert.CopyWithPrivateKey(key);

             //Public and Private keys combined final certificate
             X509Certificate2 certificate = new X509Certificate2(certWithKey.Export(X509ContentType.Pkcs12));

             //Create HttpClientHandler to hold client certificate.
             var handler = new HttpClientHandler();
             handler.ClientCertificates.Add(certificate);

             return handler;
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

     public class CertificateInfo
     {
         public string CertificatePath { get; set; }
         public string KeyPath { get; set; }
         public string Password { get; set; }
     } */
}
