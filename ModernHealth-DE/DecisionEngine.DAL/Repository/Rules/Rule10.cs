using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
   public class Rule10 : Rules
    {
        public Rule10(DecisionRules rl, DateTime utilizationstartdate, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount)
        {
			double rule10counter = 0;
			var rule10 = 0;
			var portfolioType = "";
			double currentBalance = 0;
			var ECOADesignator = "";
			DateTime? dateEffective=null;
			double total_revolving_creditLimit = 0;
			double total_revolving_balance = 0;
			double creditLimit = 0;
			int rule10val = rl.value;
			string shortDesc = rl.shortdesc.ToLower();
			string description = rl.description;
			string declinedif = declinedvalue(rl.declinedif).ToLower();
			List<TunaService.Response.Model.Trade> transunion_credit_trade = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.trade;
			//Rule === R10: Utilization of Revolving trades
			if (transunion_credit_trade.Count>0)
				{
				foreach (TunaService.Response.Model.Trade value in transunion_credit_trade)
				{
					if (value.portfolioType != null)
					{
						portfolioType = value.portfolioType;
					}
					if (value.currentBalance != null)
					{
						currentBalance = Convert.ToDouble(value.currentBalance);
					}
					if (value.dateClosed != null)
						break;
					if (value.ECOADesignator != null)
					{
						ECOADesignator = value.ECOADesignator;
					}

					creditLimit = Convert.ToDouble(value.creditLimit);
					if (value.dateEffective != null)
					{
						dateEffective = value.dateEffective.Value;
					}
					if (portfolioType == "revolving" && dateEffective > utilizationstartdate && (ECOADesignator != "jointContractLiability" && ECOADesignator != "authorizedUser" && ECOADesignator != "terminated"))
					{
						if (creditLimit > 0)
						{
							total_revolving_creditLimit += creditLimit;
							if (currentBalance > 0)
							{
								total_revolving_balance += currentBalance;
							}
						}
					}
				}
				rule10counter = Convert.ToDouble(total_revolving_creditLimit == 0 ? 0 : Convert.ToDouble(total_revolving_balance) / Convert.ToDouble(total_revolving_creditLimit));
			};
			
				rule10 = OnRuleCheck(Convert.ToInt32(rule10counter), rule10val, declinedif);
			
				_ruleMessage = shortDesc.ToUpper() + ": " + description + " :   " + Math.Round(rule10counter, 2);
				_ruleId = shortDesc;
				_ruleVal = rule10;
				ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + " " + declinedif + " " + rule10val);
	
			}

		}
       
    }

