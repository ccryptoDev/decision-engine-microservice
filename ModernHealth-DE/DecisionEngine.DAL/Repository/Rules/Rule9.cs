using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
    public class Rule9 : Rules
    {
        public Rule9(DecisionRules rl, DateTime enddate, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount)
        {
            int rule9val = rl.value;
            string shortDesc = rl.shortdesc.ToLower();
            string description = rl.description;
            string declinedif = declinedvalue(rl.declinedif).ToLower();
            //R9: #Of trades with #60+DPD in past 6 months 
            var rule9counter = 0;
            var rule9 = 0;
            DateTime paymentstartDate60 ;
            var paymenttext60 = "";
            int pastDue60 = 0;
            List<TunaService.Response.Model.Trade> transunion_credit_trade = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.trade;
            foreach (TunaService.Response.Model.Trade value in transunion_credit_trade)
            {

                pastDue60 = Convert.ToInt32(value.pastDue);
                if (value.paymentHistory != null)
                {
                    if (value.paymentHistory.paymentPattern != null)
                    {
                        paymentstartDate60 = value.paymentHistory.paymentPattern.startDate.Value;
                        paymenttext60 = value.paymentHistory.paymentPattern.text;
                        double monthdiffer = paymentstartDate60.Subtract(enddate).TotalDays / 30;
                        monthdiffer = Math.Abs(monthdiffer);

                        if (monthdiffer < 6 && monthdiffer >= 0)
                        {
                            var charcnt = 6 - monthdiffer;
                            if (charcnt > 0)
                            {
                                if (paymenttext60.Contains("3") || paymenttext60.Contains("K") || paymenttext60.Contains("G") || paymenttext60.Contains("L"))
                                {
                                    rule9counter = rule9counter + 1;
                                }
                            }
                        }
                    }
                }
            };
           
            rule9 = OnRuleCheck(rule9counter, rule9val, declinedif);
            
            _ruleMessage = shortDesc.ToUpper() + ": " + description + " :  " + rule9counter;
            _ruleId = shortDesc;
            _ruleVal = rule9;
            ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + "  " + declinedif + " " + rule9val);
        }

       
    }
}
