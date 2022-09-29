using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
  public class Rule1 : Rules
    {
        private DateTime _rule1startdate;

        public Rule1(DateTime rule1startdate, DecisionRules rl, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount)
        {
            int rule1val = rl.value;
            string shortDesc = rl.shortdesc.ToLower();
            string description = rl.description;
            string declinedif = declinedvalue(rl.declinedif).ToLower();
            _rule1startdate = rule1startdate;
            //Rule === R1:Months of Credit History (Month)
            var rule1 = 0;
            var fileSummary = creditReportResult.TransUnion.Response.product.subject.subjectRecord.fileSummary;
            if (fileSummary != null)
            {
                DateTime inFileSinceDate = Convert.ToDateTime(fileSummary.inFileSinceDate.Value);
              
                if (inFileSinceDate != null)
                {
                    rule1 = OnRuleDateCheck(inFileSinceDate, rule1startdate, declinedif);
                   
                }
              
            }
        
            _ruleMessage = shortDesc.ToUpper() + ": " + description + " : " + rule1val;
            _ruleId = shortDesc;
            _ruleVal = rule1;
            ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + " " + declinedif + "  " + rule1val);
       

        }
       
    }
}
