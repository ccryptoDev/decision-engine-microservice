using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class SocialSecurity
    {
        [XmlAttribute]
        public string source { get; set; }
        public string number { get; set; }
    }
}
