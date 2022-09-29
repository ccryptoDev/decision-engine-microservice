using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
    public class Rule5 :Rules
    {
      
        public Rule5(DecisionRules rl, DateTime bankruptcystartdate, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult, Dictionary<string, string> ruledatacount)
        {
            System.Collections.ArrayList bankruptcytype = new System.Collections.ArrayList() { "CB", "TB", "1D", "1F", "1V", "1X", "2D", "2F", "2V", "2X", "3D", "3F", "3V", "3X", "7D", "7F", "7V", "7X" };
            var publicRecord_data = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.publicRecord;
            var collections = creditReportResult.TransUnion.Response.product.subject.subjectRecord.custom.credit.collection;
            DateTime bankruptcy_date;
            //Rule === R5:BK in last 24 mos
            int rule5val = rl.value;
            string shortDesc = rl.shortdesc.ToLower();
            string description = rl.description;
            string declinedif = declinedvalue(rl.declinedif).ToLower();

            var rule5counter = 0;
                var rule5 = 0;
                if (publicRecord_data != null)
                    {
                        var bankruptcy_type = publicRecord_data.type;
                        if (publicRecord_data.dateFiled != null && publicRecord_data.dateFiled != null) {
                             bankruptcy_date = publicRecord_data.dateFiled.Value;
                        }
                        else
                        {
                             bankruptcy_date = publicRecord_data.dateFiled.Value;
                        }
                        

                        if (bankruptcy_date >= bankruptcystartdate && bankruptcytype.Contains(bankruptcy_type))
                        {
                            rule5counter = rule5counter++;
                        }
                    }
            rule5 = OnRuleCheck(rule5counter, rule5val, declinedif);
           
            _ruleMessage = shortDesc.ToUpper() + ": " + description + " " + rule5counter;
            _ruleId = shortDesc;
            _ruleVal = rule5;

            ruledatacount.Add(_ruleId, shortDesc.ToUpper() + ": " + description + " " + declinedif + "  " + rule5val);
         
        }
    }
}
