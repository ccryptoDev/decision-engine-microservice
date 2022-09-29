using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DecisionEngine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransUnionServiceController : ControllerBase
    {
        private readonly ILogger<TransUnionServiceController> _logger;
        private readonly Services.ITransUnionService _transUnionService;
        public TransUnionServiceController(Services.ITransUnionService transUnionService, ILogger<TransUnionServiceController> logger)
        {
            _transUnionService = transUnionService;
            _logger = logger;
        }

        [HttpPost("CreditReport")]
        public async Task<IActionResult> CreditReport(Services.Models.Request.CreditReportRequest req)
        {
            try
            {
                Services.Models.Request.CreditReportRequest creditReportRequest = new Services.Models.Request.CreditReportRequest
                {
                    HardPull = false,
                    FirstName = req.FirstName,
                    LastName = req.LastName,
                    DateOfBirth = null,
                    Id = req.Id,
                    SsnNumber = req.SsnNumber,
                    Address = new Services.Models.Address
                    {
                        City = req.Address.City,
                        State = req.Address.State,
                        ZipCode = req.Address.ZipCode,
                        StreetName = req.Address.StreetName,
                    }
                };
                var res = await _transUnionService.GetCreditReportAsync(creditReportRequest);
                return Ok(res);
            }
            catch (TunaService.TunaServiceException ex)
            {
                if (ex.ServiceErrorResponse.ErrorCode == "201")
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
        }

        [HttpGet("Test")]
        public async Task<IActionResult> GetTest()
        {
            Services.Models.Request.CreditReportRequest req = new Services.Models.Request.CreditReportRequest
            {
                HardPull = false,
                FirstName = "Temekasdere",
                LastName = "Adamserwe",
                DateOfBirth = null,
                Id = "1",
                SsnNumber = "666603693",
                Address = new Services.Models.Address
                {
                    City = "Stanton California",
                    State = "CA",
                    ZipCode = "90680",
                    StreetName = "8180 W Briarwood St Road",
                }
            };
            try
            {
                var res = await _transUnionService.GetCreditReportAsync(req);
                return Ok(res);
            }
            catch (TunaService.TunaServiceException ex)
            {
                if (ex.ServiceErrorResponse.ErrorCode == "201")
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}
