using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DataService
{
    public interface IDecisionEngine
    {
        Models.LoanOffersResponse GetOffers(long loanAmount, int creditScore, int monthlyDebt);
    }
}
