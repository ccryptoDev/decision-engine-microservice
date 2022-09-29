using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.DTO
{
   

    public class OfferLoanDTO
    {
        public long Id { get; set; }


        public string OfferName { get; set; }

        public string Grade { get; set; }
        public double Amount { get; set; }
    }
    public class CreateOfferLoanRequestDTO
    {
        public string OfferName { get; set; }

        public string Grade { get; set; }
        public double Amount { get; set; }
    }
    public class UpdateOfferLoanRequestDTO
    {
        public long id { get; set; }
        public string OfferName { get; set; }

        public string Grade { get; set; }
        public double Amount { get; set; }
    }
}
