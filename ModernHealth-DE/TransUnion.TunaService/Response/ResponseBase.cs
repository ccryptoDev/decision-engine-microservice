using DecisionEngine.TunaService.Response.Model;

namespace DecisionEngine.TunaService.Response
{
    public abstract class ResponseBase
    {
        public string document { get; set; } = "response";

        public string version { get; set; }

        public TransactionControl transactionControl { get; set; }
    }
}
