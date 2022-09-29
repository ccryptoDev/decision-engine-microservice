using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Rules_Engine.BAL.DTO;
using Rules_Engine.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rules_Engine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferedTermController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IOfferedTermService _offerLoanService;
        private readonly ILogger<OfferedTermController> _logger;
        public OfferedTermController(IOfferedTermService offerLoanService, ILogger<OfferedTermController> logger, IConfiguration configuration)
        {
            this._offerLoanService = offerLoanService;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CreateResponseDTO>> addOfferedTerm(CreateOfferedTermRequestDTO request)
        {
            try
            {
                var res = _offerLoanService.CreateOfferedTerm(request);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<string>> updateOfferedTerm(UpdateOfferedTermRequestDTO request)
        {
            try
            {
                var res = _offerLoanService.UpdateOfferTerm(request);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }
        [HttpPost]
        [Route("delete/{id}")]
        public async Task<ActionResult<string>> DeleteOfferedTerm(int id)
        {
            try
            {
                var res = _offerLoanService.DeleteOfferTerm(id);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("offeredTerms/{loanOfferId}")]
        public ActionResult<List<OfferedTermDTO>> LoadOfferedTerms(int  loanOfferId)
        {
            try
            {

                var offerLoans = _offerLoanService.GetOfferTerms(loanOfferId);
                return Ok(offerLoans);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

        [HttpGet]
        [Route("offeredTerm/{id}")]
        public ActionResult<OfferedTermDTO> LoadOfferedTermById(int id)
        {
            try
            {

                var offerLoans = _offerLoanService.LoadOfferedTermById(id);
                return Ok(offerLoans);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }
    }
}
