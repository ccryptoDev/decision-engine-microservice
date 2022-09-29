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
    public class GradeAPRController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IGradeAPRService _gradeService;
        private readonly ILogger<GradeAPRController> _logger;
        public GradeAPRController(IGradeAPRService gradeService, ILogger<GradeAPRController> logger, IConfiguration configuration)
        {
            this._gradeService = gradeService;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CreateResponseDTO>> addGradeAPR(CreateGradeRequestDTO createGradeRequestDTO)
        {
            try
            {
                var res = _gradeService.CreateGradeAPR(createGradeRequestDTO);

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
        public async Task<ActionResult<string>> updateGradeAPR(UpdateGradeRequestDTO updateGradeRequestDTO)
        {
            try
            {
                var res = _gradeService.UpdateGradeAPR(updateGradeRequestDTO);

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
        public async Task<ActionResult<string>> DeleteGradeAPR(int id)
        {
            try
            {
                var res = _gradeService.DeleteGradeAPR(id);

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
        public ActionResult<List<GradeAPRDTO>> LoadGradeAPRs(long settingId)
        {
            try
            {

                var grades = _gradeService.GetGradeAPRs(settingId);
                return Ok(grades);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

        [HttpGet]
        [Route("gradeapr-details/{settingId}")]
        public ActionResult<List<GradeAPRDTO>> LoadGradeAPRDetails(long settingId)
        {
            try
            {

                var grades = _gradeService.GetGradeAPRDetails(settingId);
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
        public ActionResult<GradeAPRDTO> LoadGradeAPRById(int id)
        {
            try
            {

                var grades = _gradeService.LoadGradeAPRById(id);
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
