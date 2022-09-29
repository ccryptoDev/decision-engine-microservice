using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.DTO
{
 
        public class RulesRequestDTO
        {
            public long rule_id { get; set; }
            //  public string? description { get; set; }

            public string declinedif { get; set; }

            public float value { get; set; }
        public long? setting_id { get; set; }
        public Boolean disabled { get; set; }
        public Boolean passthru { get; set; }
    }
        public class UpdateRulesRequestDTO
        {
            public long id { get; set; }
            public long rule_id { get; set; }
            //  public string? description { get; set; }

            public string declinedif { get; set; }

            public float value { get; set; }

            public Boolean disabled { get; set; }
        public long? setting_id { get; set; }
        public Boolean passthru { get; set; }
    }

        public class RuleResponseDTO
        {

            public long id { get; set; }

            public long rule_id { get; set; }

            public string description { get; set; }

            public string declinedif { get; set; }

            public float value { get; set; }
        public Boolean passthru { get; set; }
        public Boolean disabled { get; set; }

        public long? setting_id { get; set; }
    }
    public class SettingRulesResponseDto
    {
        public long id { get; set; }
        public long? rule_id { get; set; }
        public string description { get; set; }


        public long? setting_id { get; set; }


    }
    public class SettingRuleDto
    {
       
        public long Id { get; set; }
   
        public long? rule_id { get; set; }
      
        public long? setting_id { get; set; }
        public Boolean active { get; set; }
    }

}
