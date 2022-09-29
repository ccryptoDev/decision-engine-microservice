using Rules_Engine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.Interface
{
   public interface IRulesService
    {
        List<RuleResponseDTO> GetLoadRules();
        string CreateRule(RulesRequestDTO user);
        string UpdateRule(UpdateRulesRequestDTO rule);
        string CreateRuleDescription(RuleDescriptionRequestDTO ruleDescription);
        List<RuleDescriptionDTO> GetLoadRuleDescription();
    }
}
