using System;
using System.Collections.Generic;
using System.Linq;
using DecisionEngine.TunaService.Response.Model;

namespace DecisionEngine.Services.Parsers
{
    public partial class ResponseParser
    {
        public static Models.Response.CreditReportResult CreateCreditReportResult(TunaService.Response.CreditReportResponse response, Services.Models.Request.CreditReportRequest request)
        {
            if (response.product.error != null)
                ThrowException(response.product.error);

            var ssn = response.product?.subject?.subjectRecord?.indicative?.socialSecurity?.number;
            if (string.IsNullOrEmpty(ssn))
                ssn = request.SsnNumber;

            if (ssn != request.SsnNumber)
                request.SsnNumber = ssn;

            //Create History records

            var transUnions = BuildTransUnion(response, request);
            var score = string.IsNullOrEmpty(transUnions.Score) ? 0 : Convert.ToInt32(transUnions.Score.Substring(1)); /// Check this

            double monthlyDebt = GetMonthlyTradeDebt(response.product?.subject?.subjectRecord?.custom?.credit?.trade);
            if (transUnions.Trade == null)
            {
                transUnions.Trade = new List<Trade> { CreateTrade() };
            }
            else if (transUnions.Trade.Count == 0)
            {
                transUnions.Trade.Add(CreateTrade());
            }
           
            var screenTracking = new Services.Models.ScreenTracking
            {
                CreditScore = score,
                IsMil = transUnions.IsMil,
                IsNoHit = transUnions.IsNoHit,
                IsOfac = transUnions.IsOfac,
                TransUnion = transUnions
            };

            return new Services.Models.Response.CreditReportResult
            {
                CreditScore = score,
                MonthlyDebt = monthlyDebt,
                ScreenTracking = screenTracking,
                Success = true,
                TransUnion = transUnions
            };
        }

        public static Models.Response.CreditPullResult CreateCreditPullResult(TunaService.Response.CreditReportResponse response, Services.Models.Request.CreditReportRequest request)
        {
            if (response.product.error != null)
                ThrowException(response.product.error);

            var ssn = response.product?.subject?.subjectRecord?.indicative?.socialSecurity?.number;
            if (string.IsNullOrEmpty(ssn))
                ssn = request.SsnNumber;

            if (ssn != request.SsnNumber)
                request.SsnNumber = ssn;

            //Create History records

            var transUnions = BuildTransUnion(response, request);
            var score = string.IsNullOrEmpty(transUnions.Score) ? 0 : Convert.ToInt32(transUnions.Score.Substring(1)); /// Check this

            double monthlyDebt = GetMonthlyTradeDebt(response.product?.subject?.subjectRecord?.custom?.credit?.trade);
            //if (transUnions.Trade == null)
            //{
            //    transUnions.Trade = new List<Trade> { CreateTrade() };
            //}
            //else if (transUnions.Trade.Count == 0)
            //{
            //    transUnions.Trade.Add(CreateTrade());
            //}

          

            return new Services.Models.Response.CreditPullResult
            {
                CreditScore = score,
                MonthlyDebt = monthlyDebt,
                CreditPulled = true
            };
        }


        private static Services.Models.TransUnion BuildTransUnion(TunaService.Response.CreditReportResponse response, Services.Models.Request.CreditReportRequest request)
        {
            var subjectRecord = response.product?.subject?.subjectRecord;

            var person = new Person
            {
                first = request.FirstName,
                middle = request.MiddleName,
                last = request.LastName
            };

            var names = subjectRecord?.indicative?.name;
            if (names != null && names.Any())
            {
                var p = names.First().person;
                person.first = p?.first ?? request.FirstName;
                person.middle = p?.middle ?? request.MiddleName;
                person.last = p?.last ?? request.LastName;
            }


            Services.Models.TransUnion transUnion = new Services.Models.TransUnion
            {
                FirstName = person.first,
                MiddleName = person.middle,
                LastName = person.last,
                IsNoHit = subjectRecord?.fileSummary?.fileHitIndicator != "regularHit",
                IsOfac = subjectRecord?.addOnProduct?.FirstOrDefault(x => x.ofacNameScreen != null)?.ofacNameScreen == null ? false : true,
                IsMil = subjectRecord?.addOnProduct?.FirstOrDefault(x => x.militaryLendingActSearch != null)?.militaryLendingActSearch == null ? false : true,
                Response = response,
                SocialSecurity = subjectRecord?.indicative?.socialSecurity?.number ?? request.SsnNumber,
                Status = 0,
                User = request.Id,
                Employment = subjectRecord?.indicative?.employment,
                Trade = subjectRecord?.custom?.credit?.trade,
                Inquiry= subjectRecord?.custom?.credit?.inquiry,
               Collection = subjectRecord?.custom?.credit?.collection
            };

            //AddOnProduct
            var addProduct = subjectRecord?.addOnProduct;
            if (addProduct != null)
            {
                transUnion.AddOnProduct = addProduct;
            }

            //Address

            //CreditCollection

            //PublicRecord
            var publicRecord = subjectRecord?.custom?.credit?.publicRecord;
            if (publicRecord != null)
            {
                transUnion.PublicRecord = new List<PublicRecord> { publicRecord };
            }

            //Inquiry
            /* var inquiry = subjectRecord?.custom?.credit?.inquiry;
             if (inquiry != null)
             {
                 transUnion.Inquiry = new List<Inquiry> { inquiry };
             }*/
           /* var collection = subjectRecord?.custom?.credit?.collection;
            if (collection != null)
            {
                transUnion.Collection = new List<Collection> { collection };
            }*/
          
            transUnion.UpdateProductScore();
            return transUnion;
        }

        private static double GetMonthlyTradeDebt(List<Trade> trades)
        {
            double tradeBalance = 0;

            if (trades == null || !trades.Any())
                return tradeBalance;

            trades.ForEach(trade =>
            {
                var industryCode = trade?.subscriber?.industryCode?.ToUpper();
                var ecoa = trade?.ECOADesignator == null ? "undesignated" : trade?.ECOADesignator.ToLower();
                if (ecoa == "authorizeduser" || ecoa == "terminated" || ecoa == "deceased")
                {
                    return; // "undesignated","individual","jointcontractliability","authorizeduser","participant","cosigner","primary","terminated","deceased"
                }

                var currentBalane = string.IsNullOrEmpty(trade?.currentBalance) ? 0 : Convert.ToInt64(trade?.currentBalance);
                if (industryCode != "M")
                {
                    var dateClosed = trade?.dateClosed?.Value;
                    var datePaidOut = trade?.datePaidOut?.Value;
                    double scheduledMonthlyPayment = 0;

                    if (trade?.terms != null && trade?.terms?.scheduledMonthlyPayment != null)
                    {
                        scheduledMonthlyPayment = Convert.ToDouble(trade?.terms?.scheduledMonthlyPayment);
                    }

                    if (dateClosed.HasValue || datePaidOut.HasValue || currentBalane == 0)
                        return;

                    tradeBalance = Convert.ToDouble(tradeBalance + scheduledMonthlyPayment).RoundUp(2);
                }

            });

            return tradeBalance;
        }

        private static Trade CreateTrade()
        {
            var today = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            return new Trade
            {
                subscriber = new TradeSubscriber
                {
                    industryCode = "R",
                    memberCode = "",
                    name = new TradeName
                    {
                        unparsed = "REQUESTED AMOUNT"
                    }
                },
                portfolioType = "requesting",
                accountNumber = "",
                ECOADesignator = "",
                dateOpened = new ResponseDate { Value = today },
                dateEffective = new ResponseDate { Value = today },
                currentBalance = "0", //Double
                highCredit = "0", //Double
                creditLimit = 0, //Dobule
                accountRating = "01",
                account = new Account
                {
                    type = "RQ"
                },
                pastDue = "000000000",
                updateMethod = "requested"
            };
        }
        private static Trade CreateCollection()
        {
            var today = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            return new Trade
            {
                subscriber = new TradeSubscriber
                {
                    industryCode = "Y",
                    memberCode = "",
                    name = new TradeName
                    {
                        unparsed = "REQUESTED AMOUNT"
                    }
                },
                portfolioType = "requesting",
                accountNumber = "",
                ECOADesignator = "",
                dateOpened = new ResponseDate { Value = today },
                dateEffective = new ResponseDate { Value = today },
                currentBalance = "0", //Double
                highCredit = "0", //Double
                creditLimit = 0, //Dobule
                accountRating = "01",
                account = new Account
                {
                    type = "RQ"
                },
                pastDue = "000000000",
                updateMethod = "requested"
            };
        }
        private static void ThrowException(ProductError err)
        {
            throw new TunaService.TunaServiceException(
                    System.Net.HttpStatusCode.OK,
                    "OK",
                    err.description,
                    new TunaService.TunaServiceError
                    {
                        ErrorCode = err.code,
                        ErrorText = err.description
                    });
        }
    }
}
