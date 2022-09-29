
using DecisionEngine.BAL.Interface;
using DecisionEngine.Services.Models;
//using DecisionEngine.Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecisionEngine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecisionController : ControllerBase
    {
        private readonly ILogger<DecisionController> _logger;
        private readonly Services.ITransUnionService _transUnionService;
        private readonly IDecisionService _decisionService;
        public DecisionController(Services.ITransUnionService transUnionService, IDecisionService decisionService, ILogger<DecisionController> logger)
        {
            _transUnionService = transUnionService;
            _decisionService = decisionService;
            _logger = logger;
        }

        [HttpPost("offer")]
        public ActionResult<LoanOffersResponse> GetTest()
        {

            try
            {
                //var res = await _transUnionService.GetCreditReportAsync(req);
                LoanOffersRequest loanOffersRequest = new LoanOffersRequest
                {
                    CrediScore = 600,
                    Income = 1500,
                    MonthlyDebt = 10,
                    FirstName = "Carlos",
                    LastName = "Cervantes",
                    SsnNumber = "103443828",
                    settingId=0

                };
                var offerResponse = _decisionService.GetApprovedOffers(loanOffersRequest, null);
                return Ok(offerResponse);
            }
            catch (TunaService.TunaServiceException ex)
            {
                if (ex.ServiceErrorResponse.ErrorCode == "201")
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
        }

        [HttpPost("approvedOffers")]
        public async Task<IActionResult> GetApprovedOffers(DecisionEngine.Services.Models.Request.CreditReportRequest req)
        {

            try
            {
                Services.Models.Request.CreditReportRequest creditReportRequest = new Services.Models.Request.CreditReportRequest
                {
                    HardPull = false,
                    FirstName = req.FirstName,
                    LastName = req.LastName,
                    DateOfBirth = null,
                    Id = req.Id,
                    SsnNumber = req.SsnNumber,
                    
                    Address = new Services.Models.Address
                    {
                        City = req.Address.City,
                        State = req.Address.State,
                        ZipCode = req.Address.ZipCode,
                        StreetName = req.Address.StreetName,
                    }
                };
                var res = await _transUnionService.GetCreditReportAsync(creditReportRequest);
                /*  if(res.CreditScore==0)
                  {
                      LoanOffersResponse loanOffersResponse = new LoanOffersResponse
                      {
                          Status = "Failed",
                          Message = "Credit Report is invalid."
                      };
                      return Ok(loanOffersResponse);
                  }*/
                LoanOffersRequest loanOffersRequest = new LoanOffersRequest
                {
                    CrediScore = res.CreditScore,
                    Income = req.loanAmount,
                    MonthlyDebt = res.MonthlyDebt,
                    FirstName = creditReportRequest.FirstName,
                    LastName = creditReportRequest.LastName,
                    SsnNumber = creditReportRequest.SsnNumber,
                    settingId=req.settingId,
                     bankRules=req.bankRules
                };
                var offerResponse = await _decisionService.GetApprovedOffers(loanOffersRequest, res);
                res.loanOffersResponse = offerResponse;
                //offerResponse..creditReportResult = res;
                return Ok(res);
            }
            catch (TunaService.TunaServiceException ex)
            {
                if (ex.ServiceErrorResponse.ErrorCode == "201")
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
        }

    }
}
