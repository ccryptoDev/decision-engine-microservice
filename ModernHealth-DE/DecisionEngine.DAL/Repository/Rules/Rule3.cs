using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
    public class Rule3 : Rules
    {

        public Rule3(DecisionRules rl, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount)
        {

            int rule3val = rl.value;
            string shortDesc = rl.shortdesc.ToLower();
            string description = rl.description;
            string declinedif = declinedvalue(rl.declinedif).ToLower();

            System.Collections.ArrayList accountIgnore = new System.Collections.ArrayList() { "ST", "SC" };

            var custom = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom;
            var trades = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.trade;

            //Rule === R3: Number of revolving trade lines 

            int rule3counter = 0;
            int rule3 = 0;
            DateTime curDate = DateTime.UtcNow;

            foreach (var trade in trades)
            {
                var accounttype = trade.account.type;
                var dateEffective = trade.dateEffective;
                if (trade.portfolioType == "revolving")
                {
                    int? creditLimit = trade.creditLimit??0;
                    if (creditLimit < 600)
                        break;
                    // date is effective within 6 months?
                    if (dateEffective != null)
                    {
                        if (MonthDiff(dateEffective.Value, curDate) > 6)
                            break;
                    }
                    if (!String.IsNullOrEmpty(accounttype))
                    {
                        if (accountIgnore.Contains(accounttype.ToUpper().Substring(0, 2)))
                            break;
                    }
                    rule3counter++;
                }
            }
            rule3 = OnRuleCheck(rule3counter, rule3val, declinedif);


            _ruleMessage = shortDesc.ToUpper() + ": " + description + " " + rule3counter;
            _ruleId = shortDesc;
            _ruleVal = rule3;
            ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + " " + declinedif + " " + rule3val);

        }

    }
}

