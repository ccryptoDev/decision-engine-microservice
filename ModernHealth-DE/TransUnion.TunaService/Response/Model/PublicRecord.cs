using System;

namespace DecisionEngine.TunaService.Response.Model
{
    public class PublicRecord
    {
        public string type { get; set; }
        public PublicRecordSubscriber subscriber { get; set; }
        public string dockNumber { get; set; }
        public string attorney { get; set; }
        public string plaintiff { get; set; }

        public DateTime? dateEffective { get; set; }
        public DateTime? dateFiled { get; set; }
        public DateTime? datePaid { get; set; }
        public string liabilities { get; set; }
        public string ECOADesignator { get; set; }
        public PublicRecordSource source { get; set; }

    }
}
