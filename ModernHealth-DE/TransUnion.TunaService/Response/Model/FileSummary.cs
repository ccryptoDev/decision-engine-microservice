namespace DecisionEngine.TunaService.Response.Model
{
    public class FileSummary
    {
        public string fileHitIndicator { get; set; }
        public string ssnMatchIndicator { get; set; }
        public bool consumerStatementIndicator { get; set; }
        public string market { get; set; }
        public string submarket { get; set; }
        public CreditDataStatus creditDataStatus { get; set; }
        public IndicativeDate inFileSinceDate { get; set; }
    }
}
