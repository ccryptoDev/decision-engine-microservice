using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
   public class Rule7 : Rules
    {
       

        public Rule7(DecisionRules rl, DateTime publicrecordstartdate, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount)
        {
            var rule7counter = 0;
            var rule7 = 0;
            var publicRecord_data = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.publicRecord;
            var collections = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.collection;
            
            int rule7val = rl.value;
            string shortDesc = rl.shortdesc.ToLower();
            string description = rl.description;
            string declinedif = declinedvalue(rl.declinedif).ToLower();
            // R7: # public records in last 24 months 


            if (publicRecord_data!=null || collections.Count > 0)
            {
                DateTime dateFilled = publicRecord_data.dateFiled.Value;
                if (dateFilled >= publicrecordstartdate)
                {
                    rule7counter++;
                }
               foreach(var collection in collections)
                    {
                    float currentBalance = collection.currentBalance;
                    if (currentBalance > 0)
                    {
                        ++rule7counter;
                    }

                }
               
            }
            rule7 = OnRuleCheck(rule7counter, rule7val, declinedif);
                _ruleMessage = shortDesc.ToUpper() + ": " + description + " " + rule7counter;
                _ruleId = shortDesc;
                _ruleVal = rule7;
                ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + " " + declinedif +"  " + rule7val);
           

        }

    }
}
