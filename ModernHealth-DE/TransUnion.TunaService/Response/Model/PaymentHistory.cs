namespace DecisionEngine.TunaService.Response.Model
{
    public class PaymentHistory
    {
        public PaymentPattern paymentPattern { get; set; }
        public HistoricalCounters historicalCounters { get; set; }
        public MaxDelinquency maxDelinquency { get; set; }
    }
}
