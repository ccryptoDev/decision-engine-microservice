using System.Collections.Generic;
using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class SubjectRecord
    {
        public int fileNumber { get; set; }
        public FileSummary fileSummary { get; set; }
        public Indicative indicative { get; set; }
        public Custom custom { get; set; }

        [XmlElement(elementName: "addOnProduct")]
        public List<AddOnProduct> addOnProduct { get; set; }
    }
}
