using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class OfacNameScreen
    {
        [XmlAttribute]
        public string searchStatus { get; set; } //clear or potentialHit or unavailable
     
    }
}
