using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using DecisionEngine.BAL.DTO;
using DecisionEngine.BAL.Interface;
using DecisionEngine.BAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecisionEngine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRulesService _rulesService;
        private readonly ILogger<RulesController> _logger;
        public RulesController(IRulesService rulesService, ILogger<RulesController> logger, IConfiguration configuration)
        {
            this._rulesService = rulesService;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("addRule")]
        public async Task<ActionResult<string>> addRule(RulesRequestDTO ruleDTO)
        {
            try
            {
                var res = _rulesService.CreateRule(ruleDTO);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }
        [HttpPost]
        [Route("updateRule")]
        public async Task<ActionResult<string>> UpdateRule(UpdateRulesRequestDTO ruleDTO)
        {
            try
            {
                var res = _rulesService.UpdateRule(ruleDTO);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }
        [HttpPost]
        [Route("addDescription")]
        public async Task<ActionResult<string>> addDescription(RuleDescriptionRequestDTO ruleDTO)
        {
            try
            {
                var res = _rulesService.CreateRuleDescription(ruleDTO);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateRuleDescriptionRequestDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateRuleDescription")]
        public ActionResult<string> updateDescription(UpdateRuleDescriptionRequestDTO updateRuleDescriptionRequestDTO)
        {
            try
            {
                var res = _rulesService.UpdateRuleDescription(updateRuleDescriptionRequestDTO);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }


        [HttpGet]
        [Route("LoadRules/{setting_id}")]
        public ActionResult<List<RuleResponseDTO>> LoadRules(long setting_id)
        {

            var cardholder = _rulesService.GetLoadRules(setting_id);
            return Ok(cardholder);
        }

        [HttpGet]
        [Route("LoadRuleDescription")]
        public ActionResult<List<RuleDescriptionDTO>> LoadRuleDescription()
        {

            var cardholder = _rulesService.GetLoadRuleDescription();
            return Ok(cardholder);
        }
        [HttpGet]
        [Route("RuleDescriptions")]
        public ActionResult<List<RuleDescriptionDTO>> GetRuleDescriptions()
        {
            try
            {
                var cardholder = _rulesService.GetRuleDescriptions();
                return Ok(cardholder);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("SettingRule/{setting_id}")]
        public ActionResult<string> InsertSettingRule(long setting_id)
        {

            var cardholder = _rulesService.InsertSettingRule(setting_id);
            return Ok(cardholder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateRuleDescriptionRequestDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SettingRules")]
        [NonAction]
        public ActionResult<string> AddOrUpdateSettingRule(List<SettingRuleDto> settingRulesDto)
        {
            try
            {
                var res = _rulesService.AddOrUpdateSettingRule(settingRulesDto);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());
                return NotFound(ex.Message.ToString());
            }
        }


        [HttpGet]
        [Route("SettingRules/{setting_id}")]
        [NonAction]
        public ActionResult<List<RuleResponseDTO>> GetLoadSettingRules(long setting_id)
        {

            var cardholder = _rulesService.GetLoadSettingRules(setting_id);
            return Ok(cardholder);
        }
    }
}
