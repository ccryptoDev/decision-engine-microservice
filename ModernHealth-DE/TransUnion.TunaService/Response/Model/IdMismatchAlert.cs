using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.TunaService.Response.Model
{
   public class IdMismatchAlert
    {
        public string type { get; set; }
        public string condition { get; set; }
        public string inquiriesInLast60Count { get; set; }
        public string addressStatus { get; set; }


    }
}
