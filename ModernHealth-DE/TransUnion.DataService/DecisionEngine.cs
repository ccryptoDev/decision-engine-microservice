using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;

namespace DecisionEngine.DataService
{
    public class DecisionEngine : IDecisionEngine
    {
        private readonly string connectionString;
        public DecisionEngine(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public Models.LoanOffersResponse GetOffers(long loanAmount, int creditScore, int monthlyDebt)
        {
            var gradeAprs = GetGradeAndApr(loanAmount, creditScore, monthlyDebt);
            var ga = gradeAprs.FirstOrDefault();

            var offers = GetOfferTerms(ga.Grade).ToList();

            List<Models.LoanOffer> loanOffers = new List<Models.LoanOffer>();
            foreach (var o in offers)
            {
                loanOffers.Add(new Models.LoanOffer
                {
                    Apr = ga.Apr,
                    FinalRequestedLoanAmount = loanAmount,
                    FinancedAmount = loanAmount,
                    FullNumberAmount = 0,
                    InterestFeeAmount = 0,
                    InterestRate = 0,
                    LoanAmount = loanAmount,
                    LoanGrade = ga.Grade,
                    LoanTerm = o.OfferedTerm,
                    MaxCreditScore = ga.MaxScore,
                    MaxDTI = 40,
                    MaximumAmount = ga.MaxIncome,
                    MinCreditSCore = ga.MinScore,
                    MinDTI = 30,
                    MinimumAmount = ga.MinIncome,
                    MonthlyPayment = o.AvgMonthlyPayment,
                    PaymentFrequency = "Monthly",
                    TotalLoanAmount = 0
                });
            }


            var result = new Models.LoanOffersResponse
            {
                Status = "APPROVED",
                Offers = loanOffers,
                ApprovedUpTo = loanAmount,
                Requestedloanamount = loanAmount,
                Message = "Offers retrieved."
            };

            return result;
        }

        #region Private DB methods

        private IEnumerable<GradeApr> GetGradeAndApr(long loanAmount, int crediScore, int MonthlyDebt)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = " select ga.id,ga.grade, ga.apr, s.from_score as MinScore, s.to_score as MaxScore,ic.min_income as MinIncome, ic.max_income as MaxIncome " +
                                " from public.tbl_gradeapr ga  inner join public.tbl_income ic on ga.income_id = ic.id inner join public.tbl_score s on ga.score_id = s.id  " +
                                " where ga.active = true and ic.active = true and s.active = true and s.from_score< @Score and s.to_score >= @Score and  " +
                                " ic.min_income < @Income and ic.max_income >= @Income ";

                return dbConnection.Query<GradeApr>(query, new { Score = crediScore, Income = loanAmount });
            }
        }

        private IEnumerable<OfferTerm> GetOfferTerms(string grade)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = " select ola.id,ola.grade,ola.offer_name as OfferName,ola.amount as Amount,ot.term_name as TermName, " +
                                " ot.offered_term as OfferedTerm, ot.avg_monthly_payment as AvgMonthlyPayment, ot.max_monthly_payment as MaxMonthlyPayment " +
                                " from public.tbl_offer_loan_amount ola inner join public.tbl_offered_term ot on ola.id= ot.loan_offer_id " +
                                " where ola.active =true and ot.active = true and ola.grade =@Grade";

                return dbConnection.Query<OfferTerm>(query, new { Grade = grade });
            }
        }

        #endregion
    }

    public class GradeApr
    {
        public string Grade { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }

        public long MinIncome { get; set; }
        public long MaxIncome { get; set; }
        public double Apr { get; set; }
    }

    public class OfferTerm
    {
        public long OfferId { get; set; }
        public string Grade { get; set; }
        public string OfferName { get; set; }
        public long Amount { get; set; }
        public string TernName { get; set; }

        public int OfferedTerm { get; set; }
        public double AvgMonthlyPayment { get; set; }
        public double MaxMonthlyPayment { get; set; }
    }
}
