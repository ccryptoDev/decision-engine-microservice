using System.Collections.Generic;

namespace DecisionEngine.TunaService.Request.Model
{
    public class SubjectRecord
    {
        public int fileNumber { get; set; }
        public Indicative indicative { get; set; }
        public List<AddOnProduct> addOnProduct { get; set; }
    }
}
