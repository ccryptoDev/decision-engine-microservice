using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.Services.Models.Response
{
    public class CreditPullResult
    {
        public int CreditScore { get; set; }
        public double MonthlyDebt { get; set; }
        public bool CreditPulled { get; set; }
    }
}
