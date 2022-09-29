using System.Collections.Generic;
using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class Credit
    {
        [XmlElement(elementName: "trade")]
        public List<Trade> trade { get; set; }
        [XmlElement(elementName: "inquiry")]
        public List<Inquiry> inquiry { get; set; }
        //  public Inquiry inquiry { get; set; }
       
        public PublicRecord publicRecord { get; set; }
        [XmlElement(elementName: "collection")]
        public List<Collection> collection { get; set; }
    }
}
