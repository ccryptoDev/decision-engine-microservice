using System.Collections.Generic;
using System.Xml.Serialization;

namespace DecisionEngine.TunaService.Response.Model
{
    public class AddOnProduct
    {
        public string code { get; set; }
        public string status { get; set; }
       
        public IdMismatchAlert idMismatchAlert { get; set; }
      
        public ScoreModel scoreModel { get; set; }
        public OfacNameScreen ofacNameScreen { get; set; }
        public MilitaryLendingActSearch militaryLendingActSearch { get; set; }
        public HighRiskFraudAlert highRiskFraudAlert { get; set; }
        
    }
}
