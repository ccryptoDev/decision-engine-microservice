namespace DecisionEngine.TunaService.Response.Model
{
    public class TransactionControl
    {
        public string userRefNumber { get; set; }
        public Subscriber subscriber { get; set; }
        public Options options { get; set; }
        public Tracking tracking { get; set; }
    }
}
