using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
    public class Rule14 : Rules
    {
        public Rule14(DecisionRules rl, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount)
        {


            var trades = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.trade;
            int rule2val = rl.value;
            string shortDesc = rl.shortdesc.ToLower();
            string description = rl.description;
            string declinedif = declinedvalue(rl.declinedif).ToLower();

            DateTime curDate = DateTime.UtcNow;
            //Rule === R14: Number of Derogatory Active Trades
            var rule2counter = 0;
            var rule2 = 0;
            System.Collections.ArrayList accountIgnore = new System.Collections.ArrayList() { "ST" };
            System.Collections.ArrayList ecoaIgnore = new System.Collections.ArrayList() { "authorizeduser", "deceased" };
            System.Collections.ArrayList industryIgnore = new System.Collections.ArrayList() { "M" };
            System.Collections.ArrayList goodRatings = new System.Collections.ArrayList() { "01", "UR" };
            foreach (var trade in trades)
            {
                var industrycode = trade.subscriber.industryCode;
                var ECOADesignator = trade.ECOADesignator;
                var accountRating = trade.accountRating;
                var dateClosed = trade.dateClosed;
                var datePaidOut = trade.datePaidOut;
                var dateEffective = trade.dateEffective;
                var accounttype = trade.account.type;
                if (!String.IsNullOrEmpty(industrycode))
                {
                    if (industryIgnore.Contains(industrycode.ToUpper().Substring(0, 1)))
                        break;
                }
                if (!String.IsNullOrEmpty(accounttype))
                {
                    if (accountIgnore.Contains(accounttype.ToUpper().Substring(0, 2)))
                        break;
                }
                if (!String.IsNullOrEmpty(ECOADesignator))
                {
                    if (ecoaIgnore.Contains(ECOADesignator.ToLower()))
                        break;
                }
                if (!String.IsNullOrEmpty(accountRating))
                {
                    if (goodRatings.Contains(accountRating.ToLower()))
                        break;
                }
                rule2counter++;
            }
            rule2 = OnRuleCheck(rule2counter, rule2val, declinedif);

            _ruleMessage = shortDesc.ToUpper() + ": " + description + "  : " + rule2counter;
            _ruleId = shortDesc;
            _ruleVal = rule2;
            ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + "  " + declinedif + "  " + rule2val);
        }
    }
}
