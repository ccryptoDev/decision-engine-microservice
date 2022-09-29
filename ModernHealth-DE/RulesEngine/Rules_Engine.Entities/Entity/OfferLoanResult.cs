using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.Entities.Entity
{
    public class OfferLoanResult
    {
        public int Id { get; set; }
        public string OfferName { get; set; }
        public double Amount { get; set; }

        public string Grade { get; set; }

        public string TermName { get; set; }

        public int TermValue { get; set; }

        public double AvgMonthlyPayment { get; set; }

        public double MaxMonthlyPayment { get; set; }

        public int LoanOfferId { get; set; }
    }
}
