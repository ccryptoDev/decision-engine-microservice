using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ScoreController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IScoreService _scoreService;
        private readonly ILogger<ScoreController> _logger;
        public ScoreController(IScoreService scoreService, ILogger<ScoreController> logger, IConfiguration configuration)
        {
            this._scoreService = scoreService;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<CreateResponseDTO>> addScore(CreateScoreRequestDTO createScoreRequestDTO)
        {
            try
            {
                var res = _scoreService.CreateScore(createScoreRequestDTO);

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
        public async Task<ActionResult<string>> updateScore(UpdateScoreRequestDTO updateScoreRequestDTO)
        {
            try
            {
                var res = _scoreService.UpdateScore(updateScoreRequestDTO);

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
        public async Task<ActionResult<string>> DeleteScore(int id)
        {
            try
            {
                var res = _scoreService.DeleteScore(id);

                return Ok(new { result = res });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("scores")]
        public ActionResult<List<ScoreDTO>> LoadScores()
        {
            try
            {

                var scores = _scoreService.GetScores();
                return Ok(scores);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }

        [HttpGet]
        [Route("score/{id}")]
        public ActionResult<ScoreDTO> LoadScoreById(int id)
        {
            try
            {

                var scores = _scoreService.LoadScoreById(id);
                return Ok(scores);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());

                return NotFound(ex.Message.ToString());

            }
        }
    }
}
