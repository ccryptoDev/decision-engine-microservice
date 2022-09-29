using DecisionEngine.BAL.DTO;
using DecisionEngine.BAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecisionEngine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferGradeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IOfferGradeService _offergradeService;
        private readonly ILogger<OfferGradeController> _logger;
        public OfferGradeController(IOfferGradeService offergradeService, ILogger<OfferGradeController> logger, IConfiguration configuration)
        {
            this._offergradeService = offergradeService;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CreateResponseDTO>> addOfferGrade(CreateOfferGradeRequestDTO createOfferGradeRequest)
        {
            try
            {
                var res = _offergradeService.CreateOfferGrade(createOfferGradeRequest);

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
        public async Task<ActionResult<string>> updateOfferGrade(UpdateGradeRequestDTO updateGradeRequestDTO)
        {
            try
            {
                var res = _offergradeService.UpdateOfferGrade(updateGradeRequestDTO);

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
        public async Task<ActionResult<string>> DeleteOfferGrade(int id)
        {
            try
            {
                var res = _offergradeService.DeleteOfferGrade(id);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("offergrades/{settingId}")]
        public ActionResult<List<OfferGradeDTO>> LoadOfferGrades(long settingId)
        {
            try
            {

                var offergrades = _offergradeService.GetOfferGrades(settingId);
                return Ok(offergrades);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

      

        [HttpGet]
        [Route("offergrade/{id}")]
        public ActionResult<OfferGradeDTO> LoadOfferGradeById(int id)
        {
            try
            {

                var offergrades = _offergradeService.LoadOfferGradeById(id);
                return Ok(offergrades);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }
          [HttpGet]
        [Route("gradeavg/{grade_id}/{settingId}")]
        public ActionResult<GradeAvgsDTO> LoadGradeAvgs(long grade_id,long settingId)
        {
            try
            {

                var offergrades = _offergradeService.GetGradeAvgs(grade_id, settingId);
                return Ok(offergrades);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }
        [HttpGet]
        [Route("offervalue/{offer_id}")]
        public ActionResult<List<ResponseOfferValueDTO>> GetOfferValues(long offer_id)
        {
            try
            {

                var offergrades = _offergradeService.GetOfferValues(offer_id);
                return Ok(offergrades);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

    }
}
