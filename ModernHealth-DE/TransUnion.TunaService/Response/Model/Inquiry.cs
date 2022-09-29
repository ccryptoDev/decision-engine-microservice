namespace DecisionEngine.TunaService.Response.Model
{
    public class Inquiry
    {
        public string ECOADesignator { get; set; }
        public InquirySubscriber subscriber { get; set; }
        public string accountType { get; set; }
        public IndicativeDate date { get; set; }
        public Requestor requestor { get; set; }
    }
}
