using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
   public class Rule4 : Rules
    {
          public Rule4(DecisionRules rl, DateTime inquirystartdate, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount)
        {
            int rule4val = rl.value;
            string shortDesc = rl.shortdesc.ToLower();
            string description = rl.description;
            string declinedif = declinedvalue(rl.declinedif).ToLower();
           
            var custom = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom;
            var inquiries = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.inquiry;
            //Rule === R4: Inquiries in last 6 mos 

            int rule4counter = 0;
            int rule4 = 0;
            foreach (var inquiry in inquiries)
            {
                if (inquiry.date != null)
                {
                    DateTime apiinquiryresstartdate = inquiry.date.Value;

                    if (apiinquiryresstartdate >= inquirystartdate)
                    {
                        rule4counter = rule4counter++;
                    }
                }
            }

                rule4 = OnRuleCheck(rule4counter, rule4val, declinedif);
 
            _ruleMessage = shortDesc.ToUpper() + ": " + description + "" + rule4counter;
            _ruleId =shortDesc;
            _ruleVal = rule4;

            ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + " " + declinedif+"  "+rule4val);

        }


    }
}
