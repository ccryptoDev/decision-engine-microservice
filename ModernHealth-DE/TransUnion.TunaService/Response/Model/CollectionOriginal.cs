using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.TunaService.Response.Model
{
  public  class CollectionOriginal
    {
        public string creditorClassification { get; set; }
        public string balance { get; set; }
        public CollectionCreditGrantor creditGrantor { get; set; }
    }
}
