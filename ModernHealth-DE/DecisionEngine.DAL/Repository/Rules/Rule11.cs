using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
	public class Rule11 : Rules
	{
		public Rule11(DecisionRules rl, int creditScore, Dictionary<string, string> ruledatacount)
	{
		var rule11counter = creditScore;
	var rule11 = 0;

			//Rule === R11: Minimum Credit Score 
			int rule11val = rl.value;
	string shortDesc = rl.shortdesc.ToLower();
	string description = rl.description;
	string declinedif = declinedvalue(rl.declinedif).ToLower();

			rule11 = OnRuleCheck(rule11counter, rule11val, declinedif);

			_ruleMessage = shortDesc.ToUpper() + ": " + description + " :   " + rule11counter;
_ruleId = shortDesc;
_ruleVal = rule11;
ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + " " + declinedif + " " + rule11val);


		}

	}


}

