using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class IncomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IIncomeService _incomeService;
        private readonly ILogger<IncomeController> _logger;
        public IncomeController(IIncomeService incomeService, ILogger<IncomeController> logger, IConfiguration configuration)
        {
            this._incomeService = incomeService;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CreateResponseDTO>> addIncome(CreateIncomeRequestDTO createIncomeRequestDTO)
        {
            try
            {
                var res = _incomeService.CreateIncome(createIncomeRequestDTO);

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
        public async Task<ActionResult<string>> updateIncome(UpdateIncomeRequestDTO updateIncomeRequestDTO)
        {
            try
            {
                var res = _incomeService.UpdateIncome(updateIncomeRequestDTO);

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
        public async Task<ActionResult<string>> DeleteIncome(int id)
        {
            try
            {
                var res = _incomeService.DeleteIncome(id);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("incomes/{settingId}")]
        public ActionResult<List<IncomeDTO>> LoadIncomes(long settingId)
        {
            try
            {

                var incomes = _incomeService.GetIncomes(settingId);
                return Ok(incomes);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

        [HttpGet]
        [Route("income/{id}")]
        public ActionResult<IncomeDTO> LoadIncomeById(int id)
        {
            try
            {

                var incomes = _incomeService.LoadIncomeById(id);
                return Ok(incomes);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }
    }
}
