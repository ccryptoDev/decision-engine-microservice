using System.Collections.Generic;
using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Request.Model
{
    public class Indicative
    {
        public Name name { get; set; }

        [XmlElement(elementName: "address")]
        public List<Address> address { get; set; }
        public SocialSecurity socialSecurity { get; set; }
        public string dateOfBirth { get; set; }
    }
}
