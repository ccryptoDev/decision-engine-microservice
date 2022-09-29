using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.TunaService.Response.Model
{
    public class Collection
    {
        public CollectionSubscriber subscriber { get; set; }
        public string portfolioType { get; set; }
        public string accountNumber { get; set; }
        public string ECOADesignator { get; set; }
        public IndicativeDate dateOpened { get; set; }
        public IndicativeDate dateEffective { get; set; }
        public IndicativeDate dateClosed { get; set; }

        public string closedIndicator { get; set; }
        public float currentBalance { get; set; }
        public CollectionOriginal original { get; set; }
        public string pastDue { get; set; }
        public string accountRating { get; set; }
        public Remark remark { get; set; }
        public string amount { get; set; }
        public string updateMethod { get; set; }
    }
}
