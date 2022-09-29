using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.Entities.Entity
{
   public class DecisionRules
    {
            public long id { get; set; }
            public long? rule_id { get; set; }
            public string description { get; set; }
            public string declinedif { get; set; }
            public int value { get; set; }

            public string shortdesc { get; set; }


    }
}
