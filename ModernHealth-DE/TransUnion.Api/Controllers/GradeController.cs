using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using DecisionEngine.BAL.DTO;
using DecisionEngine.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecisionEngine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IGradeService _gradeService;
        private readonly ILogger<GradeController> _logger;
        public GradeController(IGradeService gradeService, ILogger<GradeController> logger, IConfiguration configuration)
        {
            this._gradeService = gradeService;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CreateResponseDTO>> addGrade(CreateReguestGradeDTO gradeDTO)
        {
            try
            {
                var res = _gradeService.CreateGrade(gradeDTO);

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
        public async Task<ActionResult<CreateResponseDTO>> updateGrade(GradeDTO gradeDTO)
        {
            try
            {
                var res = _gradeService.UpdateGrade(gradeDTO);

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
        public async Task<ActionResult<string>> DeleteGrade(int id)
        {
            try
            {
                var res = _gradeService.DeleteGrade(id);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("grades/{settingId}")]
        public ActionResult<List<GradeDTO>> LoadGrades(long settingId)
        {
            try
            {

                var grades = _gradeService.GetGrades(settingId);
            return Ok(grades);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            
            }
        }

        [HttpGet]
        [Route("grade/{id}")]
        public ActionResult<GradeDTO> LoadGradeById(int id)
        {
            try
            {

                var grades = _gradeService.LoadGradeById(id);
                return Ok(grades);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

      
    }
}
