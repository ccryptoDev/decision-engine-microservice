namespace DecisionEngine.TunaService.Response.Model
{
    public class Trade
    {
        public TradeSubscriber subscriber { get; set; }
        public string portfolioType { get; set; }
        public string accountNumber { get; set; }
        public string ECOADesignator { get; set; }
        public ResponseDate dateOpened { get; set; }
        public ResponseDate dateEffective { get; set; }
        public ResponseDate dateClosed { get; set; }
        public string closedIndicator { get; set; }
        public ResponseDate datePaidOut { get; set; }
        public string currentBalance { get; set; }
        public string highCredit { get; set; }
        public int? creditLimit { get; set; }
        public string accountRating { get; set; }

        public Remark remark { get; set; }
        public Terms terms { get; set; }

        public Account account { get; set; }
        public string pastDue { get; set; }

        public PaymentHistory paymentHistory { get; set; }
        public MostRecentPayment mostRecentPayment { get; set; }
        public string updateMethod { get; set; }
    }
}
