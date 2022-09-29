using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
    public class Rule12 : Rules
    {
        public Rule12(DecisionRules rl, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount, long income)
        {
            //Rule 12: ISA Shares income exeeds percent
            //doesn’t exceed monthly rent/ mortgage payment by at least $425.
            int rule12val = rl.value;
             var rule12 = 0;
            string shortDesc = rl.shortdesc.ToLower();
            string description = rl.description;
            string declinedif = declinedvalue(rl.declinedif).ToLower();
            double tradeBalance = 0;
            var transunion_credit_trade = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.trade;
            if (transunion_credit_trade.Count > 0)
            {
                System.Collections.ArrayList ecoaDesign = new System.Collections.ArrayList() { "authorizeduser", "terminated", "deceased" };
                foreach (var trade in transunion_credit_trade)
                {
                    string industryCode = trade.subscriber.industryCode.ToUpper();
                    string ecoa = trade.ECOADesignator.ToLower();//undesignated

                    string portfolioType = trade.portfolioType.ToLower();
                    double currentBalance = Convert.ToDouble(trade.currentBalance ?? "0");

                    if (ecoaDesign.Contains(ecoa))
                    {
                        _ruleMessage = shortDesc.ToUpper() + ": " + description + "  : " + rule12val;
                        _ruleId = shortDesc;
                        _ruleVal = rule12;
                        ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + "  " + declinedif + "  " + rule12val);
                        return;
                    }
                    if (industryCode != "M")
                    {
                        DateTime? dateClosed = string.IsNullOrWhiteSpace(Convert.ToString(trade.dateClosed)) ? (DateTime?)null : trade.dateClosed.Value.Date;
                        DateTime? datePaidOut = string.IsNullOrWhiteSpace(Convert.ToString(trade.datePaidOut)) ? (DateTime?)null : trade.datePaidOut.Value.Date;

                       
                        double scheduledMonthlyPayment = trade.terms!=null? Convert.ToDouble(String.IsNullOrWhiteSpace(trade.terms.scheduledMonthlyPayment)?"0" : trade.terms.scheduledMonthlyPayment) : 0 ;
                        if (dateClosed != null || datePaidOut != null || currentBalance == 0)
                        {
                            _ruleMessage = shortDesc.ToUpper() + ": " + description + "  : " + rule12val;
                            _ruleId = shortDesc;
                            _ruleVal = rule12;
                            ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + "  " + declinedif + "  " + rule12val);
                            return;
                        }
                        if (scheduledMonthlyPayment > 0)
                        {
                            tradeBalance = Math.Round(Convert.ToDouble(tradeBalance + scheduledMonthlyPayment), 2);
                        }
                    }
                }
            }
            double maxPreDTI = 0.36;
            double monthlyAmount = tradeBalance;
            double percent = Math.Round(Convert.ToDouble((tradeBalance / income) * 100), 2);
            if (percent >= maxPreDTI)
            {
                rule12 = 1;
            }
            _ruleMessage = shortDesc.ToUpper() + ": " + description + "  : " + rule12val;
            _ruleId = shortDesc;
            _ruleVal = rule12;
            ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + "  " + declinedif + "  " + rule12val);



        }


    }
}
