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
    public class LoanController : ControllerBase
    {
        private readonly ILogger<LoanController> _logger;
        private readonly Services.ILoanService _loanService;
        private readonly DataService.IDecisionEngine _decisionEngine;
        public LoanController(Services.ILoanService loanService, DataService.IDecisionEngine decisionEngine, ILogger<LoanController> logger)
        {
            _loanService = loanService;
            _decisionEngine = decisionEngine;
            _logger = logger;
        }

        [HttpPost("CreditPull")]
        public async Task<IActionResult> CreditPull(Services.Models.Request.CreditReportRequest request)
        {
            try
            {
                var res = await _loanService.CreditPullAsync(request);
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

        [HttpPost("RuleValidate")]
        public IActionResult RuleValidate(Services.Models.Request.RuleValidationRequest request)
        {
            return Ok(_loanService.RuleValidate(request));
        }

        [HttpPost("ApprovedOffers")]
        public IActionResult ApprovedOffers(Services.Models.Request.LoanOffersRequest request)
        {
            if (request != null)
            {
                return Ok(_decisionEngine.GetOffers(request.Income, request.CrediScore, request.MonthlyDebt));
            }
            else
            {
                return BadRequest("LoanOffersRequest is null");
            }
        }
    }
}
