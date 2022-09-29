using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Rules_Engine.BAL.DTO;
using Rules_Engine.BAL.Interface;
using Rules_Engine.BAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rules_Engine.API.Controllers
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


        [HttpGet]
        [Route("LoadRules")]
        public ActionResult<List<RuleResponseDTO>> LoadRules()
        {

            var cardholder = _rulesService.GetLoadRules();
            return Ok(cardholder);
        }

        [HttpGet]
        [Route("LoadRuleDescription")]
        public ActionResult<List<RuleDescriptionDTO>> LoadRuleDescription()
        {

            var cardholder = _rulesService.GetLoadRuleDescription();
            return Ok(cardholder);
        }
    }
}
