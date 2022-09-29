using DecisionEngine.TunaService.Request.Model;

namespace DecisionEngine.TunaService.Request
{
    public class RequestBase
    {
        public string document { get; set; } = "request";

        public string version { get; set; }

        public TransactionControl transactionControl { get; set; }
    }
}
