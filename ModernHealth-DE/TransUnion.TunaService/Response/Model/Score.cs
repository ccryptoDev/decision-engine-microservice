using System.Collections.Generic;
using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class Score
    {
        public string results { get; set; }
        public bool derogatoryAlert { get; set; }
        public bool fileInquiriesImpactedScore { get; set; }

      [XmlElement]
        public Factors factors { get; set; }
        public string scoreCard { get; set; }
    }
}
