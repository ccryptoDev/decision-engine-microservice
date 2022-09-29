using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DecisionEngine.Services.Models.Request;
using DecisionEngine.Services.Models.Response;

namespace DecisionEngine.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILogger<LoanService> _logger;
        private readonly Services.TransUnionSettings _settings;
        private readonly TunaService.ITransUnionClient _transUnionClient;
        public LoanService(TunaService.ITransUnionClient transUnionClient, IOptions<Services.TransUnionSettings> settings, ILogger<LoanService> logger)
        {
            _transUnionClient = transUnionClient;
            _logger = logger;
            _settings = settings.Value;

            //Register logging
            this.EnableRequestAndResponseXmlLogging();
        }

        public LoanOffersResponse ApprovedOffers(LoanOffersRequest request)
        {
            return new LoanOffersResponse
            {
                Status = "APPROVED",
                Offers = new List<LoanOffer>
                {
                    new LoanOffer
                    {
                        Apr = 14.9,
                        FinalRequestedLoanAmount = 9000,
                        FinancedAmount = 9000,
                        FullNumberAmount = 118,
                        InterestFeeAmount = 742.8,
                        InterestRate = 14.9,
                        LoanAmount = 9000,
                        LoanGrade = 'B',
                        LoanId = Guid.NewGuid(),
                        LoanTerm = 12,
                        MaxCreditScore = 819,
                        MaxDTI = 40,
                        MaximumAmount = 25000,
                        MinCreditSCore = 780,
                        MinDTI = 30,
                        MinimumAmount = 500,
                        MonthlyPayment = 811.9,
                        PaymentFrequency = "Monthly",
                        TotalLoanAmount = 9742.8
                    },
                    new LoanOffer
                    {
                        Apr = 14.9,
                        FinalRequestedLoanAmount = 9000,
                        FinancedAmount = 9000,
                        FullNumberAmount = 435,
                        InterestFeeAmount = 1462.8,
                        InterestRate = 14.9,
                        LoanAmount = 9000,
                        LoanGrade = 'B',
                        LoanId = Guid.NewGuid(),
                        LoanTerm = 24,
                        MaxCreditScore = 819,
                        MaxDTI = 40,
                        MaximumAmount = 25000,
                        MinCreditSCore = 780,
                        MinDTI = 30,
                        MinimumAmount = 500,
                        MonthlyPayment = 435.95,
                        PaymentFrequency = "Monthly",
                        TotalLoanAmount = 10462.8
                    },
                    new LoanOffer
                    {
                        Apr = 14.9,
                        FinalRequestedLoanAmount = 9000,
                        FinancedAmount = 9000,
                        FullNumberAmount = 361,
                        InterestFeeAmount = 1835.1,
                        InterestRate = 14.9,
                        LoanAmount = 9000,
                        LoanGrade = 'A',
                        LoanId = Guid.NewGuid(),
                        LoanTerm = 30,
                        MaxCreditScore = 819,
                        MaxDTI = 30,
                        MaximumAmount = 30000,
                        MinCreditSCore = 780,
                        MinDTI = 20,
                        MinimumAmount = 500,
                        MonthlyPayment = 361.17,
                        PaymentFrequency = "Monthly",
                        TotalLoanAmount = 10835.1
                    }
                },
                ApprovedUpTo = 10800,
                Requestedloanamount = 9000,
                Message = "Offers retrieved."
            };
        }

        public async Task<CreditPullResult> CreditPullAsync(CreditReportRequest request)
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
                CreditPullResult result = Parsers.ResponseParser.CreateCreditPullResult(tunaResponse, request);

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

        public RuleValidationResponse RuleValidate(RuleValidationRequest requeset)
        {
            return new RuleValidationResponse
            {
                Success = true
            };
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
