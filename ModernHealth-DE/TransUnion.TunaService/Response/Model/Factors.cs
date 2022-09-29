using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
   public class Factors
    {
        [XmlElement]
        public List<Factor> factor { get; set; }
    }
}
