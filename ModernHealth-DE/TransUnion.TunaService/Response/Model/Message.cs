using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class Message
    {
        [XmlAttribute]
        public string source { get; set; }

        public string code { get; set; }
    }
}
