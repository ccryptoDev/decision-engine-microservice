using System;
using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class ResponseDate
    {
       
        public bool estimatedDay { get; set; }
     
        public bool estimatedMonth { get; set; }
    
        public bool estimatedCentury { get; set; }
      
        public bool estimatedYear { get; set; }
        public DateTime Value { get; set; }
    }
}
