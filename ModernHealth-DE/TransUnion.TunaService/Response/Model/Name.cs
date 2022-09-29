using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class Name
    {
        [XmlAttribute]
        public string source { get; set; }
        public Person person { get; set; }
    }
}
