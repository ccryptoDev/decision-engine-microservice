using DecisionEngine.BAL.Interface;
using DecisionEngine.DAL.Interface;
using DecisionEngine.Services.Models;
//using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DecisionEngine.BAL.Service
{
    public class DecisionService : IDecisionService
    {
        IDecisionRepository _decisionRepository;

        public DecisionService(IDecisionRepository decisionRepository)
        {
            this._decisionRepository = decisionRepository;
        }
        public async Task<LoanOffersResponse> GetApprovedOffers(LoanOffersRequest loanOffersRequest, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult)
        {
           
            return await _decisionRepository.GetApprovedOffers(loanOffersRequest,creditReportResult);
           
        }
    }
}
