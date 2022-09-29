using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
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
        [Route("grades")]
        public ActionResult<List<GradeAPRDTO>> LoadGradeAPRs()
        {
            try
            {

                var grades = _gradeService.GetGradeAPRs();
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
        public class ActionGradeAPRHidingConvention : IActionModelConvention
        {
            public void Apply(ActionModel action)
            {
                // Replace with any logic you want
                if (action.Controller.ControllerName == "GradeAPR")
                {
                    action.ApiExplorer.IsVisible = false;
                }
            }
        }

        public class ControllerHidingConvention : IControllerModelConvention
        {
            public void Apply(ControllerModel controller)
            {
                // Replace with any logic you want
                if (controller.ControllerName == "GradeAPR")
                {
                    // This does not work
                    //controller.ApiExplorer.IsVisible = false;

                    // We need to hide all the actions
                    foreach (ActionModel action in controller.Actions)
                    {
                        action.ApiExplorer.IsVisible = false;
                    }
                }
            }
        }

        public class ControllerHidingAppConvention : IApplicationModelConvention
        {
            public void Apply(ApplicationModel application)
            {
                // We can also do it with an application model convention
                // Replace with any logic you want
                foreach (ControllerModel controller in application.Controllers.Where(c => c.ControllerName == "GradeAPR"))
                {
                    // This does not work
                    //controller.ApiExplorer.IsVisible = false;

                    // We need to hide all the actions
                    foreach (ActionModel action in controller.Actions)
                    {
                        action.ApiExplorer.IsVisible = false;
                    }
                }
            }
        }
    }
}
