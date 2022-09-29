using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.Services.Models.Request
{
    public class RuleValidationRequest
    {
        public int CreditScore { get; set; }
        public string CreditBureauResponse { get; set; }
    }
}
