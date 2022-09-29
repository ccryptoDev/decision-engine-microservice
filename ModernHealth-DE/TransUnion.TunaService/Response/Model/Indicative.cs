using System.Collections.Generic;
using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class Indicative
    {
        [XmlElement(elementName: "name")]
        public List<Name> name { get; set; }

        [XmlElement(elementName: "address")]
        public List<Address> address { get; set; }
        public SocialSecurity socialSecurity { get; set; }
        public IndicativeDate dateOfBirth { get; set; }

        [XmlElement(elementName: "employment")]
        public List<Employment> employment { get; set; }
    }

}
