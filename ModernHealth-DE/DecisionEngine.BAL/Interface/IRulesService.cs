using DecisionEngine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Interface
{
   public interface IRulesService
    {
        List<RuleResponseDTO> GetLoadRules(long setting_id);
        string CreateRule(RulesRequestDTO user);
        string UpdateRule(UpdateRulesRequestDTO rule);
        string CreateRuleDescription(RuleDescriptionRequestDTO ruleDescription);
        List<RuleDescriptionDTO> GetLoadRuleDescription();

        string UpdateRuleDescription(UpdateRuleDescriptionRequestDTO updateRuleDescriptionRequestDTO);
        List<RuleDescriptionDTO> GetRuleDescriptions();
        string InsertSettingRule(long setting_id);
        string AddOrUpdateSettingRule(List<SettingRuleDto> settingRulesDto);
        List<SettingRulesResponseDto> GetLoadSettingRules(long setting_id);
    }
}
