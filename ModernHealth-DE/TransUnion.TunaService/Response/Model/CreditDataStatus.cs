namespace DecisionEngine.TunaService.Response.Model
{
    public class CreditDataStatus
    {
        public bool suppressed { get; set; }
        public DoNotPromote doNotPromote { get; set; }
        public Freeze freeze { get; set; }
        public bool minor { get; set; }
        public bool disputed { get; set; }
    }
}
