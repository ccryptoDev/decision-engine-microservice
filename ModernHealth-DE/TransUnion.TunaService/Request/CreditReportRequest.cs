using System;
using System.Xml.Serialization;
using DecisionEngine.TunaService.Request.Model;

namespace DecisionEngine.TunaService.Request
{
    [Serializable]
    [XmlRoot(Namespace = "http://www.transunion.com/namespace", ElementName = "creditBureau", DataType = "string", IsNullable = true)]
    public class CreditReportRequest : RequestBase
    {
        public Product product { get; set; }
    }
}