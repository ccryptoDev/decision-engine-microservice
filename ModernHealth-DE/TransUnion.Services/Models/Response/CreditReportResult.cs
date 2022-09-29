namespace DecisionEngine.Services.Models.Response
{
    public class CreditReportResult
    {
        public int CreditScore { get; set; }
        public double MonthlyDebt { get; set; }
        public ScreenTracking ScreenTracking { get; set; }
        public bool Success { get; set; }
        public TransUnion TransUnion { get; set; }
        public TransUnionHistory TransUnionHistory { get; set; }

        public DecisionEngine.Services.Models.LoanOffersResponse  loanOffersResponse { get; set; }
    }
}
