using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
   public class IndicativeDate
    {
      
            [XmlAttribute]
            public bool estimatedDay { get; set; }
            [XmlAttribute]
            public bool estimatedMonth { get; set; }
            [XmlAttribute]
            public bool estimatedCentury { get; set; }
            [XmlAttribute]
            public bool estimatedYear { get; set; }
        [XmlText]
        public DateTime Value { get; set; }
        
    }
}
