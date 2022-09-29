using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.DAL.Interface
{
    public interface IOfferLoanRepository
    {
        CreateResponse CreateOfferLoan(OfferLoan income);
        string UpdateOfferLoan(OfferLoan income);
        List<OfferLoan> GetOfferLoans();
        string DeleteOfferLoan(int id);

        OfferLoan LoadOfferLoanById(int id);
        List<OfferLoanResult> GetOfferLoanWithTerms(string grade = null);
    }
}
