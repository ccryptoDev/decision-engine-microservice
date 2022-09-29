namespace DecisionEngine.Services
{
    public class TransUnionSettings
    {
        public string Url { get; set; }
        public string ProductCode { get; set; }
        public string ProcessingEnvironment { get; set; }
        public string PrefixCode { get; set; }
        public string IndustryCode { get; set; }
        public string MemberCode { get; set; }
        public string MemberCodeHardPull { get; set; }
        public string Password { get; set; }
        public string Version { get; set; }
        public bool EnableRequestXmlLogging { get; set; }
        public bool EnableResponseXmlLogging { get; set; }
    }

    public class Certificate
    {
        public string CertificatePath { get; set; }
        public string KeyPath { get; set; }
        public string Password { get; set; }
    }
}
