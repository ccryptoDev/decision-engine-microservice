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
    public class OfferValueController : ControllerBase
    {
        private readonly IOfferValueService _offerValueService;
        private readonly ILogger<OfferValueController> _logger;
        public OfferValueController(IOfferValueService offerValueService, ILogger<OfferValueController> logger)
        {
            this._offerValueService = offerValueService;
            _logger = logger;

        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CreateResponseDTO>> addOfferValue(CreateOfferValueRequestDTO offerValueDTO)
        {
            try
            {
                var res = _offerValueService.CreateOfferValue(offerValueDTO);

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
        public async Task<ActionResult<CreateResponseDTO>> updateOfferValue(OfferValueDTO offerValueDTO)
        {
            try
            {
                var res = _offerValueService.UpdateOfferValue(offerValueDTO);

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
        public async Task<ActionResult<string>> DeleteOfferValue(int id)
        {
            try
            {
                var res = _offerValueService.DeleteOfferValue(id);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("offerValues/{settingId}")]
        public ActionResult<List<OfferValueDetailDTO>> LoadOfferValues(long settingId)
        {
            try
            {

                var offerValues = _offerValueService.GetOfferValues(settingId);
                return Ok(offerValues);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

        [HttpGet]
        [Route("offerValue/{id}")]
        public ActionResult<OfferValueDetailDTO> LoadOfferValueById(int id)
        {
            try
            {

                var offerValues = _offerValueService.LoadOfferValueById(id);
                return Ok(offerValues);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

    }
}
