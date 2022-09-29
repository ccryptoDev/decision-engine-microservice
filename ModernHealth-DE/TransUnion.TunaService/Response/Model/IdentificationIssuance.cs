using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
   public class IdentificationIssuance
    {
        [XmlAttribute]
        public string source { get; set; }
        public string type { get; set; }
        public string alertMessageCode { get; set; }

        public YearRange yearRange { get; set; }
        public string state { get; set; }

        public AgeObtained ageObtained { get; set; }

    }
}
