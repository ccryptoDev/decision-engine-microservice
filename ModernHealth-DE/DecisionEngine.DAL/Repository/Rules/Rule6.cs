using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
   public class Rule6 : Rules
    {
       
        public Rule6(DecisionRules rl, DateTime forclosurestartdate, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount)
        {
            System.Collections.ArrayList forclosuretype = new System.Collections.ArrayList { "DF", "FC", "SF" };
            int rule6val = rl.value;
            string shortDesc = rl.shortdesc.ToLower();
            string description = rl.description;
            string declinedif = declinedvalue(rl.declinedif).ToLower();
            // R6: Foreclosure in last 24 mos 
            var rule6counter = 0;
            var rule6 = 0;
            var publicRecord_data = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.publicRecord;
            DateTime forclosure_date;
            if (publicRecord_data != null)
            {
                var forclosure_type = publicRecord_data.type;
                if (publicRecord_data.dateFiled != null && publicRecord_data.dateFiled != null)
                {
                    forclosure_date = publicRecord_data.dateFiled.Value;
                }
                else
                {
                    forclosure_date = publicRecord_data.dateFiled.Value;
                }


                if (forclosure_date >= forclosurestartdate && forclosuretype.Contains(forclosure_type))
                {
                    rule6counter = rule6counter + 1;
                }
            }
            rule6 = OnRuleCheck(rule6counter, rule6val, declinedif);
       

            _ruleMessage = shortDesc.ToUpper() + ": " + description + " " + rule6counter;
            _ruleId = shortDesc;
            _ruleVal = rule6;
            ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + " " + declinedif + "  " + rule6val);


        }

    }

}
