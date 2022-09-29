namespace DecisionEngine.TunaService.Request.Model
{
    public class TransactionControl
    {
        public string userRefNumber { get; set; }
        public Subscriber subscriber { get; set; }
        public Options options { get; set; }
    }
}
