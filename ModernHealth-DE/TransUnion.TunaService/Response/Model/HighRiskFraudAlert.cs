using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
  public  class HighRiskFraudAlert
    {
        public Message message { get; set; }
        [XmlElement]
        public List<IdentificationIssuance> identificationIssuance { get; set; }

    }
}
