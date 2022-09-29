using System;

namespace DecisionEngine.TunaService.Response.Model
{
    public class MaxDelinquency
    {
        public bool earliest { get; set; }
        public string amount { get; set; }
        public DateTime? date { get; set; }
        public string accountRating { get; set; }

    }
}
