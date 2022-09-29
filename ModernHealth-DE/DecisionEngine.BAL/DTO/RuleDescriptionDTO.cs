using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.DTO
{
    public class RuleDescriptionRequestDTO
    {
       
        public string description { get; set; }
        public string short_desc { get; set; }
    }

    public class RuleDescriptionResponseDTO
    {
        public long Id { get; set; }
        public string description { get; set; }
        public string short_desc { get; set; }
    }

    public class RuleDescriptionDTO
    {
        public long Id { get; set; }
        public string description { get; set; }
        public string short_desc { get; set; }
    }
    public class UpdateRuleDescriptionRequestDTO
    {
        public long id { get; set; }
        public string description { get; set; }
    
        public Boolean active { get; set; }

    }
}
