//using DecisionEngine.Entities.Entity;
using DecisionEngine.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DecisionEngine.DAL.Interface
{
    public interface IDecisionRepository
    {
        Task<LoanOffersResponse> GetApprovedOffers(LoanOffersRequest loanOffersRequest, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult);
    }
}
