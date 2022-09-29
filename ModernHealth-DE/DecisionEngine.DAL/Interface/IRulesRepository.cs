using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Interface
{
   public interface IRulesRepository
    {
        List<RulesResponse> GetLoadRules(long setting_id);
        string CreateRule(Rule user);
        string UpdateRule(Rule rule);
        string CreateRuleDescription(RuleDescription ruleDescription);
        List<RuleDescription> GetLoadRuleDescription();
        string UpdateRuleDescription(RuleDescription ruleDescription);
        List<RuleDescription> GetRuleDescriptions();
        string InsertSettingRule(long setting_id);
        string AddOrUpdateSettingRule(List<SettingRule> settingRules);
        List<SettingRulesResponse> GetLoadSettingRules(long setting_id);
    }
}
