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
    public class OfferLoanController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IOfferLoanService _offerLoanService;
        private readonly ILogger<OfferLoanController> _logger;
        public OfferLoanController(IOfferLoanService offerLoanService, ILogger<OfferLoanController> logger, IConfiguration configuration)
        {
            this._offerLoanService = offerLoanService;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CreateResponseDTO>> addOfferLoan(CreateOfferLoanRequestDTO createOfferLoanRequestDTO)
        {
            try
            {
                var res = _offerLoanService.CreateOfferLoan(createOfferLoanRequestDTO);

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
        public async Task<ActionResult<string>> updateOfferLoan(UpdateOfferLoanRequestDTO updateOfferLoanRequestDTO)
        {
            try
            {
                var res = _offerLoanService.UpdateOfferLoan(updateOfferLoanRequestDTO);

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
        public async Task<ActionResult<string>> DeleteOfferLoan(int id)
        {
            try
            {
                var res = _offerLoanService.DeleteOfferLoan(id);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("offerLoans")]
        public ActionResult<List<OfferLoanDTO>> LoadOfferLoans()
        {
            try
            {

                var offerLoans = _offerLoanService.GetOfferLoans();
                return Ok(offerLoans);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

        [HttpGet]
        [Route("offerLoan/{id}")]
        public ActionResult<OfferLoanDTO> LoadOfferLoanById(int id)
        {
            try
            {

                var offerLoans = _offerLoanService.LoadOfferLoanById(id);
                return Ok(offerLoans);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

        [HttpGet]
        [Route("offerLoanwithterms")]
        public ActionResult GetOfferLoanWithTerms()
        {
            try
            {

                var offerLoans = _offerLoanService.GetOfferLoansWithTerms();
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
