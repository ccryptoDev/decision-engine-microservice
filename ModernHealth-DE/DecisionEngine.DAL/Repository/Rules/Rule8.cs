using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
  public  class Rule8 :Rules
    {


        public Rule8(DecisionRules rl, DateTime enddate, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount)
        {
            int rule8val = rl.value;
            string shortDesc = rl.shortdesc.ToLower();
            string description = rl.description;
            string declinedif = declinedvalue(rl.declinedif).ToLower();
            List<TunaService.Response.Model.Trade> transunion_credit_trade = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.trade;
            if (transunion_credit_trade.Count>0)
            {

                //R8: #Of trades with #60+DPD in past 24 months
                var rule8counter = 0;
                var rule8 = 0;
                DateTime paymentstartDate24 ;
                var paymenttext24 ="";
                double pastDue24 = 0;
                foreach(TunaService.Response.Model.Trade value in transunion_credit_trade)
                { 
                    pastDue24 = Convert.ToDouble(value.pastDue);
                    if (value.paymentHistory!=null)
                    {
                        if (value.paymentHistory.paymentPattern!=null)
                        {
                            paymentstartDate24 = value.paymentHistory.paymentPattern.startDate.Value;
                            paymenttext24 = value.paymentHistory.paymentPattern.text;
                            double monthdiffer = paymentstartDate24.Subtract(enddate).TotalDays/30;
                            monthdiffer = Math.Abs(monthdiffer);

                            if (monthdiffer < 24 && monthdiffer >= 0)
                            {
                                var charcnt = 24 - monthdiffer;
                                if (charcnt > 0)
                                {
                                    if (paymenttext24.Contains("2")  || paymenttext24.Contains('K') || paymenttext24.Contains("G")  || paymenttext24.Contains("L"))
                                    {
                                        rule8counter = rule8counter + 1;
                                    }
                                }
                            }
                        }
                    }
                };
                rule8 = OnRuleCheck(rule8counter, rule8val, declinedif);


                    _ruleMessage = shortDesc.ToUpper() + ": " + description + " :  " + rule8counter;
                _ruleId =shortDesc;
                _ruleVal = rule8;
                ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + " " + declinedif + "  " + rule8val);

            }
           

        }

    }
}
