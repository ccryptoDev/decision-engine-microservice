using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.DTO
{
 
        public class RulesRequestDTO
        {
            public long rule_id { get; set; }
            //  public string? description { get; set; }

            public string? declinedif { get; set; }

            public float value { get; set; }

            public Boolean disabled { get; set; }
        }
        public class UpdateRulesRequestDTO
        {
            public long id { get; set; }
            public long rule_id { get; set; }
            //  public string? description { get; set; }

            public string? declinedif { get; set; }

            public float value { get; set; }

            public Boolean disabled { get; set; }
        }

        public class RuleResponseDTO
        {

            public long id { get; set; }

            public long rule_id { get; set; }

            public string? description { get; set; }

            public string? declinedif { get; set; }

            public float value { get; set; }

            public Boolean disabled { get; set; }


        }
   
}
