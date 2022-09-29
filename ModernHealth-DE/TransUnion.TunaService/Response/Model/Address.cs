using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class Address
    {
        [XmlAttribute]
        public string source { get; set; }
        public string status { get; set; }
        public string qualifier { get; set; }
        public Street street { get; set; }
        public Location location { get; set; }
        public IndicativeDate dateReported { get; set; }
    }
}
