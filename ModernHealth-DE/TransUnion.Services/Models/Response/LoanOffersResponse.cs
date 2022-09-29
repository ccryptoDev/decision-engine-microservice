using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.Services.Models.Response
{
    public class LoanOffersResponse
    {
        public string Status { get; set; }
        public IEnumerable<LoanOffer> Offers { get; set; }
        public long ApprovedUpTo { get; set; }
        public long Requestedloanamount { get; set; }
        public string Message { get; set; }
    }
    public class LoanOffer
    {
        public Guid LoanId { get; set; }
        public double Apr { get; set; }
        public long FinalRequestedLoanAmount { get; set; }
        public long FinancedAmount { get; set; }
        public double FullNumberAmount { get; set; }
        public double InterestFeeAmount { get; set; }
        public double InterestRate { get; set; }
        public long LoanAmount { get; set; }
        public char LoanGrade { get; set; }
        public int LoanTerm { get; set; }
        public int MaxCreditScore { get; set; }
        public int MinCreditSCore { get; set; }
        public double MaxDTI { get; set; }
        public double MinDTI { get; set; }
        public long MaximumAmount { get; set; }
        public long MinimumAmount { get; set; }
        public double MonthlyPayment { get; set; }
        public string PaymentFrequency { get; set; }
        public double TotalLoanAmount { get; set; }

    }
}
