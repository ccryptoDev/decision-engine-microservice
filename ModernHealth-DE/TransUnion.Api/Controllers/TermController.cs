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
    public class TermController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITermService _termService;
        private readonly ILogger<TermController> _logger;
        public TermController(ITermService termService, ILogger<TermController> logger, IConfiguration configuration)
        {
            this._termService = termService;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CreateResponseDTO>> addTerm(CreateTermRequestDTO createTermRequestDTO)
        {
            try
            {
                var res = _termService.CreateTerm(createTermRequestDTO);

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
        public async Task<ActionResult<string>> updateTerm(TermDTO updateTermRequestDTO)
        {
            try
            {
                var res = _termService.UpdateTerm(updateTermRequestDTO);

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
        public async Task<ActionResult<string>> DeleteTerm(int id)
        {
            try
            {
                var res = _termService.DeleteTerm(id);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("terms/{settingId}")]
        public ActionResult<List<TermDTO>> LoadTerms(long settingId)
        {
            try
            {

                var terms = _termService.GetTerms(settingId);
                return Ok(terms);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

        [HttpGet]
        [Route("term/{id}")]
        public ActionResult<TermDTO> LoadTermById(int id)
        {
            try
            {

                var terms = _termService.LoadTermById(id);
                return Ok(terms);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }
    }
}
