using DecisionEngine.BAL.DTO;
using DecisionEngine.BAL.Interface;
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
    public class OfferController : ControllerBase
    {
       
        private readonly IOfferService _offerService;
        private readonly ILogger<OfferController> _logger;
        public OfferController(IOfferService offerService, ILogger<OfferController> logger)
        {
            this._offerService = offerService;
            _logger = logger;
          
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CreateResponseDTO>> addOffer(CreateOfferRequestDTO offerDTO)
        {
            try
            {
                var res = _offerService.CreateOffer(offerDTO);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<CreateResponseDTO>> updateOffer(OfferDTO offerDTO)
        {
            try
            {
                var res = _offerService.UpdateOffer(offerDTO);

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
        public async Task<ActionResult<string>> DeleteOffer(int id)
        {
            try
            {
                var res = _offerService.DeleteOffer(id);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("offers/{settingId}")]
        public ActionResult<List<OfferDTO>> LoadOffers(long settingId)
        {
            try
            {

                var offers = _offerService.GetOffers(settingId);
                return Ok(offers);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

        [HttpGet]
        [Route("offer/{id}")]
        public ActionResult<OfferDTO> LoadOfferById(int id)
        {
            try
            {

                var offers = _offerService.LoadOfferById(id);
                return Ok(offers);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

        
    }
}
