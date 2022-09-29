using System.Collections.Generic;
using System.Linq;
using DecisionEngine.TunaService.Response.Model;

namespace DecisionEngine.Services.Models
{
    public class TransUnion
    {
        public int Id { get; set; }
        public List<AddOnProduct> AddOnProduct { get; set; }
        public List<CreditCollection> CreditCollection { get; set; }
        public List<Employment> Employment { get; set; }
        public string FirstName { get; set; }
        public List<string> HouseNumber { get; set; }
        public List<Inquiry> Inquiry { get; set; }
        public bool IsNoHit { get; set; }
        public bool IsOfac { get; set; }
        public bool IsMil { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public List<PublicRecord> PublicRecord { get; set; }
        public TunaService.Response.CreditReportResponse Response { get; set; }
        public string Score { get; set; }
        public string SocialSecurity { get; set; }
        public int Status { get; set; }
        public List<Trade> Trade { get; set; }
        public List<Collection> Collection { get; set; }
        public string User { get; set; }


        public void UpdateProductScore()
        {
            if (AddOnProduct != null)
            {
                var productCodes = new string[] { "001NN", "00V60", "00N94", "00P94", "00W18", "00Q88", "00P02" };
                AddOnProduct.ForEach(p =>
                {
                    if (productCodes.Any(a => a == p.code))
                    {
                        var scoreResult = p.scoreModel?.score?.results;
                        if (scoreResult == "+")
                        {
                            p.scoreModel.score.results = "+0";
                        }
                    }
                });

                AddOnProduct.ForEach(p =>
                {
                    if (productCodes.Any(a => a == p.code))
                    {
                        this.Score = p.scoreModel?.score?.results;
                        if (string.IsNullOrEmpty(this.Score))
                            return;
                    }
                });
            }
        }
    }
}
