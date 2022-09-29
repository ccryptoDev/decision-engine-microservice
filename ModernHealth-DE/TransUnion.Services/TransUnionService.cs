using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using DecisionEngine.Services.Models.Request;
using DecisionEngine.Services.Models.Response;

namespace DecisionEngine.Services
{
    public class TransUnionService : ITransUnionService
    {
        private readonly ILogger<TransUnionService> _logger;
        private readonly Services.TransUnionSettings _settings;
        private readonly TunaService.ITransUnionClient _transUnionClient;

        public TransUnionService(TunaService.ITransUnionClient transUnionClient, IOptions<Services.TransUnionSettings> settings, ILogger<TransUnionService> logger)
        {
            _transUnionClient = transUnionClient;
            _logger = logger;
            _settings = settings.Value;

            //Register logging
           this.EnableRequestAndResponseXmlLogging();
        }

        public async Task<CreditReportResult> GetCreditReportAsync(CreditReportRequest request)
        {
            //Create client requst
            _logger.LogInformation("Creating Tuna request object.");
            TunaService.Request.CreditReportRequest tunaRequest = Parsers.RequestParser.CreateCreditReportRequest(request, _settings);

            //Create Clent & Execute request
            try
            {
                _logger.LogInformation("Executing TransUnion request.");
                var tunaResponse = await _transUnionClient.ExecuteAsync<TunaService.Request.CreditReportRequest, TunaService.Response.CreditReportResponse>(tunaRequest);

                //Create result
                _logger.LogInformation("TransUnion response recieved successfully.");
                CreditReportResult result = Parsers.ResponseParser.CreateCreditReportResult(tunaResponse, request);

                return result;
            }
            catch (TunaService.TransUnionException ex)
            {
                _logger.LogError(ex, "TransUnion internal exception.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TransUnion Unhandled exception.");
                throw;
                //Return error response
            }
        }

        private void EnableRequestAndResponseXmlLogging()
        {
            if (_settings.EnableRequestXmlLogging)
                _transUnionClient.RequestXmlHandler = xml => _logger.LogInformation(xml);

            if (_settings.EnableResponseXmlLogging)
                _transUnionClient.ResponseXmlHandler = xml => _logger.LogInformation(xml);
        }

    }
}
