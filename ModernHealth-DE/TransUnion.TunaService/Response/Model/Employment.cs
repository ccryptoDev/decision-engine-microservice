using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class Employment
    {
        [XmlAttribute]
        public string source { get; set; }
        public Employer employer { get; set; }
        public string occupation { get; set; }
        public IndicativeDate dateOnFileSince { get; set; }
        public IndicativeDate dateEffective { get; set; }
    }
}
