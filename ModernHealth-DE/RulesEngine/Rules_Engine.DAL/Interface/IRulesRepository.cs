using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.DAL.Interface
{
   public interface IRulesRepository
    {
        List<RulesResponse> GetLoadRules();
        string CreateRule(Rule user);
        string UpdateRule(Rule rule);
        string CreateRuleDescription(RuleDescription ruleDescription);
        List<RuleDescription> GetLoadRuleDescription();
    }
}
