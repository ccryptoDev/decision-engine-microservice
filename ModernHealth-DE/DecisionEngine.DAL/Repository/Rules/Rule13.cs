using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
   public class Rule13 : Rules
    {
      
        public Rule13(DecisionRules rl, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount)
        {
            //Rule 13: Minimum Specified Monthly Income
            List<TunaService.Response.Model.Trade> transunion_credit_trade = null;
            int rule3val = rl.value;
            string shortDesc = rl.shortdesc.ToLower();
            string description = rl.description;
            string declinedif = declinedvalue(rl.declinedif).ToLower();

            var custom = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom;
            var trade = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.trade;
            if (custom != null)
            {
                if (trade != null)
                {
                    transunion_credit_trade = trade;
                }
                
            }

        
           
            int rule3counter = 0;
            int rule3 = 0;
            if (transunion_credit_trade.Count > 0)
            {

                foreach (var value in transunion_credit_trade)
                {
                    if (value.portfolioType == "revolving")
                    {
                        rule3counter++;
                    }
                }
                rule3 = OnRuleCheck(rule3counter, rule3val, declinedif);
                /*if (rule3counter < rule3val)
                {
                    rule3 = 1;
                }
                else
                {
                    rule3 = 0;
                }*/

                _ruleMessage = shortDesc.ToUpper() + ": " + description + " " + rule3counter;
                _ruleId = shortDesc;
                _ruleVal = rule3;
                ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + " " + declinedif + " " + rule3val);

            }
            else
            {
                 rule3 = 1;
                _ruleMessage = shortDesc.ToUpper() + ": " + description  + rule3counter;
                _ruleId =shortDesc;
                _ruleVal = rule3;
                ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + " " + declinedif + " " + rule3val);


            }
   
        }

    }
}
