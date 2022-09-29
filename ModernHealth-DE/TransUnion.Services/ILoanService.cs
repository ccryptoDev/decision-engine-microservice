using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DecisionEngine.Services
{
    public interface ILoanService
    {
        Task<Models.Response.CreditPullResult> CreditPullAsync(Models.Request.CreditReportRequest request);

        Models.Response.RuleValidationResponse RuleValidate(Models.Request.RuleValidationRequest requeset);

        Models.Response.LoanOffersResponse ApprovedOffers(Models.Request.LoanOffersRequest request);
    }
}
