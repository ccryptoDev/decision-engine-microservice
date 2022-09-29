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
    public class TermGradeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITermGradeService _termGradeService;
        private readonly ILogger<TermGradeController> _logger;
        public TermGradeController(ITermGradeService termGradeService, ILogger<TermGradeController> logger, IConfiguration configuration)
        {
            this._termGradeService = termGradeService;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CreateResponseDTO>> addTermGrade(CreateTermGradeRequestDTO createTermGradeRequestDTO)
        {
            try
            {
                var res = _termGradeService.CreateTermGrade(createTermGradeRequestDTO);

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
        public async Task<ActionResult<string>> updateTermGrade(TermGradeDTO termGradeDTO)
        {
            try
            {
                var res = _termGradeService.UpdateTermGrade(termGradeDTO);

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
        public async Task<ActionResult<string>> DeleteTermGrade(int id)
        {
            try
            {
                var res = _termGradeService.DeleteTermGrade(id);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("termGrades/{settingId}")]
        public ActionResult<List<TermGradeDetailDTO>> LoadTermGrades(long settingId)
        {
            try
            {

                var termGrades = _termGradeService.GetTermGrades(settingId);
                return Ok(termGrades);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

        [HttpGet]
        [Route("termGrade/{id}")]
        public ActionResult<TermGradeDetailDTO> LoadTermGradeById(int id)
        {
            try
            {

                var termGrades = _termGradeService.LoadTermGradeById(id);
                return Ok(termGrades);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }
    }
}
