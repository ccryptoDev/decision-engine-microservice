
using DecisionEngine.Entities.Entity;
using DecisionEngine.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
    public class BankRules : Rules
    {
        public BankRules(DecisionRules rl, List<BankRule> bankRules, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount)
        {
            int ruleBankval = rl.value;
            string shortDesc = rl.shortdesc.ToLower();
            string description = rl.description;
            string declinedif = declinedvalue(rl.declinedif).ToLower();

            var ruleBankcounter = 0;
            var ruleBank = 0;
            if (bankRules != null)
            {
                if (bankRules.Count > 0)
                {

                    ruleBankcounter = bankRules.Where(d => d.ruleName.ToLower() == shortDesc).FirstOrDefault().ruleValue ?? 0;

                    ruleBank = OnRuleCheck(ruleBankcounter, ruleBankval, declinedif);
                }
            }
                _ruleMessage = shortDesc.ToUpper() + ": " + description + " :  " + ruleBankcounter;
                _ruleId = shortDesc;
                _ruleVal = ruleBank;
                ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + "  " + declinedif + " " + ruleBankval);
            
        }
    }


}

