using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.Services.Models.Response
{
    public class RuleValidationResponse
    {
        public bool Success { get; set; }
        public IEnumerable<string> RuleFailedMessage { get; set; }
    }
}
