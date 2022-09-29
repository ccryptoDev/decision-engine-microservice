using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class MilitaryLendingActSearch
    {
        [XmlAttribute]
        public string searchStatus { get; set; } //noMatch || match
    }
}
