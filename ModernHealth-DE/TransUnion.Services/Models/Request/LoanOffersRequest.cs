using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.Services.Models.Request
{
    public class LoanOffersRequest
    {
        public long Income { get; set; }
        public int CrediScore { get; set; }
        public int MonthlyDebt { get; set; }
        public string SsnNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
